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
    public class RolePrivilegesManagerTests : CrmUnitTestBase
    {
        [TestMethod]
        public void should_retrieve_role_privileges()
        {
            var roleManager = new RoleManager(CrmContext);
            var adminRole = roleManager.GetRoleByName("System Administrator");

            var rolePrivilegesManager = new RolePrivilegesManager(CrmContext);
            var rolePrivileges = rolePrivilegesManager.GetRolePrivileges(adminRole.Id);

            Assert.IsNotNull(rolePrivileges);
        }
    }
}
