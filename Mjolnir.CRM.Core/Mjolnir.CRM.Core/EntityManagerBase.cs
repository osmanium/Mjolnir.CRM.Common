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
        

        //public async Task<EntityCollection> RetrieveMultipleAsync(QueryBase query)
        //{
        //    var t = Task.Factory.StartNew(() =>
        //    {
        //        var response = context.OrganizationService.RetrieveMultiple(query);
        //        return response;
        //    });

        //    return await t;
        //}



        //public async Task AssociateAsync(string entityName, Guid entityId, Relationship relationship, EntityReferenceCollection relatedEntities)
        //{
        //    var t = Task.Factory.StartNew(() =>
        //    {
        //        context.OrganizationService.Associate(entityName, entityId, relationship, relatedEntities);
        //    });

        //    await t;
        //}
        //public async Task DisassociateAsync(string entityName, Guid entityId, Relationship relationship, EntityReferenceCollection relatedEntities)
        //{
        //    var t = Task.Factory.StartNew(() =>
        //    {
        //        context.OrganizationService.Disassociate(entityName, entityId, relationship, relatedEntities);
        //    });

        //    await t;
        //}
    

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
        public async Task<Guid> CreateAsync(TEntity entity)
        {
            var t = Task.Factory.StartNew(() =>
            {
                return Create(entity);
            });

            return await t;
        }


        public void DeleteById(Guid id)
        {
            context.OrganizationService.Delete(entityLogicalName, id);
        }
        public async Task DeleteByIdAsync(Guid id)
        {
            var t = Task.Factory.StartNew(() =>
            {
                DeleteById(id);
            });

            await t;
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
        public async Task<EntityCollection> DeleteMultipleByConditionsAsync(List<ConditionExpression> conditions)
        {
            var t = Task.Factory.StartNew(() =>
            {
                return DeleteMultipleByConditions(conditions);
            });

            return await t;
        }


        public void Update(TEntity entity)
        {
            context.OrganizationService.Update(entity);
        }
        public async Task UpdateAsync(TEntity entity)
        {
            var t = Task.Factory.StartNew(() =>
            {
                Update(entity);
            });

            await t;
        }


        public TEntity RetrieveById(Guid id)
        {
            return RetrieveById(id, DefaultFields);
        }
        public async Task<TEntity> RetrieveByIdAsync(Guid id)
        {
            var t = Task.Factory.StartNew(() =>
            {
                return RetrieveById(id);
            });

            return await t;
        }

        public TEntity RetrieveById(Guid id, string[] columns)
        {
            return RetrieveById(id, new ColumnSet(columns));
        }
        public async Task<TEntity> RetrieveByIdAsync(Guid id, string[] columns)
        {
            var t = Task.Factory.StartNew(() =>
            {
                return RetrieveById(id, columns);
            });

            return await t;
        }

        public TEntity RetrieveById(Guid id, ColumnSet columns)
        {
            context.TracingService.TraceVerbose("RetrieveById started.");

            if (columns == null || !columns.Columns.Any())
                columns = new ColumnSet(DefaultFields);

            try
            {
                return context.OrganizationService.Retrieve(entityLogicalName, id, columns).ToSpecificEntity<TEntity>();

            }
            catch (Exception ex)
            {
                HandleException(ex);
                return null;
            }
        }
        public async Task<TEntity> RetrieveByIdAsync(Guid id, ColumnSet columns)
        {
            var t = Task.Factory.StartNew(() =>
            {
                return RetrieveById(id, columns);
            });

            return await t;
        }


        public TEntity RetrieveFirst(List<ConditionExpression> conditions)
        {
            return RetrieveFirst(conditions, DefaultFields);
        }
        public async Task<TEntity> RetrieveFirstAsync(List<ConditionExpression> conditions)
        {
            var t = Task.Factory.StartNew(() =>
            {
                return RetrieveFirst(conditions);
            });

            return await t;
        }

        public TEntity RetrieveFirst(List<ConditionExpression> conditions, string[] columns)
        {
            return RetrieveFirst(conditions, new ColumnSet(columns));
        }
        public async Task<TEntity> RetrieveFirstAsync(List<ConditionExpression> conditions, string[] columns)
        {
            var t = Task.Factory.StartNew(() =>
            {
                return RetrieveFirst(conditions, columns);
            });

            return await t;
        }

        public TEntity RetrieveFirst(List<ConditionExpression> conditions, ColumnSet columns)
        {
            if (columns == null || !columns.Columns.Any())
                columns = new ColumnSet(DefaultFields);

            var result = RetrieveMultiple(conditions, columns);

            if (result != null && result.Entities.Any())
                return result.Entities.First().ToSpecificEntity<TEntity>();
            return null;
        }
        public async Task<TEntity> RetrieveFirstAsync(List<ConditionExpression> conditions, ColumnSet columns)
        {
            var t = Task.Factory.StartNew(() =>
            {
                return RetrieveFirst(conditions, columns);
            });

            return await t;
        }


        public TEntity RetrieveFirstByAttributeExactValue(string attributeName, object value)
        {
            return RetrieveFirstByAttributeExactValue(attributeName, value, DefaultFields);
        }
        public async Task<TEntity> RetrieveFirstByAttributeExactValueAsync(string attributeName, object value)
        {
            var t = Task.Factory.StartNew(() =>
            {
                return RetrieveFirstByAttributeExactValue(attributeName, value);
            });

            return await t;
        }

        public TEntity RetrieveFirstByAttributeExactValue(string attributeName, object value, string[] columns)
        {
            return RetrieveFirstByAttributeExactValue(attributeName, value, new ColumnSet(columns));
        }
        public async Task<TEntity> RetrieveFirstByAttributeExactValueAsync(string attributeName, object value, string[] columns)
        {
            var t = Task.Factory.StartNew(() =>
            {
                return RetrieveFirstByAttributeExactValue(attributeName, value, columns);
            });

            return await t;
        }

        public TEntity RetrieveFirstByAttributeExactValue(string attributeName, object value, ColumnSet columns)
        {
            //TODO : Verbose trace
            if (columns == null || !columns.Columns.Any())
                columns = new ColumnSet(DefaultFields);

            var result = RetrieveMultipleByAttributeExactValue(attributeName, value, columns);

            if (result != null && result.Entities.Any())
                return result.Entities.First().ToSpecificEntity<TEntity>();
            return null;
        }
        public async Task<TEntity> RetrieveFirstByAttributeExactValueAsync(string attributeName, object value, ColumnSet columns)
        {
            var t = Task.Factory.StartNew(() =>
            {
                return RetrieveFirstByAttributeExactValue(attributeName, value, columns);
            });

            return await t;
        }


        //TODO : Change all EntitiCollection return types to List<TEntity>

        public EntityCollection RetrieveMultipleByAttributeExactValue(string attributeName, object value)
        {
            return RetrieveMultipleByAttributeExactValue(attributeName, value, DefaultFields);
        }
        public async Task<EntityCollection> RetrieveMultipleByAttributeExactValueAsync(string attributeName, object value)
        {
            var t = Task.Factory.StartNew(() =>
            {
                return RetrieveMultipleByAttributeExactValue(attributeName, value);
            });

            return await t;
        }

        public EntityCollection RetrieveMultipleByAttributeExactValue(string attributeName, object value, string[] columns)
        {
            return RetrieveMultipleByAttributeExactValue(attributeName, value, new ColumnSet(columns));
        }
        public async Task<EntityCollection> RetrieveMultipleByAttributeExactValueAsync(string attributeName, object value, string[] columns)
        {
            var t = Task.Factory.StartNew(() =>
            {
                return RetrieveMultipleByAttributeExactValue(attributeName, value, columns);
            });

            return await t;
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
        public async Task<EntityCollection> RetrieveMultipleByAttributeExactValueAsync(string attributeName, object value, ColumnSet columns)
        {
            var t = Task.Factory.StartNew(() =>
            {
                return RetrieveMultipleByAttributeExactValue(attributeName, value, columns);
            });

            return await t;
        }


        public EntityCollection RetrieveMultiple(string fetchXml)
        {
            return context.OrganizationService.RetrieveMultiple(new FetchExpression(fetchXml));
        }
        public async Task<EntityCollection> RetrieveMultipleAsync(string fetchXml)
        {
            var t = Task.Factory.StartNew(() =>
            {
                return RetrieveMultiple(fetchXml);
            });

            return await t;
        }


        public EntityCollection RetrieveMultiple(QueryExpression query)
        {
            return context.OrganizationService.RetrieveMultiple(query);
        }
        public async Task<EntityCollection> RetrieveMultipleAsync(QueryExpression query)
        {
            var t = Task.Factory.StartNew(() =>
            {
                return RetrieveMultiple(query);
            });

            return await t;
        }


        public EntityCollection RetrieveMultiple()
        {
            return RetrieveMultiple(DefaultFields);
        }
        public async Task<EntityCollection> RetrieveMultipleAsync()
        {
            var t = Task.Factory.StartNew(() =>
            {
                return RetrieveMultiple();
            });

            return await t;
        }

        public EntityCollection RetrieveMultiple(string[] columns)
        {
            return RetrieveMultiple(new ColumnSet(columns));
        }
        public async Task<EntityCollection> RetrieveMultipleAsync(string[] columns)
        {
            var t = Task.Factory.StartNew(() =>
            {
                return RetrieveMultiple(columns);
            });

            return await t;
        }

        public EntityCollection RetrieveMultiple(ColumnSet columns)
        {
            return RetrieveMultiple(new List<ConditionExpression>(), columns);
        }
        public async Task<EntityCollection> RetrieveMultipleAsync(ColumnSet columns)
        {
            var t = Task.Factory.StartNew(() =>
            {
                return RetrieveMultiple(columns);
            });

            return await t;
        }


        public EntityCollection RetrieveMultiple(List<ConditionExpression> conditions)
        {
            return RetrieveMultiple(conditions, DefaultFields);
        }
        public async Task<EntityCollection> RetrieveMultipleAsync(List<ConditionExpression> conditions)
        {
            return await Task.Factory.StartNew(() => RetrieveMultiple(conditions));
        }

        public EntityCollection RetrieveMultiple(List<ConditionExpression> conditions, string[] columns)
        {
            return RetrieveMultiple(conditions, new ColumnSet(columns));
        }
        public async Task<EntityCollection> RetrieveMultipleAsync(List<ConditionExpression> conditions, string[] columns)
        {
            return await Task.Factory.StartNew(() => RetrieveMultiple(conditions, columns));
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
        public async Task<EntityCollection> RetrieveMultipleAsync(List<ConditionExpression> conditions, ColumnSet columns)
        {
            var t = Task.Factory.StartNew(() =>
            {
                return RetrieveMultiple(conditions, columns);
            });

            return await t;
        }


        public void HandleException(Exception ex)
        {
            //TODO : Use trace wrapper
            context.TracingService.TraceError(ex.Message + "\n" + ex.StackTrace + "\n");
        }
    }
}
