using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Transactions;
using System.Data.Common;
using Health.Entities;
using Health.Back.BE;
using Health.BE;
using Health.BE.Enums;

namespace Health.Back
{
    public class SchedulingDAC
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pResourceSchedulingList"></param>
        /// <param name="userId"></param>
        public static void Create(ResourceSchedulingList pResourceSchedulingList,Guid userId)
        {
            ResourceScheduling r = null;
            DateTime creationDate = System.DateTime.Now;
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                foreach (ResourceSchedulingBE rbe in pResourceSchedulingList)
                {
                    r = new ResourceScheduling();

                    r.CreationDate = creationDate;
                    r.CreationUserId = userId;
                    r.DateEnd = rbe.DateEnd;
                    r.DateStart = rbe.DateStart;
                    r.Description = rbe.Description;
                    r.Duration = rbe.Duration;
                    r.TimeEnd = rbe.TimeEnd;
                    r.TimeStart = rbe.TimeStart;
                    r.ResourceId = rbe.ResourceId;
                    r.WeekDays = rbe.WeekDays;
                    r.HealthInstitutionId = rbe.HealthInstitutionId;
                    dc.ResourceSchedulings.AddObject(r);
                }
                dc.SaveChanges();

            }
        }
        public static void Update(ResourceSchedulingList resourceSchedulingList, Guid userId)
        {
            ResourceScheduling r_db = null;
            DateTime updateDate = System.DateTime.Now;
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                foreach (ResourceSchedulingBE rbe in resourceSchedulingList)
                {

                    r_db = dc.ResourceSchedulings.Where(p => p.IdSheduler.Equals(rbe.IdSheduler)).FirstOrDefault<ResourceScheduling>();

                    r_db.UpdatedDate = updateDate;
                    r_db.UpdateUserId = userId;

                    r_db.DateEnd = rbe.DateEnd;
                    r_db.DateStart = rbe.DateStart;
                    r_db.Description = rbe.Description;
                    r_db.Duration = rbe.Duration;
                    r_db.TimeEnd = rbe.TimeEnd;
                    r_db.TimeStart = rbe.TimeStart;
                    
                    r_db.WeekDays = rbe.WeekDays;
                    
                }
                dc.SaveChanges();

            }
        }

        /// <summary>
        /// Retorna la programacion de turnos de un determinado recurso para una institucion determinada 
        /// </summary>
        /// <param name="resourceId">Recurso</param>
        /// <param name="healthInstId">Opcional</param>
        /// <returns></returns>
        public static ResourceSchedulingList RetriveBy_ResourceId(int resourceId,Guid? healthInstId)
        {
            ResourceSchedulingList list = new ResourceSchedulingList ();

            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                var resourceScheduling_db = dc.ResourceSchedulings.Where<ResourceScheduling>(p => p.ResourceId.Value.Equals(resourceId) 
                                        && (!healthInstId.HasValue || p.HealthInstitutionId.Value.Equals(healthInstId.Value)));

                foreach (ResourceScheduling r in resourceScheduling_db)
                {
                    ResourceSchedulingBE wResourceScheduling = (ResourceSchedulingBE)r;
                    list.Add(wResourceScheduling);
                }
            }
            return list;
        }

        /// <summary>
        /// Retorna wAppointmentBE por appointmentId
        /// </summary>
        /// <param name="appointmentId">appointmentId</param>
        /// <returns></returns>
        public static AppointmentBE Get_Appointment_By_Id(int appointmentId)
        {
            AppointmentBE wAppointmentBE = null;

            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                Appointment appointment_db = dc.Appointments.Where<Appointment>(p => p.AppointmentId.Equals(appointmentId)).FirstOrDefault<Appointment>();
                if (appointment_db != null)
                    wAppointmentBE = new AppointmentBE(appointment_db);

            }
            return wAppointmentBE;
        }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="resourceId"></param>
      /// <param name="startDate"></param>
      /// <param name="Status"></param>
      /// <param name="healthInstId">Opcional </param>
      /// <returns></returns>
        public static AppointmentList Retrive_Appointment_By_Params_1(int resourceId, DateTime? startDate, int? Status, Guid? healthInstId)
        {
            AppointmentList list = new AppointmentList();
            //TODO Implmetar startDate
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                var appointment_db = dc.Appointments.Where<Appointment>(p => p.ResourceId.Value.Equals(resourceId) && p.Start >= startDate && 
                    (!healthInstId.HasValue || p.HealthInstitutionId.Equals(healthInstId.Value))
                    ); 

                foreach (Appointment r in appointment_db)
                {
                    AppointmentBE wResourceScheduling = (AppointmentBE)r;
                    list.Add(wResourceScheduling);
                }
            }
            return list;
        }

        /// <summary>
        /// Busca turnos de una fecha detrerminada y recurso determinado.
        /// Opcional: Status
        /// </summary>
        /// <param name="resourceId"></param>
        /// <param name="date"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public static AppointmentList Retrive_Appointment_By_Params_2(int resourceId, DateTime date, int? Status,  Guid? healthInstitutionId)
        {
            AppointmentList list = new AppointmentList();
            DateTime dEnd = Fwk.HelperFunctions.DateFunctions.GetEndDateTime(date);
            DateTime dStart = Fwk.HelperFunctions.DateFunctions.GetStartDateTime(date);
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                // dStaqrt <= FECHA_BD <= dEnd
                var appointment_db = dc.Appointments.Where<Appointment>(p =>
                    p.ResourceId.Value.Equals(resourceId) && (dStart <= p.Start && p.Start <= dEnd) &&
                    (healthInstitutionId.HasValue == false || p.HealthInstitutionId.Value.Equals(healthInstitutionId.Value)));

                //var x = from p in dc.Appointments from pa in dc.ProfesionalAppointments
                foreach (Appointment r in appointment_db)
                {
                    AppointmentBE wAppointmentBE = (AppointmentBE)r;
                    wAppointmentBE.ProfesionalAppointment = (ProfesionalAppointmentBE) r.ProfesionalAppointment;
                    list.Add(wAppointmentBE);
                }
            }
            return list;
        }
        /// <summary>
        /// Por el momento representa Turnos otorgados a un profesional
        /// </summary>
        /// <param name="startDate">Fecha desde</param>
        /// <param name="status">Estado que del appointment se desea cunsultar</param>
        /// <param name="resourceId">Id a quien pertenezca el appointment</param>
        /// <returns>AppointmentList, Appointment con ProfesionalAppointment</returns>
        public static AppointmentList Retrive_ProfessionalAppointment(DateTime? startDate, int? status, int? resourseId = null, Guid? healthInstitutionId=null)
        {
            AppointmentList list = new AppointmentList();
            if (startDate.HasValue)
                startDate = Fwk.HelperFunctions.DateFunctions.GetStartDateTime(startDate.Value);

            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                var appointment_db = dc.Appointments.Where<Appointment>(p =>
                    (!startDate.HasValue || p.Start.Value >= startDate.Value)
                    && (!status.HasValue || status.Value.Equals(p.Status.Value))
                    && (!resourseId.HasValue || p.ResourceId.Value.Equals(resourseId.Value))
                    && (!healthInstitutionId.HasValue || p.HealthInstitutionId.Value.Equals(healthInstitutionId.Value))
                    );//.OrderByDescending(sort=>sort.CreationDate);

                foreach (Appointment r in appointment_db)
                {
                    AppointmentBE wAppoiment = (AppointmentBE)r;
                    wAppoiment.ProfesionalAppointment = (ProfesionalAppointmentBE)r.ProfesionalAppointment;
                    list.Add(wAppoiment);
                }
            }
            return list;
        }


        public static void Create_Appointments(AppointmentList appointmentList, Guid userId)
        {
            Appointment a = null;
            DateTime creationDate = System.DateTime.Now;

            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {

                foreach (AppointmentBE abe in appointmentList)
                {
                    a = new Appointment();
                    a.ProfesionalAppointment = new ProfesionalAppointment();
                    a.CreationDate = creationDate;
                    
                    a.CreationUserId = userId;
                    a.Description = abe.Description;
                    a.Duration = abe.Duration;
                    a.Start = abe.Start;
                    a.End = abe.End;
                    
                    a.ResourceId = abe.ResourceId;
                    a.HealthInstitutionId = abe.HealthInstitutionId;
                    a.ProfesionalAppointment.PatientId = abe.ProfesionalAppointment.PatientId;
                    a.ProfesionalAppointment.PatientName = abe.ProfesionalAppointment.PatientName;
                    a.ProfesionalAppointment.IdMotivoConsulta = abe.ProfesionalAppointment.IdMotivoConsulta;
                    a.ProfesionalAppointment.RoomId = abe.ProfesionalAppointment.RoomId;
                    a.Location = abe.Location;
                    a.Status = abe.Status;
                    a.Label = abe.Label;
                    a.Subject = abe.Subject;


                    a.WeekDays = abe.WeekDays;
                    a.WeekOfMonth = abe.WeekOfMonth;
                    a.IsExceptional = abe.IsExceptional;
                    dc.Appointments.AddObject(a);
                }
                dc.SaveChanges();
            }
          
        }


        /// <summary>
        /// Actualiza un AppointmentList. El userId Viene de la context info del requets del servicio
        /// La UpdatedDate se crea en este método
        /// </summary>
        /// <param name="appointmentList">Lista de appointments</param>
        /// <param name="userId">El userId Viene de la context info del requets del servicio</param>
        public static void Update_Appointments(AppointmentList appointmentList, Guid userId)
        {
            DateTime updatedDate = System.DateTime.Now;

            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {

                foreach (AppointmentBE abe in appointmentList)
                {
                    var appointment_db = dc.Appointments.Where<Appointment>(p => p.AppointmentId.Equals(abe.AppointmentId)).FirstOrDefault(); 
                    
                    appointment_db.UpdatedDate = updatedDate;
                    appointment_db.UpdateUserId = userId;
                    appointment_db.Description = abe.Description;
                    appointment_db.Location = abe.Location;
                    appointment_db.Status = abe.Status;
                    appointment_db.Label = abe.Label;
                    appointment_db.Subject = abe.Subject;
                }
                dc.SaveChanges();
            }
        }

        public static void Update_Appointment_Status(int AppointmentId,AppoimantsStatus_SP status, Guid userId)
        {
         
            DateTime updateDate = System.DateTime.Now;

            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {


                var appointment_db = dc.Appointments.Where<Appointment>(p => p.AppointmentId.Equals(AppointmentId)).FirstOrDefault();

                    appointment_db.UpdatedDate = updateDate;
                    appointment_db.UpdateUserId = userId;
                    appointment_db.Status = (int)status;
                
                dc.SaveChanges();
            }
        }

        public static void RemoveAppointment(int appointmentId)
        {
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {


                var appointment_db = dc.Appointments.Where<Appointment>(p => p.AppointmentId.Equals(appointmentId)).FirstOrDefault();
                dc.Appointments.DeleteObject(appointment_db);
                dc.SaveChanges();
            }
        }
    }
}

