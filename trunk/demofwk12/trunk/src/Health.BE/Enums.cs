using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace Health.BE.Enums
{
    /// <summary>
    /// Espesifica el tipo de detalle de un evento clinico
    /// </summary>
    public enum MedicalEventDetailType
    {
        /// <summary>
        /// CEI-10
        /// </summary>
        CEI10_Diagnosis = 12000,
        ///// <summary>
        ///// PMO
        ///// </summary>
        //Tratamiento_TTO = 12001,
        /// <summary>
        ///      PMOEnum.Diagnostico_Imagenes 
        ///        PMOEnum.Odontológicas 
        ///       PMOEnum.Diagnostico_Analisis_Clinico
        /// </summary>
        Metodo_Complementarios = 12002,
        /// <summary>
        /// PMO 859 Reabilit
        /// </summary>
        Rehabilitación = 12004,

        Quirurgico = 12005

    }

    /// <summary>
    /// 
    /// </summary>
    public enum AlertTypeEnum
    {
        Diagnosis = 1,
        Alergy = 2,
        Internacion = 3
    }

    /// <summary>
    /// Tipo parametro DiagnosisRelevanceType IdTioParametro = 860
    /// </summary>
    public enum DiagnosisRelevanceType
    {
        RelevanteActual                                  = 870,
        RelevanteCrónico = 871,
        Presuntivo = 872
    }


    public enum BoodGroupEnum
    {
        A=0,
        B=1,
        AB=2,
        O=3
    }
    public enum BoodFactorEnum
    {
        Negative = 0,
        Positive = 1
        
        
    }
    public enum MedicamentStatus
    {
        [Description("Permanente")]
        Permanente = 660,
        [Description("Suspendido")]
        Suspendido = 661,
        [Description("Suspendido Temporalmente")]
        Suspendido_Temporalmente = 662,
        [Description("Temporal")]
        Temporal = 663,
       [Description("Finalizado")]
        Finalizado = 664,
       [Description("Deshabilitado")]
       Deshabilitado = 665,
    }

    public enum PMOEnum
    {
        Quirurgicas = 850,
        Odontológicas = 851,
        Diagnostico_Imagenes = 852,//Espesializadas = 852,
        Diagnostico_Analisis_Clinico = 853,
        Rehabilitacion = 854 ,// PMO Espesializado
    }

    public enum Sexo
    {
        Masculino = 0,
        Femenino = 1,
    }

    public enum EstadoCivil
    {
        Soltero = 101,
        Casado = 102,
        Divorciado = 103,
        Viudo = 104,
    }

    /// <summary>
    /// 630	Reservado                                         
    ///631	Es atencion                                       
    ///632	Cerrado                                           
    ///633	Cancelado                                         
    ///634	Expirado                                             
    ///635	En espera                                         
    /// </summary>
    public enum AppoimantsStatus_SP
    {
        Reservado = 630,
        EnAtencion = 631,
        Cerrado = 632,
        Cancelado = 633,
        Expirado = 634,
        EnEspera = 635,
        Libre = 636,
        Nulo = 637
        
    }
    public enum AppoimantsStatus_SP_type
    {
        
        Entreturno = 638,
        Sobreturno = 639
    }
   /// <summary>
   /// Estados de una subscripcion enviada para pertenecer a una institución
   /// </summary>
    public enum SubscriptionRequestStatus
    {
        EnEspera = 650,
        Rechazado = 651,
        Expirado = 652,
        Null = 653

    }

    public enum MonthsShortName_ES
    {
        ENE = 1,
        FEB = 2,
        MAR = 3,
        ABR = 4,
        MAY = 5,
        JUN = 6,
        JUL = 7,
        AGO = 8,
        SET = 9,
        OCT = 10,
        NOV = 11,
        DIC = 12

    }




    public enum MonthsNames_ES
    {
        Enero = 1,
        Febrero = 2,
        Marzo = 3, Abril = 4, Mayo = 5, Junio = 6, Julio = 7, Agosto = 8,
        Septiembre = 9,
        Octubre = 10,
        Noviembre = 11,
        Diciembre = 12

    }

    /// <summary>
    /// El orden esta asociado al orden que maneja DxExpress para ubicar el correspondiente valor en base 2
    /// SAB	VIE	JUE	MIE	MAR	LUN	DOM
    /// 0   0   0   0   1   0   0
    /// 0   0   0   0   0   0   1
    /// </summary>
    [Serializable]
    [ComVisible(true)]
    public enum DayNamesIndex_ES
    {
        //SAB	VIE	JUE	MIE	MAR	LUN	DOM
        Sabado = 0,
        Viernes = 1,
        Jueves = 2,
        Miercoles = 3,
        Martes = 4,
        Lunes = 5,
        Domingo = 6
    }



    //}
    // Summary:
    //     Lists days and groups of days for recurrence patterns.
    [Serializable]
    [Flags]
    public enum WeekDays_EN
    {
        // Summary:
        //     Specifies Sunday.
        Sunday = 1,
        //
        // Summary:
        //     Specifies Monday.
        Monday = 2,
        //
        // Summary:
        //     Specifies Tuesday.
        Tuesday = 4,
        //
        // Summary:
        //     Specifies Wednesday.
        Wednesday = 8,
        //
        // Summary:
        //     Specifies Thursday.
        Thursday = 16,
        //
        // Summary:
        //     Specifies Friday.
        Friday = 32,
        //
        // Summary:
        //     Specifies work days (Monday, Tuesday, Wednesday, Thursday and Friday).
        WorkDays = 62,
        //
        // Summary:
        //     Specifies Saturday.
        Saturday = 64,
        //
        // Summary:
        //     Specifies Saturday and Sunday.
        WeekendDays = 65,
        //
        // Summary:
        //     Specifies every day of the week.
        EveryDay = 127,
    }


    public enum CommonValuesEnum
    {
        TodosComboBoxValue = -1000,
        VariosComboBoxValue = -2000,
        SeleccioneUnaOpcion = -3000,
        Ninguno = -4000
    }

    public enum TipoParametroEnum
    {
        Especialidad = 500,
        Profesion = 100,
        EstadoCivil = 600,
        TipoDocumento = 601,
        TipoConsulta = 200,
        TipoEventoMedico = 700,
        TipoMedioContacto = 1000,
        Paices = 1050,
        Localidad = 1200,
        Provincia = 1100,
        AllergiesTypes = 10100,
        AllergiesItemTypes = 10101
    }

    public enum RubroProfesionalEnum
    {
        //Secretario = 100,
        //Medico = 101,
        //Limpiesa = 102,
        //Enfermeria = 103,
        //Informatico_Administrador = 104


        Secretario = 100,
        Medico = 104,
        LicFisioterapia = 102,
        Enfermeria = 103,
        Informatico_Administrador = 101,
        Bioquico = 105,
        Lic_Bioimagenes = 106,
        Odontologo = 107,
        Aaladeutiped = 108,
        Sala_uti_neo = 109
    }

    public enum TipoAlergia
    {
        AnimalAllergy = 10104,
        ChemicalAllergy= 10108,
        FoodAllergy = 10103,
        InsectAllergy= 10106,
        MedicamentsAllergy= 10105,
        MiteAllergy= 10102,
        PollenAllergy = 10101 ,
        SunAllergy = 10107
    }
}
