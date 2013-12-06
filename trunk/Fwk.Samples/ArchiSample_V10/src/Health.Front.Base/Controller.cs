using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Health.Entities;
using Health.Isvc.SearchParametroByParams;
using Health.Isvc.DeleteParametro;
using Health.Isvc.CreateParametro;
using Health.Back.BE;
using Health.Isvc.RetrivePersonas;
using Health.Isvc.CrearProfesional;
using Health.Isvc.CrearPatient;
using Health.Isvc.RetrivePatients;
using Health.Isvc.GetPlanVacunacion;
using Health.Isvc.UpdatePatient;
using Health.Isvc.UpdatePlanVacunacion;
using Health.Isvc.RetriveProfesionales;
using Health.Isvc.GetProfesional;
using Health.Isvc.CreateResourceScheduling;
using Health.Isvc.CreateAppointments;
using Health.Isvc.UpdateResourceScheduling;
using Health.Isvc.RetriveResourceSchedulingAndAppoinments;
using Health.Isvc.UpdateAppointments;
using Health.Isvc.RetriveAppointment;
using Health.Isvc.RetriveAllObraSocial;
using Health.Isvc.CreateObraSocial;
using Health.Isvc.GetPatient;
using Health.Isvc.UpdateProfesional;
using Health.Isvc.AsociarPatientAPersona;
using Health.Isvc.GetObraSocialPorPatient;
using Health.Isvc.GetPatientAllergy;
using Health.Isvc.CreateUpdatePatientAllergy;
using Health.Isvc.RetrivePatientMedicaments;
using Health.Isvc.CreateUpdatePatientMedicament;
using Health.Isvc.CreatePatientEvent;
using Health.Isvc.UpdatePatientEvent;
using Fwk.UI.Controller;
using System.Runtime.Remoting.Messaging;
using System.Diagnostics;
using Health.Isvc.RetrivePatientEvent;
using Health.Isvc.GetPatientEvent;
using Health.Isvc.RetrivePatientAppoiments;
using Health.Isvc.GetAppoinmentByParams;
using Health.Isvc.UpdateAppointmentStatus;
using Health.BE;
using Health.Isvc.ValidateActivationCode;
using Health.Isvc.RetriveHealthInstitution;
using Health.Isvc.AuthHealthInstitution;
using Health.Isvc.GetHealthInstitutionById;
using Health.BE.Enums;
using Health.Isvc.RemoveAppointment;
using Health.Isvc.RetriveMedicalEventPMO_Diag;

using Health.Isvc.RetriveMedicalEventAlerts;
using Health.Isvc.RetriveMedicalEventDetails;

namespace Health.Front
{
    public delegate void DelegateWithOutAndRefParameters(out Exception ex);
    public class Controller
    {
        public static HealthInstitution_ProfesionalBE CurrentHealthInstitution_Profesional { get; set; }
        public static HealthInstitutionBE CurrentHealthInstitution { get; set; }
        static Health.BE.CEI10GridList _CEI_10List;
        public static PMOFileList PMOFileList { get { return Controller._PMOFileList; } }

        static Health.BE.PMOFileList  _PMOFileList;

        static Health.BE.CEI10ComboList _CEI_10ComboList;

        public static CEI10GridList CEI_10List { get { return Controller._CEI_10List; } }
        public static CEI10ComboList CEI_10ComboList { get { return Controller._CEI_10ComboList; } }
        public static ProfesionalBE CurrentProfesional { get; set; }
        public static PatientBE CurrentPatient { get; set; }

        static ParametroList _TipoEventoMedicoList;

        public static ParametroList TipoEventoMedicoList
        {
            get { return Controller._TipoEventoMedicoList; }
            set { Controller._TipoEventoMedicoList = value; }
        }
        static ParametroList _EstadoCivilList;
        static ParametroList _EspecialidadMedicaList;
        static ParametroList _ProfecionesList;
        static ParametroList _AllergiesItemTypesList;
        public static ParametroList AllergiesItemTypesList
        {
            get { return Controller._AllergiesItemTypesList; }
            set { Controller._AllergiesItemTypesList = value; }
        }
        public static ParametroList EspecialidadMedicaList
        {
            get { return Controller._EspecialidadMedicaList; }
            set { Controller._EspecialidadMedicaList = value; }
        }
        public static ParametroList ProfecionesList
        {
            get { return Controller._ProfecionesList; }
            set { Controller._ProfecionesList = value; }
        }
        public static ParametroList EstadoCivilList
        {
            get { return _EstadoCivilList; }
            set { _EstadoCivilList = value; }
        }

        public static event EventHandler OnControlerException;
  
