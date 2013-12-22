using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Health.Back.BE;
using Health.Entities;
using Health.BE;



namespace Health.Back
{
    public class CEI10DAC
    {
        public static CEI_10List Retrive_All_ChildsOnly()
        {
            CEI_10List list = new CEI_10List();
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                CEI_10BE c;
                foreach (CEI_10 item in dc.CEI_10.Where(p => p.HasChilds.Equals(false)))
                {
                    //list.Add((CEI_10BE)c);
                    c = new CEI_10BE();
                    c.Code = item.Code;
                    c.Description = item.Description;
                    list.Add(c);
                }
            }
            return list;
        }

        public static CEI_10List Retrive_All()
        {
            CEI_10List list = new CEI_10List();
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                foreach (CEI_10BE c in dc.CEI_10)
                {
                   list.Add((CEI_10BE)c);

                }
            }
            return list;
        }
        public static List<Health.Entities.cei10_view> Retrive_View_All()
        {
            List<Health.Entities.cei10_view> list = new List<Health.Entities.cei10_view>();
            using (Health.Entities.HealthLinQDataContext dc = new Health.Entities.HealthLinQDataContext(Common.CnnString))
            {
                foreach (cei10_view c in dc.cei10_views)
                {
                    list.Add((cei10_view)c);

                }
            }
            return list;
        }
        static void Insert(CEI_10List list)
        {

            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                CEI_10 wCEI_10;
                try
                {
                    foreach (CEI_10BE c in list)
                    {
                        //falla i10
                        wCEI_10 = new CEI_10();
                        wCEI_10.ParentCode = c.ParentCode.Trim();
                        wCEI_10.Code = c.Code.Trim();
                        wCEI_10.Description = c.Description;
                        wCEI_10.HasChilds = c.HasChilds;

                        dc.CEI_10.AddObject(wCEI_10);
                        dc.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

     public    static void TrimAll()
        {

            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
               
                try
                {
                    foreach (CEI_10 c in dc.CEI_10)
                    {
                        c.ParentCode = c.ParentCode.Trim();
                        c.Code = c.Code.Trim();
                    }
                    dc.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }
         static List<CEI10_Temp> Retrive_Temporal_All()
        {
         
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
         
                return dc.CEI10_Temp.ToList<CEI10_Temp>();
            }
         
        }

        public static void ProcessCEI10()
        {
            CEI_10List generatedList = new CEI_10List();
            CEI_10BE generatedBE = null;
            var tempList = Retrive_Temporal_All();

            string auxiliar = string.Empty;
            foreach (CEI10_Temp cei10_temp in tempList.OrderBy(p=>p.Id))
            {
                generatedBE = new CEI_10BE();
                generatedBE.Description = cei10_temp.Description;
                generatedBE.Code = cei10_temp.Code.Trim();
                if (!string.IsNullOrEmpty(cei10_temp.ParentCode.Trim()))
                {
                    auxiliar = cei10_temp.Code.Trim();
                    generatedBE.ParentCode = cei10_temp.ParentCode.Trim();
                    generatedBE.HasChilds = true;
                }
                else
                {
                    generatedBE.ParentCode = auxiliar;
                }
                generatedList.Add(generatedBE);
            }

            foreach (CEI_10BE item in generatedList)
            {
                item.HasChilds = generatedList.Any(p => p.ParentCode.Equals(item.Code));
            }
            Insert(generatedList);
        }
    }


    
}
