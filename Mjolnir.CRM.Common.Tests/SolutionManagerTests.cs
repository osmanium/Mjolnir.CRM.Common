using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk.Client;
using System.Configuration;
using Mjolnir.CRM.Common;
using Mjolnir.CRM.Common.EntityManagers;
using Microsoft.Xrm.Sdk;

namespace Mjolnir.CRM.Common.Tests
{
    [TestClass]
    public class SolutionManagerTests : CrmUnitTestBase
    {
       


        [TestMethod]
        public void should_create_solution()
        {
            var solutionManager = new SolutionManager(CrmContext);

            //solutionManager.CreateSolution()

            //Assert.AreEqual(

        }
    }
}