        static Controller()
        {


            //_ProfecionesList = SearchParametroByParams((int)TipoParametroEnum.Profecion, null);
            //_EstadoCivilList = SearchParametroByParams((int)TipoParametroEnum.EstadoCivil, null);
            ////_EstadoCivilList.Add(new ParametroBE { Nombre = Enum.GetName(typeof(CommonValuesEnum), CommonValuesEnum.SeleccioneUnaOpcion), IdParametro = (int)CommonValuesEnum.SeleccioneUnaOpcion });

            //_EspecialidadMedicaList = SearchParametroByParams((int)TipoParametroEnum.Especialidad, null);
            ////_EspecialidadMedicaList.Add(new ParametroBE { Nombre = Enum.GetName(typeof(CommonValuesEnum), CommonValuesEnum.SeleccioneUnaOpcion), IdParametro = (int)CommonValuesEnum.SeleccioneUnaOpcion });
            //_EspecialidadMedicaList.Add(new ParametroBE { Nombre = Enum.GetName(typeof(CommonValuesEnum), CommonValuesEnum.Ninguno), IdParametro = (int)CommonValuesEnum.Ninguno });

            ////_EstadoCivilList.Add(new ParametroBE { Nombre = "Todos", IdParametro = (int)CommonValuesEnum.TodosComboBoxValue });
            //_MotivoConsultaList = SearchParametroByParams((int)TipoParametroEnum.MotivoConsulta, null);


        }
        #region PopulateSync

        /// <summary>
        /// Carga de manera asincrona los Dominios relacionados entre si en la grilla.-
        /// </summary>
        public static void PopulateAsync()
        {
            Exception ex = null;
            DelegateWithOutAndRefParameters s = new DelegateWithOutAndRefParameters(Populate);

            s.BeginInvoke(out ex, new AsyncCallback(EndPopulate), null);
        }

        /// <summary>
        /// Fin de el metodo populate que fue llamado de forma asincrona
        /// </summary>
        /// <param name="res"></param>
        static void EndPopulate(IAsyncResult res)
        {
            Exception ex;
            AsyncResult result = (AsyncResult)res;

            DelegateWithOutAndRefParameters del = (DelegateWithOutAndRefParameters)result.AsyncDelegate;
            del.EndInvoke(out ex, res);
            if (ex != null)
            {
                if(OnControlerException!=null)
                    OnControlerException(ex,new EventArgs());
                return;
            }
            if (ex == null)
            {
                _EspecialidadMedicaList.Add(new ParametroBE { Nombre = Enum.GetName(typeof(CommonValuesEnum), CommonValuesEnum.Ninguno), IdParametro = (int)CommonValuesEnum.Ninguno });
            }
        }

        /// <summary>
        /// Carga Dominios relacionados entre al objeto _RelatedDomains que esta bindiado a la grilla
        /// </summary>
        static void Populate(out Exception ex)
        {
            ex = null;

            try
            {
                _ProfecionesList = SearchParametroByParams((int)TipoParametroEnum.Profecion, null);
                _EstadoCivilList = SearchParametroByParams((int)TipoParametroEnum.EstadoCivil, null);
                _EspecialidadMedicaList = SearchParametroByParams((int)TipoParametroEnum.Especialidad, null);
                _EspecialidadMedicaList.Add(new ParametroBE { Nombre = Enum.GetName(typeof(CommonValuesEnum), CommonValuesEnum.Ninguno), IdParametro = (int)CommonValuesEnum.Ninguno });
                _TipoEventoMedicoList = SearchParametroByParams((int)TipoParametroEnum.TipoEventoMedico, null);
                _AllergiesItemTypesList = Controller.SearchParametroByParams((int)TipoParametroEnum.AllergiesItemTypes, null);
                
                _CEI_10List = (CEI10GridList)Fwk.HelperFunctions.SerializationFunctions.DeserializeFromXml(typeof(CEI10GridList), Fwk.HelperFunctions.FileFunctions.OpenTextFile(@"dat\cei.xml"));
                _CEI_10ComboList = (CEI10ComboList)Fwk.HelperFunctions.SerializationFunctions.DeserializeFromXml(typeof(CEI10ComboList), Fwk.HelperFunctions.FileFunctions.OpenTextFile(@"dat\cei10_combo.xml"));
                _PMOFileList = (PMOFileList)Fwk.HelperFunctions.SerializationFunctions.DeserializeFromXml(typeof(PMOFileList), Fwk.HelperFunctions.FileFunctions.OpenTextFile(@"dat\pmo.xml"));

            }
            catch (Exception err)
            {
                //err.Source = "Origen de datos";
                ex = err;
            }
        }

        #endregion

