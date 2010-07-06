using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGauges.Core.Model;
using Allus.Cnn.Common;
using Allus.Cnn.Common.BE;

namespace Allus.Cnn.Common
{
    public partial class MarqueeEditor : MessageCreatorBase
    {
        private MarqueeBE mMarqueeBE;
        
        public MarqueeEditor()
        {
            InitializeComponent();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            marquee1.Restart();
            marquee1.Start();
        }

        // Texto a mostrar
        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            marquee1.TextToShow = txtTexto.Text;
            //mMarqueeBE.TextToShow = txtTexto.Text;
        }

        // Direccion del texto
        private void rdgDireccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            marquee1.TextDirection = (Direction)Enum.ToObject(typeof(Direction), rdgDireccion.SelectedIndex);
            //mMarqueeBE.Direction = (Direction)Enum.ToObject(typeof(Direction), rdgDireccion.SelectedIndex);
        }

        // Posicion de la marquesina
        private void rdgPosición_SelectedIndexChanged(object sender, EventArgs e)
        {
            marquee1.Position = (Position)Enum.ToObject(typeof(Position), rdgPosición.SelectedIndex);
            //mMarqueeBE.Position = (Position)Enum.ToObject(typeof(Position), rdgPosición.SelectedIndex);
        }

        // color del texto
        private void colorEdit1_EditValueChanged(object sender, EventArgs e)
        {
            marquee1.TextColor = edtColor.Color;
            //mMarqueeBE.Color = edtColor.Color;
        }

        // Velocidad del texto
        private void trkSpeed_EditValueChanged(object sender, EventArgs e)
        {            
            marquee1.Speed = trkSpeed.Value;
            //mMarqueeBE.Speed = trkSpeed.Value;
            marquee1.Start();
        }

        // Cantidad de digitos a mostrar en la marquee
        private void numDigitos_ValueChanged(object sender, EventArgs e)
        {   // siempre son enteros
            marquee1.DigitCount = Convert.ToInt32(numDigitos.Value);
            //mMarqueeBE.DigitCount = Convert.ToInt32(numDigitos.Value);
        }

        // Tiempo especificado para mostrar la marquee
        private void numTimeToShow_ValueChanged(object sender, EventArgs e)
        {
            // duracion generada en segundos que permanecera activa la marquee
            // la marquee utiliza milisegundos por eso se multiplica por 1000 = 1 seg
            marquee1.TimeToShow = Convert.ToInt32(numTimeToShow.Value) * 1000;
            //mMarqueeBE.TimeToShow = Convert.ToInt32(numTimeToShow.Value) * 1000;
        }

        // Estilo de la marquee
        private void cmbEstilo_SelectedIndexChanged(object sender, EventArgs e)
        {
            marquee1.Shape = (DigitalBackgroundShapeSetType)cmbEstilo.SelectedItem;
            //mMarqueeBE.Shape = Enum.GetName(typeof(DigitalBackgroundShapeSetType), cmbEstilo.SelectedItem);
        }

        // Texto que se muestra en lugar del link
        private void txtTextoLink_TextChanged(object sender, EventArgs e)
        {
            marquee1.LinkText = txtTextoLink.Text;
        }

        // Link
        private void txtLink_TextChanged(object sender, EventArgs e)
        {
            marquee1.Link = txtLink.Text;            
        }

        //Color del texto que se muestra en lugar del link
        private void edtColorLink_EditValueChanged(object sender, EventArgs e)
        {
            marquee1.LinkColor = edtColorLink.Color;
        }

        private void MarqueeEditor_Load(object sender, EventArgs e)
        {
            cmbEstilo.Properties.Items.AddRange(Enum.GetValues(typeof(DigitalBackgroundShapeSetType)));
            cmbEstilo.SelectedIndex = 7;


            marquee1.Shape = (DigitalBackgroundShapeSetType)cmbEstilo.SelectedItem;
            marquee1.TimeToShow = Convert.ToInt32(numTimeToShow.Value) * 1000;
            marquee1.DigitCount = Convert.ToInt32(numDigitos.Value);
            marquee1.Speed = trkSpeed.Value;
            marquee1.TextColor = edtColor.Color;
            marquee1.Position = (Position)Enum.ToObject(typeof(Position), rdgPosición.SelectedIndex);
            marquee1.TextDirection = (Direction)Enum.ToObject(typeof(Direction), rdgDireccion.SelectedIndex);
            marquee1.TextToShow = txtTexto.Text;
            marquee1.LinkText = txtTextoLink.Text;
            marquee1.LinkColor = edtColorLink.Color;
            marquee1.Link = txtLink.Text;
            
        }

        internal override void FillMessage(AlertMessage pMessage)
        {
            pMessage.Title = txtTitle.Text;
            //pMessage.Url = txtUrl.Text;
            pMessage.RequireConfirm = false;
            pMessage.MessageType = MessageType.Marquee;
            pMessage.Tag.Text = GetMarqueeBE().GetXml();
            pMessage.Text = txtTexto.Text;
            pMessage.Url = txtLink.Text;
        }

        /// <summary>
        /// Retorna true si ningun control contiene datos.- 
        /// Sirve par adeterminar si el user control se encuentra en estado No Modificado o
        /// sin intencion del usuario de haber ingresado datos.-
        /// </summary>
        /// <returns></returns>
        internal override bool IsEmpty()
        {
            return string.IsNullOrEmpty(txtTexto.Text);
        }


        /// <summary>
        /// Obtiene las propiedades de seteo de la marquee
        /// </summary>
        private MarqueeBE GetMarqueeBE()
        {
            
            mMarqueeBE = new MarqueeBE();
            mMarqueeBE.Shape = Enum.GetName(typeof(DigitalBackgroundShapeSetType), cmbEstilo.SelectedItem);
            mMarqueeBE.TimeToShow = Convert.ToInt32(numTimeToShow.Value) * 1000;
            mMarqueeBE.DigitCount = Convert.ToInt32(numDigitos.Value);
            mMarqueeBE.Speed = trkSpeed.Value;
            mMarqueeBE.Color = edtColor.Color.ToArgb();
            mMarqueeBE.Position = (Position)Enum.ToObject(typeof(Position), rdgPosición.SelectedIndex);
            mMarqueeBE.Direction = (Direction)Enum.ToObject(typeof(Direction), rdgDireccion.SelectedIndex);
            mMarqueeBE.TextToShow = txtTexto.Text;
            mMarqueeBE.TextLink = txtTextoLink.Text;
            mMarqueeBE.TextoLinkColor = edtColorLink.Color.ToArgb();


            return mMarqueeBE;
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void marquee1_Load(object sender, EventArgs e)
        {

        }

       

    }
}
