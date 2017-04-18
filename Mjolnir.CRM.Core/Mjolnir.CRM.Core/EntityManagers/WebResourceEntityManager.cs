using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Mjolnir.CRM.SDK.Entities;
using Mjolnir.CRM.SDK.Optionsets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Mjolnir.CRM.Core.EntityManagers
{
    public class WebResourceEntityManager : EntityManagerBase<WebResourceEntity>
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

        public WebResourceEntityManager(CrmContext context)
            : base(context, EntityAttributes.WebResourceEntityAttributes.EntityName)
        { }


        public List<WebResourceEntity> GetAllWebResourcesMetadata(WebResourceType type)
        {
            context.TracingService.TraceVerbose("GetAllJavascriptWebResourcesMetadata started.");

            try
            {
                string[] retrieveColumns = new string[] {
                    EntityAttributes.WebResourceEntityAttributes.Name,
                    EntityAttributes.WebResourceEntityAttributes.DisplayName
                };

                QueryExpression query = new QueryExpression(EntityAttributes.WebResourceEntityAttributes.EntityName);
                query.ColumnSet = new ColumnSet(retrieveColumns);

                if (type != WebResourceType.All)
                    query.Criteria.AddCondition(new ConditionExpression(EntityAttributes.WebResourceEntityAttributes.WebResourceType, ConditionOperator.Equal, (int)type));

                var result = context.OrganizationService.RetrieveMultiple(query);

                if (result != null && result.Entities.Any())
                {
                    return result.Entities.Cast<WebResourceEntity>().ToList();
                }

                return null;
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return null;
            }
        }

        public string GetWebResourceContentById(Guid webResourceId)
        {
            context.TracingService.TraceVerbose("GetWebResourceContentById started.");

            try
            {
                string[] retrieveColumns = new string[] {
                    EntityAttributes.WebResourceEntityAttributes.Name,
                    EntityAttributes.WebResourceEntityAttributes.DisplayName,
                    EntityAttributes.WebResourceEntityAttributes.Content
                };

                var webResource = RetrieveById(webResourceId, retrieveColumns);

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

        public List<WebResourceEntity> GetWebResourcesContents(WebResourceType type)
        {
            context.TracingService.TraceVerbose("GetAllJavascriptWebResourcesMetadata started.");

            try
            {
                string[] retrieveColumns = new string[] {
                    EntityAttributes.WebResourceEntityAttributes.Name,
                    EntityAttributes.WebResourceEntityAttributes.DisplayName
                };

                QueryExpression query = new QueryExpression(EntityAttributes.WebResourceEntityAttributes.EntityName);
                query.ColumnSet = new ColumnSet(retrieveColumns);

                if (type != WebResourceType.All)
                    query.Criteria.AddCondition(new ConditionExpression(EntityAttributes.WebResourceEntityAttributes.WebResourceType, ConditionOperator.Equal, (int)type));

                var result = context.OrganizationService.RetrieveMultiple(query);

                if (result != null && result.Entities.Any())
                {
                    return result.Entities.Cast<WebResourceEntity>().ToList();
                }

                return null;
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return null;
            }
        }

    }
}
