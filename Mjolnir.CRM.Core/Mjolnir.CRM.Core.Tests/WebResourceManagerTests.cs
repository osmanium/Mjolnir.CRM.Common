using Mjolnir.CRM.Core.EntityManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mjolnir.CRM.Core.Tests
{
    [TestClass]
    public class WebResourceManagerTests : CrmUnitTestBase
    {
        [TestMethod]
        public void should_retrieve_all_js_web_resource_metadata()
        {
            var webResourceManager = new WebResourceManager(CrmContext);

            var result = webResourceManager.GetAllWebResourcesMetadata(Sdk.Optionsets.WebResourceType.JScript);

            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Any(),
                () => result.Count.ShouldBeGreaterThan(0)
            );
        }

        [TestMethod]
        public void should_retrieve_js_content()
        {
            var webResourceManager = new WebResourceManager(CrmContext);

            string[] webResourceIds = new string[]
            {
                "8a0b4d2f-dd1a-e111-822a-00155d9c2804",
                "94336222-a834-e011-adf2-00155d9d3c04",
                "c2a338b7-77b1-e011-963d-00155db99e10"
            };

            var result = webResourceManager.GetWebResourcesContentsByIds(webResourceIds);

            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Any(),
                () => result.Count.ShouldBe(3)
            );
        }

    }
}
