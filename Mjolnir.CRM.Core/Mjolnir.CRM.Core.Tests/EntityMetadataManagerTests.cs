using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mjolnir.CRM.Core.EntityManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mjolnir.CRM.Sdk.Extensions;
using Microsoft.Xrm.Sdk.Metadata;

namespace Mjolnir.CRM.Core.Tests
{
    [TestClass]
    public class EntityMetadataManagerTests : CrmUnitTestBase
    {

        [TestMethod]
        public void Should_Retrieve_Contact_Entity_Metadata()
        {
            var entityMetadataManager = new EntityMetadataManager(SourceCrmContext);

            var task = entityMetadataManager.GetEntityMetadataByEntitySchemaName("contact");

            task.Wait();

            var result = task.Result;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Should_Compare_Same_Entity_Attributes_Metadata()
        {
            ConnectTargetCRM();

            var sourceEntityMetadataManager = new EntityMetadataManager(SourceCrmContext);
            var task = sourceEntityMetadataManager.GetEntityMetadataByEntitySchemaName("contact", EntityFilters.Attributes);
            task.Wait();
            var sourceContactEntityMetadata = task.Result;

            Assert.IsNotNull(sourceContactEntityMetadata);

            var targetEntityMetadataManager = new EntityMetadataManager(TargetCrmContext);
            var task2 = sourceEntityMetadataManager.GetEntityMetadataByEntitySchemaName("contact", EntityFilters.Attributes);
            task2.Wait();
            var targetContactEntityMetadata = task2.Result;

            Assert.IsNotNull(targetContactEntityMetadata);

            var compareConfig = new Sdk.ValueObjects.EntityMetadataComparisonConfiguration()
            {
                EntityFilters = EntityFilters.Attributes,
                ContinueOnDifference = true,
                IsTargetToSourceAttributeCheck = true
            };

            //Same CRM instance, same entity comparison should be equal
            var compareResult = sourceContactEntityMetadata.CompareMetadata(targetContactEntityMetadata, compareConfig);

            Assert.IsTrue(compareResult.IsEqual);
        }

        [TestMethod]
        public void Should_Compare_Different_Entity_Attributes_Metadata()
        {
            ConnectTargetCRM();

            var sourceEntityMetadataManager = new EntityMetadataManager(SourceCrmContext);
            var task = sourceEntityMetadataManager.GetEntityMetadataByEntitySchemaName("contact");
            task.Wait();
            var sourceContactEntityMetadata = task.Result;

            Assert.IsNotNull(sourceContactEntityMetadata);

            var targetEntityMetadataManager = new EntityMetadataManager(TargetCrmContext);
            var task2 = sourceEntityMetadataManager.GetEntityMetadataByEntitySchemaName("account");
            task2.Wait();
            var targetContactEntityMetadata = task2.Result;

            Assert.IsNotNull(targetContactEntityMetadata);

            var compareConfig = new Sdk.ValueObjects.EntityMetadataComparisonConfiguration()
            {
                EntityFilters = EntityFilters.Attributes,
                ContinueOnDifference = true,
                IsTargetToSourceAttributeCheck = true
            };

            //Same CRM instance, same entity comparison should be equal
            var compareResult = sourceContactEntityMetadata.CompareMetadata(targetContactEntityMetadata, compareConfig);

            Assert.IsFalse(compareResult.IsEqual);
        }

        public void Should_Compare_Same_Entity_Relationships_Metadata()
        {
            ConnectTargetCRM();

            var sourceEntityMetadataManager = new EntityMetadataManager(SourceCrmContext);
            var task = sourceEntityMetadataManager.GetEntityMetadataByEntitySchemaName("contact");
            task.Wait();
            var sourceContactEntityMetadata = task.Result;

            Assert.IsNotNull(sourceContactEntityMetadata);

            var targetEntityMetadataManager = new EntityMetadataManager(TargetCrmContext);
            var task2 = sourceEntityMetadataManager.GetEntityMetadataByEntitySchemaName("contact");
            task2.Wait();
            var targetContactEntityMetadata = task2.Result;

            Assert.IsNotNull(targetContactEntityMetadata);

            var compareConfig = new Sdk.ValueObjects.EntityMetadataComparisonConfiguration()
            {
                EntityFilters = EntityFilters.Relationships,
                ContinueOnDifference = true,
                IsTargetToSourceAttributeCheck = true
            };

            //Same CRM instance, same entity comparison should be equal
            var compareResult = sourceContactEntityMetadata.CompareMetadata(targetContactEntityMetadata, compareConfig);

            Assert.IsTrue(compareResult.IsEqual);
        }
    }
}
