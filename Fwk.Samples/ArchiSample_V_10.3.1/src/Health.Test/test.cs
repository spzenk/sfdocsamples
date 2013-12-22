using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Health.Back;
using Health.Isvc.GetPatientAllergy;
using Health.Back.BE;

namespace Health.Test
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class test
    {
        public test()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        

        [TestMethod]
        public void GetPatientAllergy_ReturnNull()
        {
            string strErrorResut = string.Empty;
            try
            {
                var patien = PatientsDAC.GetPatientAllergy(12312);
                Assert.AreEqual(patien, null, "no retorna nulo");
            }
            catch (Exception e)
            {
                strErrorResut = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(e);
            }
            Assert.AreEqual<String>(strErrorResut, String.Empty, strErrorResut);


        }
        [TestMethod]
        public void GetPatientAllergyRes_SetXml()
        {
            string strErrorResut = string.Empty;
            string xml = Fwk.HelperFunctions.FileFunctions.OpenTextFile(@"D:\Projects\pelsofthealth\trunk\src\Health.Test\GetPatientAllergyRes.txt");

            GetPatientAllergyRes res = new GetPatientAllergyRes();
            PatientAllergyBE wPatientAllergyBE = new PatientAllergyBE();

            //res.BusinessData = new Back.BE.PatientAllergyBE();
            res.BusinessData = null;
            string x = res.GetXml(); 
            try
            {
                res = (GetPatientAllergyRes)Fwk.HelperFunctions.SerializationFunctions.DeserializeFromXml(typeof(GetPatientAllergyRes),xml);
                res.SetXml(x);
                res.SetXml(xml);
            }
            catch (Exception e)
            {
                strErrorResut = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(e);
            }
            Assert.AreEqual<String>(strErrorResut, String.Empty, strErrorResut);
        }
    }
}
    
