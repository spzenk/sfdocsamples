using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using agsXMPP;
using agsXMPP.protocol;
using agsXMPP.protocol.client;
using agsXMPP.protocol.iq.search;


namespace agsXMPP.Client
{
    public partial class frmFindUsers : frmDialogBase
    {
        private string _IdFieldRequest = null;
        private string _IdSearchRequest = null;
        private bool _IsOldSearch = false;
        DataTable _dataTable= new DataTable(); 
        public frmFindUsers()
        {
            InitializeComponent();

            ///CArgo los servicios de busqueda
            foreach (Jid jid in Util.XmppServices.Search)
            {
                cboServices.Items.Add(jid.Bare);
            }

            dataGridView1.DataSource = _dataTable;
            dataGridView1.RowTemplate.Height = 20;
            dataGridView1.RowHeadersWidth = 24;
            dataGridView1.MultiSelect = false;
        }



        #region << Request Search Fields >>

        /// <summary>
        /// 
        /// *************BUSCAR CAMPOS********************
        /// Efectua una busqueda al server de los campos por los cuales buscar
        /// cboServices.SelectedItem.ToString()
        /// </summary>
        private void RequestSearchFields()
        {
            //Example 1. Requesting Search Fields

            //<iq type='get'
            //    from='romeo@montague.net/home'
            //    to='characters.shakespeare.lit'
            //    id='search1'
            //    xml:lang='en'>
            //  <query xmlns='jabber:iq:search'/>
            //</iq>


            cmdSearch.Enabled = false;

            SearchIq siq = new SearchIq();
            siq.Type = agsXMPP.protocol.client.IqType.get;
            siq.To = new Jid(cboServices.SelectedItem.ToString());

            // Remuevo alguna consulta pendiente si hay
            if (_IdFieldRequest != null)
                Util.XmppServices.XmppCon.IqGrabber.Remove(_IdFieldRequest);

            //guardo el Id de la nueva consulta 
            _IdFieldRequest = siq.Id;

            // Envio la consulta
            Util.XmppServices.XmppCon.IqGrabber.SendIq(siq, new IqCB(OnSearchFieldsResult), null);
        }


        /// <summary>
        /// Retorna los campos de la consulta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="iq"></param>
        /// <param name="data"></param>
        private void OnSearchFieldsResult(object sender, IQ iq, object data)
        {
            if (InvokeRequired)
            {
		
                BeginInvoke(new IqCB(OnSearchFieldsResult), new object[] { sender, iq, data });
                return;
            }

            if (iq.Type == IqType.result)
            {
                if (iq.Query is Search)
                {
                    Search search = iq.Query as Search;
                    if (search.Data != null)
                    {
                        xDataControl.CreateForm(search.Data);
                                        
                    }
                    else
                    {
                        // no xdata form returned from the search service.
                        // TODO should we add the old jabber search without xdata too? I don't think so.
                        //toolStripLabelForm.Text = String.Format("{0} returned no data form", iq.From.ToString());                        
                        xDataControl.CreateForm(search);
                        _IsOldSearch = true;
                    }
                    xDataControl.From = iq.From;
                    cmdSearch.Enabled = true;

                    toolStripStatusLabel1.Text = String.Format("search form from {0}", iq.From.ToString());
                }
            }
            else if (iq.Type == IqType.error)
            {
                toolStripStatusLabel1.Text = String.Format("{0} returned an error", iq.From.ToString());
            }
        }
        #endregion

        #region << Submit search request >>

        /// <summary>
        /// Efectuar consulta 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSearch_Click(object sender, EventArgs e)
        {
            /*
            
             Ejemlo Entity Submits Search Form

             <iq type='set'
                 from='juliet@capulet.com/balcony'
                 to='characters.shakespeare.lit'
                 id='search4'
                 xml:lang='en'>
               <query xmlns='jabber:iq:search'>
                 <x xmlns='jabber:x:data' type='submit'>
                   <field type='hidden' var='FORM_TYPE'>
                     <value>jabber:iq:search</value>
                   </field>
                   <field var='gender'>
                     <value>male</value>
                   </field>
                 </x>
               </query>
             </iq>
             */

            IQ searchIQ = null;
            if (!_IsOldSearch)
            {
                // validar entrada de datos
                if (xDataControl.Validate())
                {
                    searchIQ = new SearchIq();
                    //siq.To = xDataControl.From;
                    //siq.Type = IqType.set;
                    ((SearchIq)searchIQ).Query.Data = xDataControl.CreateResponse();
                }
            }
            else
            {
                searchIQ = new IQ();
                searchIQ.GenerateId();
                searchIQ.Query = xDataControl.CreateSearchResponse();
            }

            searchIQ.To = xDataControl.From;
            searchIQ.Type = IqType.set;
            // Elimino alguna antigua si existe
            if (_IdSearchRequest != null)
                Util.XmppServices.XmppCon.IqGrabber.Remove(_IdSearchRequest);

            // Guardo la actual consulta
            _IdSearchRequest = searchIQ.Id;

            // Envio el Iq
            Util.XmppServices.XmppCon.IqGrabber.SendIq(searchIQ, new IqCB(OnSearchResult), null);
        }

