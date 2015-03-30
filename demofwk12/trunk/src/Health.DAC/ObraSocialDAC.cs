using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Health.Back.BE;
using Health.BE;

namespace Health.Back
{
    public class ObraSocialDAC
    {
        public static MutualList RetriveAll()
        {
            MutualList list = new MutualList();
            MutualBE wMutualBE               ;
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                foreach (Mutual m_db in dc.Mutuals)
                {
                    wMutualBE = (MutualBE)m_db;
                    list.Add( wMutualBE);
                }
            }
            return list;
        }


        public static void Create(MutualBE pMutualBE)
        {
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                Mutual wMutual = new Mutual();
                wMutual.Nombre = pMutualBE.Nombre;
                wMutual.ExigeCoseguro = pMutualBE.ExigeCoseguro;

                dc.Mutuals.AddObject(wMutual);
                dc.SaveChanges();
                wMutual.IdMutual = wMutual.IdMutual;
            }
        }

        public static void Create_MutualPorPaciente(MutualPorPacienteList pMutualesDelPatient, int pIdPatient)
        {
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {

                MutualPorPaciente wMutual =null;

                foreach (MutualPorPacienteBE wMutualBE in pMutualesDelPatient)
                {
                    wMutual = new MutualPorPaciente();
                    wMutual.IdPaciente = pIdPatient;
                    wMutual.IdMutual = wMutualBE.IdMutual;
                    wMutual.NroAfiliadoMutual = wMutualBE.NroAfiliadoMutual;

                    dc.MutualPorPacientes.AddObject(wMutual);
                 
                 
                }
                dc.SaveChanges();
            }
        }
        public static void Update_MutualPorPaciente(MutualPorPacienteList MutualPorPacienteList, int pPatientId)
        {
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {

                MutualPorPaciente wMutual = null;

                foreach (MutualPorPacienteBE wMutualBE in MutualPorPacienteList)
                {
                    if (wMutualBE.EntityState == Fwk.Bases.EntityState.Added)
                    {
                        wMutual = new MutualPorPaciente();
                        wMutual.IdPaciente = pPatientId;
                        wMutual.IdMutual = wMutualBE.IdMutual;
                        wMutual.NroAfiliadoMutual = wMutualBE.NroAfiliadoMutual;
                        wMutual.IsActive = true;
                        dc.MutualPorPacientes.AddObject(wMutual);
                    }

                    if (wMutualBE.EntityState == Fwk.Bases.EntityState.Changed)
                    {
                        wMutual = dc.MutualPorPacientes.Where(p => p.IdMutual.Equals(wMutualBE.IdMutual)).FirstOrDefault();
                        wMutual.NroAfiliadoMutual = wMutualBE.NroAfiliadoMutual;
                        wMutual.IsActive = wMutualBE.IsActive;
                    }
                }
                dc.SaveChanges();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pPatientId"></param>
        /// <returns></returns>
        public static MutualPorPacienteList RetriveByIdPatient(int pPatientId)
        {
            MutualPorPacienteList list = new MutualPorPacienteList();
            
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                var mutuales_xPatient_db = from m in dc.Mutuals
                                           from mp in dc.MutualPorPacientes
                                           where m.IdMutual.Equals(mp.IdMutual) && mp.IdPaciente.Equals(pPatientId)
                                           select 
                                  new  MutualPorPacienteBE{IdMutual=mp.IdMutual, NroAfiliadoMutual=mp.NroAfiliadoMutual, NombreMutual=m.Nombre,IsActive=mp.IsActive};

                list.AddRange(mutuales_xPatient_db.ToList<MutualPorPacienteBE>());
            }
            return list;
        }

        public static bool Existe(string pNombre)
        {
            
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                return dc.Mutuals.Any<Mutual>(p => p.Nombre.Equals(pNombre));
            }
            
        }

       
    }
}
