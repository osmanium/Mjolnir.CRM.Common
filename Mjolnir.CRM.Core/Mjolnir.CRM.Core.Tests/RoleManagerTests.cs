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
    public class RoleManagerTests : CrmUnitTestBase
    {
        [TestMethod]
        public void should_get_role_by_name()
        {
            var roleEntityManager = new RoleManager(CrmContext);

            var adminRole = roleEntityManager.GetRoleByName("System Administrator");

            Assert.IsNotNull(adminRole);
        }
    }
}
