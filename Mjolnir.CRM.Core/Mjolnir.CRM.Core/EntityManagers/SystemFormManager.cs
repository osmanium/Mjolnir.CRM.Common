using Microsoft.Xrm.Sdk.Query;
using Mjolnir.CRM.Sdk.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mjolnir.CRM.Sdk.Extensions;

namespace Mjolnir.CRM.Core.EntityManagers
{
    public class SystemFormManager : EntityManagerBase<SystemFormEntity>
    {
        internal override string[] DefaultFields
        {
            get
            {
                return new string[] {
                    EntityAttributes.SystemFormEntityAttributes.IdFieldName,
                    EntityAttributes.SystemFormEntityAttributes.Name,
                    EntityAttributes.SystemFormEntityAttributes.FormActivationState,
                    EntityAttributes.SystemFormEntityAttributes.IsManaged,
                    EntityAttributes.SystemFormEntityAttributes.PublishedOn,
                    EntityAttributes.SystemFormEntityAttributes.Type,
                    EntityAttributes.SystemFormEntityAttributes.UniqueName
                };
            }
        }

        public SystemFormManager(CrmContext context)
            : base(context, EntityAttributes.SystemFormEntityAttributes.EntityName)
        { }


        public async Task<List<SystemFormEntity>> GetAllSystemFormsByEntitySchemaNameAsync(string entitySchemaName)
        {
            context.TracingService.TraceVerbose("GetAllSystemFormsByEntitySchemaNameAsync started.");

            try
            {

                EntityMetadataManager entityMetadataManager = new EntityMetadataManager(context);
                var entityMetadata = await entityMetadataManager.GetEntityMetadataByEntitySchemaName(entitySchemaName);
                var objectTypeCode = entityMetadata.ObjectTypeCode;

                //ObjectTypecode field can be queried by schema name even though it returns string
                var result = RetrieveMultipleByAttributeExactValue(EntityAttributes.SystemFormEntityAttributes.ObjectTypeCode, objectTypeCode);

                if (result != null && result.Entities.Any())
                {
                    //TODO : Return ToListAsync version
                    return result.Entities.Select(s => s.ToSpecificEntity<SystemFormEntity>()).ToList();
                }

                return null;
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return null;
            }
        }

        public async Task<SystemFormEntity> GetSystemFormByEntitySchemaNameAndFormNameAsync(string entitySchemaName, string formName)
        {
            context.TracingService.TraceVerbose("GetSystemFormByEntitySchemaNameAndFormNameAsync started.");

            try
            {

                EntityMetadataManager entityMetadataManager = new EntityMetadataManager(context);
                var entityMetadata = await entityMetadataManager.GetEntityMetadataByEntitySchemaName(entitySchemaName);
                var objectTypeCode = entityMetadata.ObjectTypeCode;

                var result = await RetrieveMultipleAsync(new List<ConditionExpression>()
                {
                    //ObjectTypecode field can be queried by schema name even though it returns string
                    new ConditionExpression(EntityAttributes.SystemFormEntityAttributes.ObjectTypeCode, ConditionOperator.Equal,objectTypeCode),
                    new ConditionExpression(EntityAttributes.SystemFormEntityAttributes.Name, ConditionOperator.Equal,formName)
                });


                if (result != null && result.Entities.Any())
                {
                    return result.Entities.First().ToSpecificEntity<SystemFormEntity>();
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
