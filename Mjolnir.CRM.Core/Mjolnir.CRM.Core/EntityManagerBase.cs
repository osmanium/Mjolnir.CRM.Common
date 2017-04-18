using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using Mjolnir.CRM.SDK;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Core
{
    public abstract class EntityManagerBase<TEntity>
        where TEntity : EntityBase
    {
        internal CrmContext context = null;
        internal string entityLogicalName = string.Empty;

        internal abstract string[] DefaultFields { get; }

        public EntityManagerBase(CrmContext context, string entityLogicalName)
        {
            this.context = context;
            this.entityLogicalName = entityLogicalName;
        }


        public Guid Create(TEntity entity)
        {
            context.TracingService.TraceVerbose("Create started.");

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

        public void Update(TEntity entity)
        {
            context.OrganizationService.Update(entity);
        }

        public TEntity RetrieveById(Guid id, ColumnSet columns = null)
        {
            context.TracingService.TraceVerbose("RetrieveById started.");

            if (columns == null || !columns.Columns.Any())
                columns = new ColumnSet(DefaultFields);

            try
            {
                return context.OrganizationService.Retrieve(entityLogicalName, id, columns).ToEntity<TEntity>();

            }
            catch (Exception ex)
            {
                HandleException(ex);
                return null;
            }
        }

        public TEntity RetrieveById(Guid id, string[] columns = null)
        {
            if (columns != null)
                return RetrieveById(id, new ColumnSet(columns));
            else
                return RetrieveById(id, new ColumnSet(DefaultFields));
        }


        public EntityCollection RetrieveMultipleByAttributeExactValue(string attributeName, object value, ColumnSet columns = null)
        {
            //TODO : Verbose trace
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
            //TODO : Use trace wrapper
            context.TracingService.TraceError(ex.Message + "\n" + ex.StackTrace + "\n");
        }
    }
}
