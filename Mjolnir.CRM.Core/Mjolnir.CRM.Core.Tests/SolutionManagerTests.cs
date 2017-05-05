using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk.Client;
using System.Configuration;
using Mjolnir.CRM.Core;
using Mjolnir.CRM.Core.EntityManagers;
using Microsoft.Xrm.Sdk;

namespace Mjolnir.CRM.Core.Tests
{
    [TestClass]
    public class SolutionManagerTests : CrmUnitTestBase
    {
       


        [TestMethod]
        public void should_create_solution()
        {
            var solutionManager = new SolutionManager(SourceCrmContext);

            //solutionManager.CreateSolution()

            //Assert.AreEqual(

        }
    }
}