        public static ParametroList SearchParametroByParams(int? pIdTipo, int? pIdParametroRef)
        {
            SearchParametroByParamsReq req = new SearchParametroByParamsReq();
            req.BusinessData.IdTipoParametro = pIdTipo;
            req.BusinessData.IdParametroRef = pIdParametroRef;
            req.BusinessData.Vigente = true;

#if (DEBUG ==false)
                req.ContextInformation.UserId = frmBase_TabForm.IndentityUserInfo.ProviderId.ToString();
            if (Controller.CurrentHealthInstitution != null)
            req.ContextInformation.AppId = Controller.CurrentHealthInstitution.HealthInstitutionId.ToString();
#endif


            SearchParametroByParamsRes res = req.ExecuteService<SearchParametroByParamsReq, SearchParametroByParamsRes>(req);

            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);
            return res.BusinessData;
        }
        public static void DeleteParametro(int pIdParametro, string name)
        {
            DeleteParametroReq req = new DeleteParametroReq();
            req.BusinessData.IdParametro = pIdParametro;
            req.BusinessData.Name = name;
            req.ContextInformation.UserId = frmBase_TabForm.IndentityUserInfo.ProviderId.ToString();
            if (Controller.CurrentHealthInstitution!=null)
                req.ContextInformation.AppId = Controller.CurrentHealthInstitution.HealthInstitutionId.ToString();

            DeleteParametroRes res = req.ExecuteService<DeleteParametroReq, DeleteParametroRes>(req);

            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);

        }
        public static void CreateParametro(ParametroBE pParametro)
        {
            CreateParametroReq req = new CreateParametroReq();
            req.BusinessData = pParametro;
            req.ContextInformation.UserId = frmBase_TabForm.IndentityUserInfo.ProviderId.ToString();
            if (Controller.CurrentHealthInstitution != null)
                req.ContextInformation.AppId = Controller.CurrentHealthInstitution.HealthInstitutionId.ToString();
            CreateParametroRes res = req.ExecuteService<CreateParametroReq, CreateParametroRes>(req);

            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);
        }


        #region
        /// <summary>
        /// Retorna todas las personas
        /// </summary>
        /// <returns></returns>
        public static PersonaList RetrivePersonas()
        {
            RetrivePersonasReq req = new RetrivePersonasReq();

            //req.BusinessData.Apellido = ;
            //req.BusinessData.Vigente = true;
            req.ContextInformation.UserId = frmBase_TabForm.IndentityUserInfo.ProviderId.ToString();
            //+req.ContextInformation.AppId = CurrentPelsoftUser.AppId;

            RetrivePersonasRes res = req.ExecuteService<RetrivePersonasReq, RetrivePersonasRes>(req);


            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);
            return res.BusinessData;
        }

        public static PatientList RetrivePatients(int? IdPersona)
        {
            RetrivePatientsReq req = new RetrivePatientsReq();

            //req.BusinessData.Apellido = ;

            req.BusinessData.Id = IdPersona;
            req.ContextInformation.UserId = frmBase_TabForm.IndentityUserInfo.ProviderId.ToString();
            if (Controller.CurrentHealthInstitution != null)
                req.ContextInformation.AppId = Controller.CurrentHealthInstitution.HealthInstitutionId.ToString();

            RetrivePatientsRes res = req.ExecuteService<RetrivePatientsReq, RetrivePatientsRes>(req);


            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);
            return res.BusinessData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pIdPatient"></param>
        /// <returns></returns>
        public static GetPatientRes GetPatient(int pIdPatient)
        {
            GetPatientReq req = new GetPatientReq();

            //req.BusinessData.Apellido = ;

            req.BusinessData.Id = pIdPatient;
            req.ContextInformation.UserId = frmBase_TabForm.IndentityUserInfo.ProviderId.ToString();
            req.ContextInformation.AppId = Controller.CurrentHealthInstitution.HealthInstitutionId.ToString();

            GetPatientRes res = req.ExecuteService<GetPatientReq, GetPatientRes>(req);


            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);
            return res;
        }

        public static MutualPorPacienteList GetPatient_Mutuals(int patientId)
        {
            GetObraSocialPorPatientReq req = new GetObraSocialPorPatientReq();

            //req.BusinessData.Apellido = ;

            req.BusinessData.PatientId = patientId;
            req.ContextInformation.UserId = frmBase_TabForm.IndentityUserInfo.ProviderId.ToString();
            req.ContextInformation.AppId = Controller.CurrentHealthInstitution.HealthInstitutionId.ToString();

            GetObraSocialPorPatientRes res = req.ExecuteService<GetObraSocialPorPatientReq, GetObraSocialPorPatientRes>(req);


            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);
            return res.BusinessData;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int CrearPatient(PatientBE Patient, MutualPorPacienteList mutualList)
        {
            CrearPatientReq req = new CrearPatientReq();

            req.BusinessData.Patient = Patient;
            //MutualPorPacienteList wMutualPorPacienteList = new MutualPorPacienteList();
            //var mList = from m in mutualList select new MutualPorPacienteBE { IdMutual = m.IdMutual, IdPatient = Patient.PatientId };
            //wMutualPorPacienteList.AddRange(mList);
            req.BusinessData.Mutuales = mutualList;
            req.ContextInformation.UserId = frmBase_TabForm.IndentityUserInfo.ProviderId.ToString();

            CrearPatientRes res = req.ExecuteService<CrearPatientReq, CrearPatientRes>(req);
            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);
            return res.BusinessData.IdPatient;
        }
        public static void UpdatePatient(PatientBE Patient, MutualPorPacienteList mutualList, DateTime? nuevaFechaNacimiento)
        {
            UpdatePatientReq req = new UpdatePatientReq();
            req.BusinessData.AnteriorFechaNacimiento = nuevaFechaNacimiento;
            req.BusinessData.Patient = Patient;
            //MutualPorPacienteList wMutualPorPacienteList = new MutualPorPacienteList();
            //var mList = from m in mutualList select new MutualPorPacienteBE { IdMutual = m.IdMutual, IdPatient = Patient.PatientId };
            //wMutualPorPacienteList.AddRange(mList);
            req.BusinessData.Mutuales = mutualList;

            req.ContextInformation.UserId = frmBase_TabForm.IndentityUserInfo.ProviderId.ToString();

            UpdatePatientRes res = req.ExecuteService<UpdatePatientReq, UpdatePatientRes>(req);
            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Patient"></param>
        /// <param name="mutualList"></param>
        public static void AsociarPatientAPersona(PatientBE Patient, MutualPorPacienteList mutualList)
        {
            AsociarPatientAPersonaReq req = new AsociarPatientAPersonaReq();

            req.BusinessData.Patient = Patient;
            //MutualPorPacienteList wMutualPorPacienteList = new MutualPorPacienteList();
            //var mList = from m in mutualList select new MutualPorPacienteBE { IdMutual = m.IdMutual, IdPatient = Patient.PatientId };
            //wMutualPorPacienteList.AddRange(mList);
            req.BusinessData.Mutuales = mutualList;
            //req.BusinessData.AnteriorFechaNacimiento = anteriorFechaNacimiento;
            req.ContextInformation.UserId = frmBase_TabForm.IndentityUserInfo.ProviderId.ToString();

            AsociarPatientAPersonaRes res = req.ExecuteService<AsociarPatientAPersonaReq, AsociarPatientAPersonaRes>(req);
            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);

        }


        public static PlanVacunacion_FullViewList Patient_GetPlanVacunacion(int idPatient)
        {
            GetPlanVacunacionReq req = new GetPlanVacunacionReq();
            req.BusinessData.IdPatient = idPatient;

            req.ContextInformation.UserId = frmBase_TabForm.IndentityUserInfo.ProviderId.ToString();


            GetPlanVacunacionRes res = req.ExecuteService<GetPlanVacunacionReq, GetPlanVacunacionRes>(req);
            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);
            return res.BusinessData;
        }
        public static void Patient_UpdatePlanVacunacion(PlanVacunacion_FullViewList plan)
        {
            UpdatePlanVacunacionReq req = new UpdatePlanVacunacionReq();
            req.ContextInformation.UserId = frmBase_TabForm.IndentityUserInfo.ProviderId.ToString();
            req.BusinessData = plan;

            UpdatePlanVacunacionRes res = req.ExecuteService<UpdatePlanVacunacionReq, UpdatePlanVacunacionRes>(req);
            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="profesional">ProfesionalBE</param>
        /// <param name="userName">Nombre de usuario para inicio de sesión al sistema</param>
        /// <returns></returns>
        public static int CrearProfesional(ProfesionalBE profesional, Fwk.Security.Common.User user)
        {
            CrearProfesionalReq req = new CrearProfesionalReq();

            req.BusinessData.profesional = profesional;
            req.BusinessData.User = user;
            req.ContextInformation.UserId = frmBase_TabForm.IndentityUserInfo.ProviderId.ToString();
            req.ContextInformation.AppId = Controller.CurrentHealthInstitution.HealthInstitutionId.ToString();

            CrearProfesionalRes res = req.ExecuteService<CrearProfesionalReq, CrearProfesionalRes>(req);

            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);
            return res.BusinessData.IdProfesional;
        }
        #endregion


        public static int CreateMedicalEvent(MedicalEventBE medicalEvent)
        {
            CreatePatientEventReq req = new CreatePatientEventReq();

            req.BusinessData = medicalEvent;

            req.ContextInformation.UserId = frmBase_TabForm.IndentityUserInfo.ProviderId.ToString();
            req.ContextInformation.AppId = Controller.CurrentHealthInstitution.HealthInstitutionId.ToString();

            CreatePatientEventRes res = req.ExecuteService<CreatePatientEventReq, CreatePatientEventRes>(req);

            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);

            return res.BusinessData.EventId;
        }

        public static void UpdateMedicalEvent(MedicalEventBE medicalEvent)
        {
            UpdatePatientEventReq req = new UpdatePatientEventReq();

            req.BusinessData = medicalEvent;

            req.ContextInformation.UserId = frmBase_TabForm.IndentityUserInfo.ProviderId.ToString();
            req.ContextInformation.AppId = Controller.CurrentHealthInstitution.HealthInstitutionId.ToString();

            UpdatePatientEventRes res = req.ExecuteService<UpdatePatientEventReq, UpdatePatientEventRes>(req);

            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);


        }
        public static MedicalEvent_ViewList RetriveMedicalEvent(int patientId)
        {
            RetrivePatientEventReq req = new RetrivePatientEventReq();
            req.BusinessData.PatientId = patientId;
            RetrivePatientEventRes res = req.ExecuteService<RetrivePatientEventReq, RetrivePatientEventRes>(req);

            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);

            return res.BusinessData;
        }

        public static MedicalEventBE GetMedicalEvent(int medicalEventId)
        {
            GetPatientEventReq req = new GetPatientEventReq();

            req.BusinessData.MedicalEventId = medicalEventId;


            GetPatientEventRes res = req.ExecuteService<GetPatientEventReq, GetPatientEventRes>(req);

            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);

            return res.BusinessData;
        }

        public static object RetriveMedicalEvent_PMO_Diad(int patientId, bool pPMOQuir, bool pRetrive_CEI10, bool pRetrive_PMOMetodoComplementario)
        {
            RetriveMedicalEventPMO_DiagReq req = new RetriveMedicalEventPMO_DiagReq();
            req.BusinessData.PatientId = patientId;

            req.BusinessData.Retrive_PMOQuir = pPMOQuir;
            req.BusinessData.Retrive_PMOMetodoComplementario = pRetrive_PMOMetodoComplementario;
            req.BusinessData.Retrive_CEI10 = pRetrive_CEI10;

            RetriveMedicalEventPMO_DiagRes res = req.ExecuteService<RetriveMedicalEventPMO_DiagReq, RetriveMedicalEventPMO_DiagRes>(req);

            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);

            return res.BusinessData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="profesional"></param>
        /// <param name="user"></param>
        public static void UpdateProfesional(ProfesionalBE profesional, Fwk.Security.Common.User user ,Guid? healthInstitutionId)
        {
            UpdateProfesionalReq req = new UpdateProfesionalReq();

            req.BusinessData.profesional = profesional;
            req.BusinessData.User = user;
            req.BusinessData.HealthInstitutionId = healthInstitutionId;
            req.ContextInformation.UserId = frmBase_TabForm.IndentityUserInfo.ProviderId.ToString();

            req.ContextInformation.AppId = Controller.CurrentHealthInstitution.HealthInstitutionId.ToString();

            UpdateProfesionalRes res = req.ExecuteService<UpdateProfesionalReq, UpdateProfesionalRes>(req);

            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);
            //return res.BusinessData.IdPersona;
        }

        /// <summary>
        /// Retorna profesional por id o userGuid
        /// </summary>
        /// <param name="idProfesional"></param>
        /// <param name="includeScheduler"></param>
        /// <param name="userGuid">Si no posee el guid se puede buscar por userGuid</param>
        /// <returns></returns>
        public static GetProfesionalRes GetProfesional(int? idProfesional, bool includeScheduler, bool includeSecurityInfo,bool includeAllInstitutions, Guid? userGuid = null, Guid? healthInstitutionId = null)
        {
            GetProfesionalReq req = new GetProfesionalReq();

            req.BusinessData.IdProfesional = idProfesional;
            req.BusinessData.IncludeScheduler = includeScheduler;
            req.BusinessData.IncludeSecurityInfo = includeSecurityInfo;
            req.BusinessData.UserGuid = userGuid;
            req.BusinessData.HealthInstitutionId = healthInstitutionId;
            req.BusinessData.IncludeSecurityInfo = includeSecurityInfo;
            req.BusinessData.IncludeAllInstitutions = includeAllInstitutions;
            
            req.ContextInformation.UserId = frmBase_TabForm.IndentityUserInfo.ProviderId.ToString();
            if (Controller.CurrentHealthInstitution!=null)
             req.ContextInformation.AppId = Controller.CurrentHealthInstitution.HealthInstitutionId.ToString();

            GetProfesionalRes res = req.ExecuteService<GetProfesionalReq, GetProfesionalRes>(req);

            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);

            return res;
        }

        /// <summary>
        /// Retorna todas Vista completa de un Profesional
        /// </summary>
        /// <returns><see cref="Profesional_FullViewList"/></returns>
        public static Profesional_FullViewList RetriveProfesionales(string nombre, string apellido, Guid? healthInstId)
        {
            RetriveProfesionalesReq req = new RetriveProfesionalesReq();

            req.BusinessData.Apellido = apellido;
            req.BusinessData.Nombre = nombre;
            req.BusinessData.HealthInstId = healthInstId;
            req.ContextInformation.UserId = frmBase_TabForm.IndentityUserInfo.ProviderId.ToString();
            req.ContextInformation.AppId = Controller.CurrentHealthInstitution.HealthInstitutionId.ToString();

            RetriveProfesionalesRes res = req.ExecuteService<RetriveProfesionalesReq, RetriveProfesionalesRes>(req);


            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);
            return res.BusinessData;
        }


        public static void CreateResourceScheduling(ResourceSchedulingBE pResourceScheduling, Guid healthInstId)
        {
            ResourceSchedulingList list = new ResourceSchedulingList();
            pResourceScheduling.HealthInstitutionId = healthInstId;
            list.Add(pResourceScheduling);
            CreateResourceScheduling(list, healthInstId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="healthInstId"></param>
        public static void CreateResourceScheduling(ResourceSchedulingList list, Guid healthInstId)
        {
            CreateResourceSchedulingReq req = new CreateResourceSchedulingReq();
            list.ForEach(p => p.HealthInstitutionId = healthInstId);
            req.BusinessData = list;
            req.ContextInformation.UserId = frmBase_TabForm.IndentityUserInfo.ProviderId.ToString();
            req.ContextInformation.AppId = Controller.CurrentHealthInstitution.HealthInstitutionId.ToString();

            CreateResourceSchedulingRes res = req.ExecuteService<CreateResourceSchedulingReq, CreateResourceSchedulingRes>(req);
            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);
        }

        public static void UpdateResourceSheduling(ResourceSchedulingBE resourceSchedulingBE, Guid healthInstId)
        {
            ResourceSchedulingList list = new ResourceSchedulingList();
            list.Add(resourceSchedulingBE);
            UpdateResourceScheduling(list, healthInstId);
        }
        public static void UpdateResourceScheduling(ResourceSchedulingList list, Guid healthInstId)
        {
            UpdateResourceSchedulingReq req = new UpdateResourceSchedulingReq();
            list.ForEach(p => p.HealthInstitutionId = healthInstId);
            req.BusinessData = list;
            
            req.ContextInformation.UserId = frmBase_TabForm.IndentityUserInfo.ProviderId.ToString();
            req.ContextInformation.AppId = Controller.CurrentHealthInstitution.HealthInstitutionId.ToString();

            UpdateResourceSchedulingRes res = req.ExecuteService<UpdateResourceSchedulingReq, UpdateResourceSchedulingRes>(req);


            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);

        }

        public static void CreateAppointments(AppointmentList list)
        {
            CreateAppointmentsReq req = new CreateAppointmentsReq();

            req.BusinessData = list;
            req.ContextInformation.UserId = frmBase_TabForm.IndentityUserInfo.ProviderId.ToString();
            req.ContextInformation.AppId = Controller.CurrentHealthInstitution.HealthInstitutionId.ToString();

            CreateAppointmentsRes res = req.ExecuteService<CreateAppointmentsReq, CreateAppointmentsRes>(req);


            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceId"></param>
        /// <param name="startDate"></param>
        /// <param name="useAsStartDate">Detetmina si Date es = o >=</param>
        /// <returns></returns>
        public static RetriveResourceSchedulingAndAppoinmentsRes RetriveResourceSchedulingAndAppoinments(int resourceId, DateTime startDate, bool useAsStartDate, Guid? healthInstId)
        {
            RetriveResourceSchedulingAndAppoinmentsReq req = new RetriveResourceSchedulingAndAppoinmentsReq();

            req.BusinessData.UseStartDate = useAsStartDate;
            req.BusinessData.Date = startDate;
            req.BusinessData.ResourceId = resourceId;
            req.BusinessData.HealthInstId = healthInstId;
            req.ContextInformation.UserId = frmBase_TabForm.IndentityUserInfo.ProviderId.ToString();
            req.ContextInformation.AppId = Controller.CurrentHealthInstitution.HealthInstitutionId.ToString();

            RetriveResourceSchedulingAndAppoinmentsRes res = req.ExecuteService<RetriveResourceSchedulingAndAppoinmentsReq, RetriveResourceSchedulingAndAppoinmentsRes>(req);


            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);

            return res;
        }

        public static AppointmentBE Get_Appointment(int appointmetId)
        {
            GetAppoinmentByParamsReq req = new GetAppoinmentByParamsReq();

            req.BusinessData.AppointmentId = appointmetId;

            req.ContextInformation.UserId = frmBase_TabForm.IndentityUserInfo.ProviderId.ToString();
            req.ContextInformation.AppId = Controller.CurrentHealthInstitution.HealthInstitutionId.ToString();
       

            GetAppoinmentByParamsRes res = req.ExecuteService<GetAppoinmentByParamsReq, GetAppoinmentByParamsRes>(req);


            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);

            return res.BusinessData.AppointmentBE;
        }

        public static AppointmentList RetriveAppointment(int? status, DateTime? startDate, int? resourseId = null, Guid? healthInstId=null)
        {
            RetriveAppointmentReq req = new RetriveAppointmentReq();

            req.BusinessData.StartDate = startDate;

            req.BusinessData.Status = status;

            req.ContextInformation.UserId = frmBase_TabForm.IndentityUserInfo.ProviderId.ToString();
            req.ContextInformation.AppId = Controller.CurrentHealthInstitution.HealthInstitutionId.ToString();
            req.BusinessData.ResourseId = resourseId;
            req.BusinessData.HealthInstId = healthInstId;
            RetriveAppointmentRes res = req.ExecuteService<RetriveAppointmentReq, RetriveAppointmentRes>(req);


            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);

            return res.BusinessData.AppoimentsList;
        }
        public static void UpdateAppoiment(AppointmentList appointments)
        {
            UpdateAppointmentsReq req = new UpdateAppointmentsReq();

            req.BusinessData = appointments;
            req.ContextInformation.UserId = frmBase_TabForm.IndentityUserInfo.ProviderId.ToString();
            req.ContextInformation.AppId = Controller.CurrentHealthInstitution.HealthInstitutionId.ToString();
            req.ContextInformation.AppId = Controller.CurrentHealthInstitution.HealthInstitutionId.ToString();
            UpdateAppointmentsRes res = req.ExecuteService<UpdateAppointmentsReq, UpdateAppointmentsRes>(req);

            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);
        }
        public static void UpdateAppoimentStatus(AppointmentBE appointment)
        {
            AppointmentList wAppointmentList = new AppointmentList();
            wAppointmentList.Add(appointment);
            UpdateAppoiment(wAppointmentList);
        }
        public static void UpdateAppoimentStatus(AppointmentList appointments)
        {
            UpdateAppointmentStatusReq req = new UpdateAppointmentStatusReq();

            req.BusinessData = appointments;
            req.ContextInformation.UserId = frmBase_TabForm.IndentityUserInfo.ProviderId.ToString();
            req.ContextInformation.AppId = Controller.CurrentHealthInstitution.HealthInstitutionId.ToString();

            UpdateAppointmentStatusRes res = req.ExecuteService<UpdateAppointmentStatusReq, UpdateAppointmentStatusRes>(req);

            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);
        }
        public static void CreateAppointments(AppointmentBE app)
        {
            AppointmentList l = new BE.AppointmentList();
            l.Add(app);
            CreateAppointments(l);
        }

        public static MutualList RetriveAllObraSocial()
        {
            RetriveAllObraSocialReq req = new RetriveAllObraSocialReq();
            req.ContextInformation.UserId = frmBase_TabForm.IndentityUserInfo.ProviderId.ToString();
            req.ContextInformation.AppId = Controller.CurrentHealthInstitution.HealthInstitutionId.ToString();
            RetriveAllObraSocialRes res = req.ExecuteService<RetriveAllObraSocialReq, RetriveAllObraSocialRes>(req);
            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);

            return res.BusinessData.ObraSocialList;
        }


        public static void CreateObraSocial(MutualBE mutual)
        {
            CreateObraSocialReq req = new CreateObraSocialReq();
            req.ContextInformation.UserId = frmBase_TabForm.IndentityUserInfo.ProviderId.ToString();
            req.ContextInformation.AppId = Controller.CurrentHealthInstitution.HealthInstitutionId.ToString();
            req.BusinessData.Mutual = mutual;
            CreateObraSocialRes res = req.ExecuteService<CreateObraSocialReq, CreateObraSocialRes>(req);
            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);

            //return res.BusinessData.Id;
        }


        public static bool IsInDesignMode()
        {
            bool returnFlag = false;

#if DEBUG
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
            {
                returnFlag = true;
            }
            else if (Process.GetCurrentProcess().ProcessName.ToUpper().Equals("DEVENV"))
            {
                returnFlag = true;
            }
#endif

            return returnFlag;
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId">patient id</param>
        /// <returns></returns>
        public static PatientAllergyBE GetPatientAllergy(int patientId)
        {
            GetPatientAllergyReq req = new GetPatientAllergyReq();
            req.BusinessData.PatientId = patientId;

            req.ContextInformation.UserId = frmBase_TabForm.IndentityUserInfo.ProviderId.ToString();
            req.ContextInformation.AppId = Controller.CurrentHealthInstitution.HealthInstitutionId.ToString();
            GetPatientAllergyRes res = req.ExecuteService<GetPatientAllergyReq, GetPatientAllergyRes>(req);

            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);
            res.BusinessData.PatientId = patientId;
            return res.BusinessData;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientAllergy"></param>
        /// <returns></returns>
        public static void CreateUpdatePatientAllergy(PatientAllergyBE patientAllergy)
        {
            CreateUpdatePatientAllergyReq req = new CreateUpdatePatientAllergyReq();
            req.BusinessData = patientAllergy;

            req.ContextInformation.UserId = frmBase_TabForm.IndentityUserInfo.ProviderId.ToString();
            req.ContextInformation.AppId = Controller.CurrentHealthInstitution.HealthInstitutionId.ToString();
            CreateUpdatePatientAllergyRes res = req.ExecuteService<CreateUpdatePatientAllergyReq, CreateUpdatePatientAllergyRes>(req);

            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);

        }

        /// <summary>
        /// Busca medicamentos para un determinado Patient .-
        /// </summary>
        /// <param name="patientId">Patient</param>
        /// <param name="medicalEvenId">Si distinto de null busca por un evento medico en particular. Si retriveHistory = true. Se ignora este parametro</param>
        /// <param name="retriveHistory">Si es true retorna todos los medicamentos (History).-
        /// Valor por defecto false</param>
        /// <returns></returns>
        public static PatientMedicament_ViewList RetrivePatientMedicaments(int patientId, int? medicalEvenId,bool retriveHistory=false)
        {
            RetrivePatientMedicamentsReq req = new RetrivePatientMedicamentsReq();

            req.BusinessData.PatientId = patientId;
            req.BusinessData.MedicalEventId = medicalEvenId;
            req.BusinessData.RetriveHistory = retriveHistory;

            req.ContextInformation.UserId = frmBase_TabForm.IndentityUserInfo.ProviderId.ToString();
            req.ContextInformation.AppId = Controller.CurrentHealthInstitution.HealthInstitutionId.ToString();
            RetrivePatientMedicamentsRes res = req.ExecuteService<RetrivePatientMedicamentsReq, RetrivePatientMedicamentsRes>(req);

            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);

            return res.BusinessData;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public static void CreateUpdatePatientMedicaments(PatientMedicament_ViewBE patientMedicament_View)
        {
            CreateUpdatePatientMedicamentReq req = new CreateUpdatePatientMedicamentReq();
            req.BusinessData = patientMedicament_View;

            req.ContextInformation.UserId = frmBase_TabForm.IndentityUserInfo.ProviderId.ToString();
            req.ContextInformation.AppId = Controller.CurrentHealthInstitution.HealthInstitutionId.ToString();
            CreateUpdatePatientMedicamentRes res = req.ExecuteService<CreateUpdatePatientMedicamentReq, CreateUpdatePatientMedicamentRes>(req);

            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);

        }


        public static MedicalEventAlert_ViewList RetriveMedicalEventAlert(int patientID, DateTime? startDate, bool retriveHistory)
        {

            RetriveMedicalEventAlertsReq req = new RetriveMedicalEventAlertsReq();
            req.BusinessData.PatientId = patientID;
            req.BusinessData.StartDate = startDate;
            req.BusinessData.RetriveHistory = retriveHistory;

            req.ContextInformation.UserId = frmBase_TabForm.IndentityUserInfo.ProviderId.ToString();

            RetriveMedicalEventAlertsRes res = req.ExecuteService<RetriveMedicalEventAlertsReq, RetriveMedicalEventAlertsRes>(req);

            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);

            return res.BusinessData;
        }
        public static MedicalEventDetail_ViewList RetriveMedicalEventDetails(int patientID, int? medicalEventId)
        {

            RetriveMedicalEventDetailsReq req = new RetriveMedicalEventDetailsReq();
            req.BusinessData.PatientId = patientID;
            req.BusinessData.MedicalEventId = medicalEventId;
            

            req.ContextInformation.UserId = frmBase_TabForm.IndentityUserInfo.ProviderId.ToString();

            RetriveMedicalEventDetailsRes res = req.ExecuteService<RetriveMedicalEventDetailsReq, RetriveMedicalEventDetailsRes>(req);

            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);

            return res.BusinessData;
        }
        public static Patient_Appointments_ViewList RetrivePatientAppoinments(int patientID, DateTime? startDate, int? status)
        {

            RetrivePatientAppoimentsReq req = new RetrivePatientAppoimentsReq();
            req.BusinessData.PatientId = patientID;
            req.BusinessData.StartDate = startDate;
            req.BusinessData.Status = status;

            req.ContextInformation.UserId = frmBase_TabForm.IndentityUserInfo.ProviderId.ToString();

            RetrivePatientAppoimentsRes res = req.ExecuteService<RetrivePatientAppoimentsReq, RetrivePatientAppoimentsRes>(req);

            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);

            return res.BusinessData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pActivationCode"></param>
        /// <returns></returns>
        public static HealthInstitutionBE ValidateActivationCode(string pActivationCode)
        {
            ValidateActivationCodeReq req = new ValidateActivationCodeReq();
            req.BusinessData.Code = pActivationCode;
            //req.ContextInformation.UserId = frmBase_TabForm.IndentityUserInfo.ProviderId.ToString();

            ValidateActivationCodeRes res = req.ExecuteService<ValidateActivationCodeReq, ValidateActivationCodeRes>(req);

            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);

            return res.BusinessData;
        }






        /// <summary>
        /// Busca HealthInstitution por parametros
        /// </summary>
        /// <returns></returns>
        public static HealthInstitutionList RetriveHealthInstitutionList(string text)
        {
            RetriveHealthInstitutionReq req = new RetriveHealthInstitutionReq();

            req.BusinessData.TextToSearch = text;
            if (frmBase_TabForm.IndentityUserInfo!=null)
                req.ContextInformation.UserId = frmBase_TabForm.IndentityUserInfo.ProviderId.ToString();
            RetriveHealthInstitutionRes res = req.ExecuteService<RetriveHealthInstitutionReq, RetriveHealthInstitutionRes>(req);


            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);
            return res.BusinessData;
        }
        /// <summary>
        /// Retrorna HealthInstitution_ProfesionalBE HealthInstitution por parametros
        /// </summary>
        /// <returns></returns>
        public static AuthHealthInstitutionRes AuthHealthInstitution(Guid pHealthInstitutionId, Int32? pProfesionalId,Guid? userId)
        {
            AuthHealthInstitutionReq req = new AuthHealthInstitutionReq();

            req.BusinessData.HealthInstId = pHealthInstitutionId;
            req.BusinessData.ProfesionalId = pProfesionalId;
            req.BusinessData.UserId = userId;
            if (frmBase_TabForm.IndentityUserInfo != null)
                req.ContextInformation.UserId = frmBase_TabForm.IndentityUserInfo.ProviderId.ToString();
            AuthHealthInstitutionRes res = req.ExecuteService<AuthHealthInstitutionReq, AuthHealthInstitutionRes>(req);


            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);

            return res;
        }





        public static HealthInstitutionBE GetHealthInstitutionById(Guid pHealthInstitutionId)
        {
            GetHealthInstitutionByIdReq req = new GetHealthInstitutionByIdReq();

            req.BusinessData.HealthInstId = pHealthInstitutionId;
            
            if (frmBase_TabForm.IndentityUserInfo != null)
                req.ContextInformation.UserId = frmBase_TabForm.IndentityUserInfo.ProviderId.ToString();
            GetHealthInstitutionByIdRes res = req.ExecuteService<GetHealthInstitutionByIdReq, GetHealthInstitutionByIdRes>(req);


            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);

            return res.BusinessData;
        }

        public static void RemoveAppoiment(int appointmentId)
        {
            RemoveAppointmentReq req = new RemoveAppointmentReq();

            req.BusinessData.AppointmentId = appointmentId;

            if (frmBase_TabForm.IndentityUserInfo != null)
                req.ContextInformation.UserId = frmBase_TabForm.IndentityUserInfo.ProviderId.ToString();
            RemoveAppointmentRes res = req.ExecuteService<RemoveAppointmentReq, RemoveAppointmentRes>(req);


            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);

           
        }

     
    }





}