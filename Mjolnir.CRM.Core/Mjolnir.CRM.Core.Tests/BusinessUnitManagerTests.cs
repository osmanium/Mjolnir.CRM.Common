using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mjolnir.CRM.Core.EntityManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Core.Tests
{
    [TestClass]
    public class BusinessUnitManagerTests : CrmUnitTestBase
    {
        [TestMethod]
        public void should_get_business_unit_by_name()
        {
            var businessUnitEntityManager = new BusinessUnitManager(SourceCrmContext);

            var task = businessUnitEntityManager.GetBusinessUnitByNameAsync("Common");
            task.Wait();

            var common = task.Result;
            Assert.AreEqual("Common", common.Name);
        }

        [TestMethod]
        public void should_get_root_business_unit()
        {
            var businessUnitEntityManager = new BusinessUnitManager(SourceCrmContext);

            var root = businessUnitEntityManager.GetRootBusinessUnitAsync();
            Assert.IsNotNull(root);
        }
    }
}
