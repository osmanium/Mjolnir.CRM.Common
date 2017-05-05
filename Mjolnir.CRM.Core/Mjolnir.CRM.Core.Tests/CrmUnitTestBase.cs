using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk.Client;
using Mjolnir.CRM.Core.Loggers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Mjolnir.CRM.Core.Tests
{
    public class CrmUnitTestBase
    {
        public CrmContext SourceCrmContext { get; set; }
        public CrmContext TargetCrmContext { get; set; }

        public CrmUnitTestBase()
        {
            ConnectSourceCRM();
        }

        public void ConnectSourceCRM()
        {
            var sourceUserName = ConfigurationManager.AppSettings["SourceUsername"];
            var sourceServer = ConfigurationManager.AppSettings["SourceServer"];
            var sourceDomain = ConfigurationManager.AppSettings["SourcePassword"];
            var sourcePassword = ConfigurationManager.AppSettings["SourceDomain"];
            var sourcePort = ConfigurationManager.AppSettings["SourcePort"];
            var sourceOrganizationName = ConfigurationManager.AppSettings["SourceOrganizationName"];
            var sourceUseSSL = Boolean.Parse(ConfigurationManager.AppSettings["SourceUseSSL"]);
            var timeOutInMinutes = Int32.Parse(ConfigurationManager.AppSettings["TimeOutInMinutes"]);

            SourceCrmContext = CrmConnection.ConnectCrm(sourceUserName, sourceServer, sourcePassword, sourceDomain, sourcePort, sourceOrganizationName, sourceUseSSL, timeOutInMinutes);
        }

        public void ConnectTargetCRM()
        {
            var targetUserName = ConfigurationManager.AppSettings["TargetUsername"];
            var targetServer = ConfigurationManager.AppSettings["TargetServer"];
            var targetDomain = ConfigurationManager.AppSettings["TargetPassword"];
            var targetPassword = ConfigurationManager.AppSettings["TargetDomain"];
            var targetPort = ConfigurationManager.AppSettings["TargetPort"];
            var targetOrganizationName = ConfigurationManager.AppSettings["TargetOrganizationName"];
            var targetUseSSL = Boolean.Parse(ConfigurationManager.AppSettings["TargetUseSSL"]);

            var timeOutInMinutes = Int32.Parse(ConfigurationManager.AppSettings["TimeOutInMinutes"]);

            TargetCrmContext = CrmConnection.ConnectCrm(targetUserName, targetServer, targetPassword, targetDomain, targetPort, targetOrganizationName, targetUseSSL, timeOutInMinutes);
        }
    }
}
