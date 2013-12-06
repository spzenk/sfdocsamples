using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Data.Common;
using Health.Entities;
using Health.Back.BE;
using System.Data;
using Health.BE;
using Fwk.Exceptions;
namespace Health.Back
{
    public  class EnvironmentDAC
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="activationKey"></param>
        /// <returns></returns>
        public static HealthInstitutionBE ValidateCode(String activationKey)
        {
            HealthInstitutionBE wHealthInstitutionBE = null;
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                var wHealthInstitution = dc.HealthInstitutions.Where(p => p.ActivationKey.Equals(activationKey)).FirstOrDefault<Health.Back.BE.HealthInstitution>();

                if (wHealthInstitution != null)
                    wHealthInstitutionBE = new HealthInstitutionBE(wHealthInstitution);
             
                return wHealthInstitutionBE;
            }
        }
    }
}
