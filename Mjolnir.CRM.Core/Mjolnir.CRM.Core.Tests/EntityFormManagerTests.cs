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
    public class EntityFormManagerTests : CrmUnitTestBase
    {
        [TestMethod]
        public void Should_Retrieve_Entity_Forms()
        {
            var systemFormManager = new SystemFormManager(SourceCrmContext);

            var task = systemFormManager.GetAllSystemFormsByEntitySchemaNameAsync("new_testentity");

            task.Wait();

            var result = task.Result;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Should_Retrieve_Entity_Form_By_FormName()
        {
            var systemFormManager = new SystemFormManager(SourceCrmContext);

            var task = systemFormManager.GetSystemFormByEntitySchemaNameAndFormNameAsync("new_testentity", "Header - SOCW");

            task.Wait();

            var result = task.Result;

            Assert.IsNotNull(result);
        }
    }
}
