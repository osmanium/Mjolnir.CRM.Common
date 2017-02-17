﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk.Client;
using Mjolnir.CRM.Common.Loggers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Common.Tests
{
    [TestClass]
    public class CrmUnitTestBase
    {

        public CrmContext CrmContext { get; set; }

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
            var timeOutInMinutes = Int32.Parse(ConfigurationManager.AppSettings["TimeOutInMinutes"]);


            CrmContext = CrmConnection.ConnectCrm(sourceUserName, sourceServer, sourcePassword, sourceDomain, sourcePort, sourceOrganizationName, sourceUseSSL, timeOutInMinutes);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (CrmContext != null && CrmContext.OrganizationService != null)
                CrmContext.Dispose();
        }
    }
}
