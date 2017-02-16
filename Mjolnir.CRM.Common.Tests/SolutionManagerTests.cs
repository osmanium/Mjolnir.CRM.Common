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
    public class SolutionManagerTests : CRMUnitTestBase
    {
       


        [TestMethod]
        public void should_create_solution()
        {
            var solutionManager = new SolutionManager(CRMContext);

            //solutionManager.CreateSolution()

            //Assert.AreEqual(

        }
    }
}
