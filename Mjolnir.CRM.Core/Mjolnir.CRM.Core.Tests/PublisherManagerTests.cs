using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;
using Mjolnir.CRM.Core.EntityManagers;
using Mjolnir.CRM.Sdk.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Core.Tests
{
    [TestClass]
    public class PublisherManagerTests : CrmUnitTestBase
    {
        const string PUBLISHER_FRIENDLY_NAME = "Test Publisher";
        const string PUBLISHER_UNIQUE_NAME = "test_publisher";
        const string PUBLISHER_PREFIX = "test";

        [TestMethod]
        public void should_create_publisher()
        {
            var publisherManager = new PublisherManager(CrmContext);

            var publisherEntity = new PublisherEntity();
            publisherEntity.FriendlyName = PUBLISHER_FRIENDLY_NAME;
            publisherEntity.UniqueName = PUBLISHER_UNIQUE_NAME;
            publisherEntity.CustomizationPrefix = PUBLISHER_PREFIX;
            publisherEntity.SupportingWebsiteUrl = "www.abc.com";
            publisherEntity.EMailAddress = "123@abc.com";
            publisherEntity.Description = "description";

            publisherEntity.Id = publisherManager.Create(publisherEntity);

            Assert.AreNotEqual(Guid.Empty, publisherEntity.Id);
        }

        [TestMethod]
        public void should_delete_publisher()
        {
            var publisherManager = new PublisherManager(CrmContext);

            //Get the publisher
            var publishers = publisherManager.RetrieveMultipleByAttributeExactValue(EntityAttributes.PublisherEntityAttributes.UniqueName, PUBLISHER_UNIQUE_NAME);

            //Delete publisher
            publisherManager.Delete(publishers.Entities.First().Id);

            //Try to get deleted publisher
            var publisher_after_delete = publisherManager.RetrieveMultipleByAttributeExactValue(EntityAttributes.PublisherEntityAttributes.UniqueName, PUBLISHER_UNIQUE_NAME); publisherManager.RetrieveMultipleByAttributeExactValue(EntityAttributes.PublisherEntityAttributes.UniqueName, PUBLISHER_UNIQUE_NAME); 

            //Make sure publisher is not retrieved after delete
            Assert.AreEqual(false, publisher_after_delete.Entities.Any());
        }
    }
}
