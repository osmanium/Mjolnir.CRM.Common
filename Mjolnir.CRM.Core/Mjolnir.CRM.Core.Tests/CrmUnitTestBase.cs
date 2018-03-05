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
            var sourceOrgConnectionString = ConfigurationManager.AppSettings["SourceOrgConnectionString"];
            SourceCrmContext = CrmConnection.ConnectCrm(sourceOrgConnectionString);
        }

        public void ConnectTargetCRM()
        {
            var targetOrgConnectionString = ConfigurationManager.AppSettings["TargetOrgConnectionString"];
            TargetCrmContext = CrmConnection.ConnectCrm(targetOrgConnectionString);
        }
    }
}
