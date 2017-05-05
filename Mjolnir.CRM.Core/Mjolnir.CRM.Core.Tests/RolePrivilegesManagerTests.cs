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
            var roleManager = new RoleManager(SourceCrmContext);
            var task = roleManager.GetRoleByNameAsync("System Administrator");
            task.Wait();

            var adminRole = task.Result;

            var rolePrivilegesManager = new RolePrivilegesManager(SourceCrmContext);
            var task2 = rolePrivilegesManager.GetRolePrivilegesAsync(adminRole.Id);
            task.Wait();

            var rolePrivileges = task.Result;

            Assert.IsNotNull(rolePrivileges);
        }
    }
}