        private void OnSearchResult(object sender, IQ iq, object data)
        {
            if (InvokeRequired)
            {
			
                BeginInvoke(new IqCB(OnSearchResult), new object[] { sender, iq, data });
                return;
            }

            /*
             Example 9. Service Returns Search Results

            <iq type='result'
                from='characters.shakespeare.lit'
                to='juliet@capulet.com/balcony'
                id='search4'
                xml:lang='en'>
              <query xmlns='jabber:iq:search'>
                <x xmlns='jabber:x:data' type='result'>
                  <field type='hidden' var='FORM_TYPE'>
                    <value>jabber:iq:search</value>
                  </field>
                  <reported>
                    <field var='first' label='First Name'/>
                    <field var='last' label='Last Name'/>
                    <field var='jid' label='Jabber ID'/>
                    <field var='gender' label='Gender'/>
                  </reported>
                  <item>
                    <field var='first'><value>Benvolio</value></field>
                    <field var='last'><value>Montague</value></field>
                    <field var='jid'><value>benvolio@montague.net</value></field>
                    <field var='gender'><value>male</value></field>
                  </item>
                  <item>
                    <field var='first'><value>Romeo</value></field>
                    <field var='last'><value>Montague</value></field>
                    <field var='jid'><value>romeo@montague.net</value></field>
                    <field var='gender'><value>male</value></field>
                  </item>
                </x>
              </query>
            </iq>            
            */

            if (iq.Type == IqType.result)
            {
                if (iq.Query is Search)
                {
                    agsXMPP.protocol.x.data.Data xdata = ((Search)iq.Query).Data;
                    if (xdata != null)
                    {
                        ShowData(xdata);
                    }
                    else
                    {
                        ShowData(iq.Query as Search);
                    }
                }
            }
            else
            {
                ClearGridAndDataTable();
                toolStripStatusLabel1.Text = "an error occured in the search request";
            }
        }

        /// <summary>
        ///Limpio la grilla  Filas y columnas para nueva busqueda
        ///
        /// </summary>
        private void ClearGridAndDataTable()
        {
            dataGridView1.SuspendLayout();

            _dataTable.Rows.Clear();
            _dataTable.Columns.Clear();

            dataGridView1.Columns.Clear();

            dataGridView1.ResumeLayout();
        }

        /// <summary>
        /// Shows the search result in the UI
        /// </summary>
        /// <param name="xdata"></param>
        private void ShowData(agsXMPP.protocol.x.data.Data xdata)
        {
            lock (this)
            {
                //ClearGridAndDataTable();

                dataGridView1.SuspendLayout();

                _dataTable.Rows.Clear();
                _dataTable.Columns.Clear();
                dataGridView1.Columns.Clear();

                agsXMPP.protocol.x.data.Reported reported = xdata.Reported;

                #region GRID COLUMNS
                if (reported != null)
                {
                    foreach (agsXMPP.protocol.x.data.Field f in reported.GetFields())
                    {
                        // Create header
                        DataGridViewTextBoxColumn header = new DataGridViewTextBoxColumn();
                        header.DataPropertyName = f.Var;
                        header.HeaderText = f.Label;
                        header.Name = f.Var;

                        dataGridView1.Columns.Add(header);

                        // Create dataTable Col
                        _dataTable.Columns.Add(f.Var, typeof(string));
                    }
                }
                #endregion

                #region  GRID ROWS
                agsXMPP.protocol.x.data.Item[] items = xdata.GetItems();
                foreach (agsXMPP.protocol.x.data.Item item in items)
                {
                    DataRow dataRow = _dataTable.Rows.Add();
                    foreach (agsXMPP.protocol.x.data.Field field in item.GetFields())
                    {
                        dataRow[field.Var] = field.GetValue();
                    }
                }
                #endregion

                if (_dataTable.Rows.Count == 0)
                    toolStripStatusLabel1.Text = "no items found";
                else
                    toolStripStatusLabel1.Text = String.Format("{0} items found", _dataTable.Rows.Count.ToString());

                dataGridView1.ResumeLayout();
            }
        }

        private void AddColumnHeader(string name, string label)
        {
            // Create header
            DataGridViewTextBoxColumn header = new DataGridViewTextBoxColumn();
            header.DataPropertyName = name;
            header.HeaderText = label;
            header.Name = name;

            dataGridView1.Columns.Add(header);
            _dataTable.Columns.Add(name, typeof(string));
        }

        private void ShowData(Search search)
        {
            lock (this)
            {
                //ClearGridAndDataTable();

                dataGridView1.SuspendLayout();

                _dataTable.Rows.Clear();
                _dataTable.Columns.Clear();
                dataGridView1.Columns.Clear();


                // Create headers                
                AddColumnHeader("jid", "Jid");
                AddColumnHeader("last", "Lastname");
                AddColumnHeader("first", "Firstname");
                AddColumnHeader("nick", "Nickname");
                AddColumnHeader("email", "Email");

                SearchItem[] items = search.GetItems();
                foreach (SearchItem item in items)
                {
                    DataRow dataRow = _dataTable.Rows.Add();

                    if (item.Jid != null)
                        dataRow["jid"] = item.Jid;

                    if (item.Lastname != null)
                        dataRow["last"] = item.Lastname;

                    if (item.Firstname != null)
                        dataRow["first"] = item.Firstname;

                    if (item.Nickname != null)
                        dataRow["nick"] = item.Nickname;

                    if (item.Email != null)
                        dataRow["email"] = item.Email;
                }

                if (_dataTable.Rows.Count == 0)
                    toolStripStatusLabel1.Text = "no items found";
                else
                    toolStripStatusLabel1.Text = String.Format("{0} items found", _dataTable.Rows.Count.ToString());

                dataGridView1.ResumeLayout();
            }
        }

        #endregion

        private void cboServices_SelectedValueChanged(object sender, EventArgs e)
        {
            RequestSearchFields();
        }

       
      

    }
}
