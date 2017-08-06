using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Mjolnir.CRM.Sdk.Entities;
using Mjolnir.CRM.Sdk.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Core.EntityManagers
{
    public class EntityMetadataManager : OrganizationServiceCore
    {
        public EntityMetadataManager(CrmContext context)
            : base(context)
        { }


        public async Task<EntityMetadata> GetEntityMetadataByEntitySchemaName(string entitySchemaName, EntityFilters filter = EntityFilters.All)
        {
            var retrieveRequest = new RetrieveEntityRequest()
            {
                EntityFilters = filter,
                LogicalName = entitySchemaName
            };

            var response = await ExecuteAsync<RetrieveEntityResponse>(retrieveRequest);

            return response.EntityMetadata;
        }

        public async Task<EntityMetadata> GetEntityMetadataByEntityDisplayName(string entityDisplayName, EntityFilters filter = EntityFilters.All)
        {
            var retrieveRequest = new RetrieveAllEntitiesRequest()
            {
                EntityFilters = filter,
                RetrieveAsIfPublished = true
            };

            var response = await ExecuteAsync<RetrieveAllEntitiesResponse>(retrieveRequest);

            if (response != null && response.EntityMetadata.Any())
            {
                foreach (var entityMetadata in response.EntityMetadata)
                {
                    var match = entityMetadata
                                    .DisplayName
                                    .LocalizedLabels
                                    .Where(w => w.Label.Equals(entityDisplayName, StringComparison.InvariantCultureIgnoreCase));

                    if (match != null && match.Any())
                        return entityMetadata;
                }
            }

            return null;
        }
    }
}
