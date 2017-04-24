using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using Mjolnir.CRM.Sdk;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mjolnir.CRM.Sdk.Extensions;

namespace Mjolnir.CRM.Core
{
    public abstract class EntityManagerBase<TEntity>
        where TEntity : EntityBase, new()
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

        public void DeleteById(Guid id)
        {
            context.OrganizationService.Delete(entityLogicalName, id);
        }

        /// <summary>
        /// This method should be used only for small amount of data, pager is not implemented, works only for initial page of data.
        /// </summary>
        /// <returns>
        /// Failed Records
        /// </returns>
        /// <param name="conditions"></param>
        public EntityCollection DeleteMultipleByConditions(List<ConditionExpression> conditions)
        {
            EntityCollection failedRecords = new EntityCollection();

            var recordsToBeDeleted = RetrieveMultiple(conditions);

            if (recordsToBeDeleted != null && recordsToBeDeleted.Entities.Any())
            {
                foreach (var record in recordsToBeDeleted.Entities)
                {
                    try
                    {
                        context.OrganizationService.Delete(entityLogicalName, record.Id);
                    }
                    catch (Exception)
                    {
                        failedRecords.Entities.Add(record);
                    }
                }
            }

            return failedRecords;
        }


        public void Update(TEntity entity)
        {
            context.OrganizationService.Update(entity);
        }



        public TEntity RetrieveById(Guid id)
        {
            return RetrieveById(id, DefaultFields);
        }

        public TEntity RetrieveById(Guid id, string[] columns)
        {
            return RetrieveById(id, new ColumnSet(columns));
        }

        public TEntity RetrieveById(Guid id, ColumnSet columns)
        {
            context.TracingService.TraceVerbose("RetrieveById started.");

            if (columns == null || !columns.Columns.Any())
                columns = new ColumnSet(DefaultFields);

            try
            {
                return context.OrganizationService.Retrieve(entityLogicalName, id, columns).ToGenericEntity<TEntity>();

            }
            catch (Exception ex)
            {
                HandleException(ex);
                return null;
            }
        }

        

        public TEntity RetrieveFirst(List<ConditionExpression> conditions)
        {
            return RetrieveFirst(conditions, DefaultFields);
        }

        public TEntity RetrieveFirst(List<ConditionExpression> conditions, string[] columns)
        {
            return RetrieveFirst(conditions, new ColumnSet(columns));
        }

        public TEntity RetrieveFirst(List<ConditionExpression> conditions, ColumnSet columns)
        {
            if (columns == null || !columns.Columns.Any())
                columns = new ColumnSet(DefaultFields);

            var result = RetrieveMultiple(conditions, columns);

            if (result != null && result.Entities.Any())
                return result.Entities.First().ToGenericEntity<TEntity>();
            return null;
        }



        public TEntity RetrieveFirstByAttributeExactValue(string attributeName, object value)
        {
            return RetrieveFirstByAttributeExactValue(attributeName, value, DefaultFields);
        }

        public TEntity RetrieveFirstByAttributeExactValue(string attributeName, object value, string[] columns)
        {
            return RetrieveFirstByAttributeExactValue(attributeName, value, new ColumnSet(columns));
        }

        public TEntity RetrieveFirstByAttributeExactValue(string attributeName, object value, ColumnSet columns)
        {
            //TODO : Verbose trace
            if (columns == null || !columns.Columns.Any())
                columns = new ColumnSet(DefaultFields);

            var result = RetrieveMultipleByAttributeExactValue(attributeName, value, columns);

            if (result != null && result.Entities.Any())
                return result.Entities.First().ToGenericEntity<TEntity>();
            return null;
        }



        public EntityCollection RetrieveMultipleByAttributeExactValue(string attributeName, object value)
        {
            return RetrieveMultipleByAttributeExactValue(attributeName, value, DefaultFields);
        }

        public EntityCollection RetrieveMultipleByAttributeExactValue(string attributeName, object value, string[] columns)
        {
            return RetrieveMultipleByAttributeExactValue(attributeName, value, new ColumnSet(columns));
        }

        public EntityCollection RetrieveMultipleByAttributeExactValue(string attributeName, object value, ColumnSet columns)
        {
            //TODO : Verbose trace
            if (columns == null || !columns.Columns.Any())
                columns = new ColumnSet(DefaultFields);

            return RetrieveMultiple(new List<ConditionExpression>
                         {
                            new ConditionExpression(attributeName, ConditionOperator.Equal, value)
                         }, columns);
        }



        public EntityCollection RetrieveMultiple(string fetchXml)
        {
            return context.OrganizationService.RetrieveMultiple(new FetchExpression(fetchXml));
        }

        
        public EntityCollection RetrieveMultiple()
        {
            return RetrieveMultiple(DefaultFields);
        }

        public EntityCollection RetrieveMultiple(string[] columns)
        {
            return RetrieveMultiple( new ColumnSet(columns));
        }

        public EntityCollection RetrieveMultiple(ColumnSet columns)
        {
            return RetrieveMultiple(new List<ConditionExpression>(), columns);
        }
        
        
        public EntityCollection RetrieveMultiple(List<ConditionExpression> conditions)
        {
            return RetrieveMultiple(conditions, DefaultFields);
        }

        public EntityCollection RetrieveMultiple(List<ConditionExpression> conditions, string[] columns)
        {
            return RetrieveMultiple(conditions, new ColumnSet(columns));
        }

        public EntityCollection RetrieveMultiple(List<ConditionExpression> conditions, ColumnSet columns)
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
