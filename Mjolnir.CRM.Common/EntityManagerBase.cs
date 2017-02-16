using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Common
{
    public abstract class EntityManagerBase
    {
        internal CRMContext context = null;
        internal string entityLogicalName = string.Empty;

        internal abstract string[] DefaultFields { get; }

        public EntityManagerBase(CRMContext context, string entityLogicalName)
        {
            this.context = context;
            this.entityLogicalName = entityLogicalName;
        }


        public Guid Create(Entity entity)
        {
            context.TracingService.Trace("CreatePublisher started.");

            try
            {
                if (string.IsNullOrWhiteSpace(entity.LogicalName))
                    entity.LogicalName = entityLogicalName;

                if (entity.LogicalName != entityLogicalName)
                    throw new CrmBusinessException("Entity logical name is different than what was initiated.");

                return context.OrganizationService.Create(entity);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return Guid.Empty;
            }
        }

        public void Delete(Guid id)
        {
            context.OrganizationService.Delete(entityLogicalName, id);
        }

        public void Update(Entity entity)
        {
            context.OrganizationService.Update(entity);
        }

        public Entity RetrieveById(Guid id, ColumnSet columns = null)
        {
            if (columns == null || !columns.Columns.Any())
                columns = new ColumnSet(DefaultFields);

            return context.OrganizationService.Retrieve(entityLogicalName, id, columns);
        }

        public EntityCollection RetrieveMultipleByAttributeExactValue(string attributeName, object value, ColumnSet columns = null)
        {
            if (columns == null || !columns.Columns.Any())
                columns = new ColumnSet(DefaultFields);

            QueryExpression query = new QueryExpression(entityLogicalName);
            query.ColumnSet = columns;
            query.Criteria.AddCondition(new ConditionExpression(attributeName, ConditionOperator.Equal, value));

            return context.OrganizationService.RetrieveMultiple(query);
        }

        public EntityCollection RetrieveMultiple(List<ConditionExpression> conditions, ColumnSet columns = null)
        {
            if (columns == null || !columns.Columns.Any())
                columns = new ColumnSet(DefaultFields);

            QueryExpression query = new QueryExpression(entityLogicalName);
            query.ColumnSet = columns;

            foreach (var condition in conditions)
            {
                query.Criteria.AddCondition(condition);
            }

            return context.OrganizationService.RetrieveMultiple(query);
        }



        public void HandleException(Exception ex)
        {
            context.TracingService.Trace(ex.Message + "\n" + ex.StackTrace + "\n");
        }
    }
}
