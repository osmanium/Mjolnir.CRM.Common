using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mjolnir.CRM.Core.EntityManagers;
using Mjolnir.CRM.Sdk.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mjolnir.CRM.Sdk.Extensions;

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

        [TestMethod]
        public void should_get_all_roles()
        {
            var roleEntityManager = new RoleManager(CrmContext);

            var roles = roleEntityManager.GetAllRootLevelRoles();

            Assert.IsNotNull(roles);
            Assert.IsTrue(roles.Any());

        }


        [TestMethod]
        public void should_compare_entity_records_same()
        {
            var roleEntityManager = new RoleManager(CrmContext);
            var adminRole = roleEntityManager.GetRoleByName("System Administrator");
            var adminRole2 = roleEntityManager.GetRoleByName("System Administrator");

            Assert.IsTrue(adminRole.Compare(adminRole2));
        }

        [TestMethod]
        public void should_compare_entity_records_different()
        {
            var roleEntityManager = new RoleManager(CrmContext);
            var adminRole = roleEntityManager.GetRoleByName("System Administrator");
            var adminRole2 = roleEntityManager.GetRoleByName("System Customizer");

            Assert.IsFalse(adminRole.Compare(adminRole2));
        }
    }
}
