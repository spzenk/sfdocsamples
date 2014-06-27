using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Health.Entities;
using Health.Back.BE;
using Health.Isvc.RetrivePersonas;
using Fwk.UI.Controller;
using System.Runtime.Remoting.Messaging;
using System.Diagnostics;
using Health.BE;
using Health.Isvc.SearchParametroByParams;

namespace Health.Front
{
    /// <summary>
    /// Clase llamadora de servicios
    /// </summary>
    internal class Controller
    {

        static ParametroList _MotivoConsultaList;

        public static ParametroList MotivoConsultaList
        {
            get { return Controller._MotivoConsultaList; }
            set { Controller._MotivoConsultaList = value; }
        }

        /// <summary>
        /// Constructor estatico aqui inicializar listas y ciertos datos utilies en todo el sistema.-
        /// Se puede hacer tambien una inicializacion asincrona.-
        /// </summary>
        static Controller()    {

        }

        /// <summary>
        /// Busca parametros por tipo y parent ref
        /// </summary>
        /// <param name="pIdTipo">Param tipe</param>
        /// <param name="pIdParametroRef">Referencia</param>
        /// <returns></returns>
        public static ParametroList SearchParametroByParams(int? pIdTipo, int? pIdParametroRef)
        {
            SearchParametroByParamsReq req = new SearchParametroByParamsReq();


            

            req.BusinessData.IdTipoParametro = pIdTipo;
            req.BusinessData.IdParametroRef = pIdParametroRef;
            req.BusinessData.Vigente = true;


            SearchParametroByParamsRes res = req.ExecuteService<SearchParametroByParamsReq, SearchParametroByParamsRes>(req);
            
            //Control de errores ante llamadas
            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);

            Exception es = Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error); ;

            
            
            return res.BusinessData;
        }


        internal static bool IsInDesignMode()
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




    }

}