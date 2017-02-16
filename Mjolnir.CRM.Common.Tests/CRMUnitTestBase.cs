using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Common.Tests
{
    [TestClass]
    public class CRMUnitTestBase
    {

        public CRMContext CRMContext { get; set; }

        [TestInitialize()]
        public void TestInit()
        {
            var sourceUserName = ConfigurationManager.AppSettings["Username"];
            var sourceServer = ConfigurationManager.AppSettings["Server"];
            var sourceDomain = ConfigurationManager.AppSettings["Domain"];
            var sourcePassword = ConfigurationManager.AppSettings["Password"];
            var sourcePort = ConfigurationManager.AppSettings["Port"];
            var sourceOrganizationName = ConfigurationManager.AppSettings["OrganizationName"];
            var sourceUseSSL = Boolean.Parse(ConfigurationManager.AppSettings["UseSSL"]);


            var _orgService = CRMConnection.ConnectCrm(sourceUserName, sourceServer, sourcePassword, sourceDomain, sourcePort, sourceOrganizationName, sourceUseSSL);
            if (_orgService == null)
            {
                throw new Exception("CRM connection failed");
            }
            else
            {
                int timeOutInMinutes;
                if (int.TryParse(ConfigurationManager.AppSettings["TimeOutInMinutes"], out timeOutInMinutes))
                {
                    _orgService.Timeout = new TimeSpan(0, timeOutInMinutes, 0);
                }
                else
                {
                    _orgService.Timeout = new TimeSpan(0, 30, 0);
                }
            }

            CRMContext = new CRMContext(_orgService, _orgService.CallerId, new CrmUnitTestTracer(CRMContext), null, null);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (CRMContext != null && CRMContext.OrganizationService != null)
                CRMContext.OrganizationService.Dispose();
        }
    }
}
