using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Health.Back;
using Health.Back.BE;
using Health.Entities;
using FileHelpers;
using System.IO;
using Health.BE;

namespace GenData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CEI10DAC.ProcessCEI10();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CEI_10List wCEI_10List = CEI10DAC.Retrive_All_ChildsOnly();
            CEI10ComboList list = new CEI10ComboList();
            
           foreach (CEI_10BE i in wCEI_10List)
           {
               list.Add(new CEI10Combo(i));
           }
           Fwk.HelperFunctions.FileFunctions.SaveTextFile("cei10_combo.xml", list.GetXml());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Health.Entities.cei10_view> wCEI_10List = CEI10DAC.Retrive_View_All();
            CEI10GridList list = new CEI10GridList();

            foreach (cei10_view i in wCEI_10List)
            {
                list.Add(new CEI10Grid(i));
            }
            Fwk.HelperFunctions.FileFunctions.SaveTextFile("cei.xml", list.GetXml());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //NomenclatorDAC.Process_PMO_AnalisisClinicos();
            //NomenclatorDAC.Process_PMO_Quirurgicas();
            //NomenclatorDAC.Process_PMO_Odont();

            FileHelperEngine engine = new FileHelperEngine(typeof(PMO));
            PMO[] res = engine.ReadFile("PMO_Espespecializado.txt") as PMO[];
            List<Nomenclator> wNomenclatorList = new List<Nomenclator>();

            foreach (PMO p in res)
            {
                wNomenclatorList.Add(new Nomenclator { Code = p.Code.Trim(), Description = p.Description });
            }

            NomenclatorDAC.Process_PMO(wNomenclatorList, (int)PMOEnum.Espesializadas);
        }   
            
        

        private void button5_Click(object sender, EventArgs e)
        {
//            850	Quirurgicas                                       
//851	Odontológicas                                     
//852	Espesializadas                                    
//853	Análisis Clkinicos                                
            save(PMOEnum.Espesializadas, "pmo_esp.xml");
            save(PMOEnum.Odontológicas, "pmo_odont.xml");
            save(PMOEnum.Quirurgicas, "pmo_quir.xml");
            save(PMOEnum.Analisis_Clinico, "pmo_analisis.xml");
        }

        void save(PMOEnum? type, string filename)
        {
            PMOFile f;
            PMOFileList file = new PMOFileList();
            List<Nomenclator> list = null;
            //Espesializadas
            if (type != null)
                list = NomenclatorDAC.RetriveByType((int)type);
            else
                list = NomenclatorDAC.RetriveAll();

            //list.ForEach(p => file.Add(new PMOFile { Code = p.Code.Trim(), Description = p.Description, ParentCode = p.ParentCode.Trim(),HasChild=p.HasChilds }));
            foreach (Nomenclator db in list)
            {
                f = new PMOFile();
                f.Code = db.Code.Trim();
                f.Description = db.Description;
                f.HasChild = db.HasChilds;
                f.Id = db.Id;
                f.Type = db.PMOType;
                if (!string.IsNullOrEmpty(db.ParentCode))
                    f.ParentCode = db.ParentCode.Trim();
                file.Add(f);
            }
            Fwk.HelperFunctions.FileFunctions.SaveTextFile(filename, file.GetXml());

        }

        private void button6_Click(object sender, EventArgs e)
        {
            FileHelperEngine engine = new FileHelperEngine(typeof(PMO));
            PMO[] res = engine.ReadFile("PMO_Quirurgico.txt") as PMO[];
            List<Nomenclator> wNomenclatorList = new List<Nomenclator>();
           // int i = 0;
            foreach (PMO p in res)
            {
                wNomenclatorList.Add(new Nomenclator {  Code = p.Code.Trim(), Description = p.Description });
                //i++;
            }
            NomenclatorDAC.Process_PMO(wNomenclatorList,(int) PMOEnum.Quirurgicas);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            NomenclatorDAC.Process_PMO_AnalisisClinicos();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            save(null, "pmo.xml");
        }

       
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            DirectoryInfo d = new System.IO.DirectoryInfo(@"d:\BackUp\ma\");
            //foreach (FileInfo f in d)
            //{
            //    FileInfo = new FileInfo(""); 
            //}

        }

        private void btn_ProccessOdontot_Click(object sender, EventArgs e)
        {
            NomenclatorDAC.Process_PMO_Odont();
        }



    }

    [DelimitedRecord("|")]
    public class PMO
    {
        public string Code;
        public string Description;
    }
   
}
