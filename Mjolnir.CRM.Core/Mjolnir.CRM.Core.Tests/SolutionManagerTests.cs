using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk.Client;
using System.Configuration;
using Mjolnir.CRM.Core;
using Mjolnir.CRM.Core.EntityManagers;
using Microsoft.Xrm.Sdk;
using Shouldly;

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

        [TestMethod]
        public void should_retrieve_all_solutions()
        {
            var solutionManager  = new Mjolnir.CRM.Core.EntityManagers.SolutionManager(SourceCrmContext);
            var allSolutionsTask = solutionManager.GetAllSolutionsAsync();
            allSolutionsTask.Wait();
            var allSolutions = allSolutionsTask.Result;
            allSolutions.Count.ShouldBeGreaterThan(0);
        }

        [TestMethod]
        public void should_retrieve_solution_id_by_unique_name()
        {
            var solutionManager  = new Mjolnir.CRM.Core.EntityManagers.SolutionManager(SourceCrmContext);
            var task = solutionManager.GetSolutionIdByUniqueSolutionNameAsync("BaseLibrary");
            task.Wait();
            var solutionId = task.Result;
            solutionId.ShouldNotBe(Guid.Empty);
        }
    }
}
