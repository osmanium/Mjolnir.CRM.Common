using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Mjolnir.CRM.Sdk.Entities;
using Mjolnir.CRM.Sdk.Optionsets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Mjolnir.CRM.Sdk.Extensions;

namespace Mjolnir.CRM.Core.EntityManagers
{
    public class WebResourceManager : EntityManagerBase<WebResourceEntity>
    {
        internal override string[] DefaultFields
        {
            get
            {
                return new string[] {
                    EntityAttributes.WebResourceEntityAttributes.IdFieldName,
                    EntityAttributes.WebResourceEntityAttributes.Name,
                    EntityAttributes.WebResourceEntityAttributes.WebResourceType,
                    EntityAttributes.WebResourceEntityAttributes.DisplayName,
                    EntityAttributes.WebResourceEntityAttributes.Description,
                    EntityAttributes.WebResourceEntityAttributes.Content,
                };
            }
        }

        public WebResourceManager(CrmContext context)
            : base(context, EntityAttributes.WebResourceEntityAttributes.EntityName)
        { }


        public async Task<List<WebResourceEntity>> GetAllWebResourcesMetadataAsync(WebResourceType type)
        {
            context.TracingService.TraceVerbose("GetAllWebResourcesMetadataAsync started.");

            try
            {
                string[] retrieveColumns = new string[] {
                    EntityAttributes.WebResourceEntityAttributes.Name,
                    EntityAttributes.WebResourceEntityAttributes.DisplayName,
                    EntityAttributes.WebResourceEntityAttributes.Description,
                    EntityAttributes.WebResourceEntityAttributes.WebResourceType
                };

                QueryExpression query = new QueryExpression(EntityAttributes.WebResourceEntityAttributes.EntityName);
                query.ColumnSet = new ColumnSet(retrieveColumns);

                if (type != WebResourceType.All)
                    query.Criteria.AddCondition(new ConditionExpression(EntityAttributes.WebResourceEntityAttributes.WebResourceType, ConditionOperator.Equal, (int)type));

                //TODO : Make here async
                var result = await RetrieveMultipleAsync(query);

                if (result != null && result.Entities.Any())
                {
                    //TODO : Return ToListAsync version
                    return result.Entities.Select(s => s.ToSpecificEntity<WebResourceEntity>()).ToList();
                }

                return null;
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return null;
            }
        }

        public async Task<string> GetWebResourceContentByIdAsync(Guid webResourceId)
        {
            context.TracingService.TraceVerbose("GetWebResourceContentByIdAsync started.");

            try
            {
                string[] retrieveColumns = new string[] {
                    EntityAttributes.WebResourceEntityAttributes.Name,
                    EntityAttributes.WebResourceEntityAttributes.DisplayName,
                    EntityAttributes.WebResourceEntityAttributes.Content
                };

                var webResource = await RetrieveByIdAsync(webResourceId, retrieveColumns);

                if (webResource != null)
                {
                    return webResource.Content;
                }

                return null;
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return null;
            }
        }

        public async Task<List<WebResourceEntity>> GetWebResourcesContentsByIdsAsync(string[] webResourceIds)
        {
            context.TracingService.TraceVerbose("GetWebResourcesContentsByIdsAsync started.");

            try
            {
                string[] retrieveColumns = new string[] {
                    EntityAttributes.WebResourceEntityAttributes.Name,
                    EntityAttributes.WebResourceEntityAttributes.DisplayName,
                    EntityAttributes.WebResourceEntityAttributes.Content,
                    EntityAttributes.WebResourceEntityAttributes.WebResourceType,
                };

                QueryExpression query = new QueryExpression(EntityAttributes.WebResourceEntityAttributes.EntityName);
                query.ColumnSet = new ColumnSet(retrieveColumns);

                query.Criteria.AddCondition(EntityAttributes.WebResourceEntityAttributes.IdFieldName, ConditionOperator.In, webResourceIds);

                var result = await RetrieveMultipleAsync(query);

                if (result != null && result.Entities.Any())
                {
                    return result.Entities.Select(s => s.ToSpecificEntity<WebResourceEntity>()).ToList();
                }

                return null;
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return null;
            }
        }

        public async Task<WebResourceEntity> GetWebResourceBySchemaNameAsync(string webResourceSchemaName)
        {
            return await RetrieveFirstByAttributeExactValueAsync(EntityAttributes.WebResourceEntityAttributes.Name, webResourceSchemaName);
        }
    }
}
