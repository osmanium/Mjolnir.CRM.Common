using Mjolnir.CRM.Sdk.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mjolnir.CRM.Sdk.Extensions;
using Microsoft.Xrm.Sdk.Query;

namespace Mjolnir.CRM.Core.EntityManagers
{
    public class RoleManager : EntityManagerBase<RoleEntity>
    {
        internal override string[] DefaultFields
        {
            get
            {
                return new string[] {
                    EntityAttributes.RoleEntityAttributes.IdFieldName,
                    EntityAttributes.RoleEntityAttributes.BusinessUnitId,
                    EntityAttributes.RoleEntityAttributes.IsManaged,
                    EntityAttributes.RoleEntityAttributes.IsCustomizable,
                    EntityAttributes.RoleEntityAttributes.Name,
                    EntityAttributes.RoleEntityAttributes.ParentRoleId,
                    EntityAttributes.RoleEntityAttributes.ParentRootRoleId,
                    EntityAttributes.RoleEntityAttributes.RoleTemplateId,
                    EntityAttributes.RoleEntityAttributes.SolutionId,
                };
            }
        }

        public RoleManager(CrmContext context)
            : base(context, EntityAttributes.RoleEntityAttributes.EntityName)
        { }


        public async Task<RoleEntity> GetRoleByNameAsync(string roleName)
        {
            return await GetRoleByNameAsync(roleName, DefaultFields);
        }

        public async Task<RoleEntity> GetRoleByNameAsync(string roleName, string[] columns = null)
        {
            return await GetRoleByNameAsync(roleName, new ColumnSet(columns));
        }

        public async Task<RoleEntity> GetRoleByNameAsync(string roleName, ColumnSet columns = null)
        {
            var businessUnitEntityManager = new BusinessUnitManager(context);
            var rootBusinessUnit = await businessUnitEntityManager.GetRootBusinessUnitAsync();

            return await GetRoleByNameAsync(roleName, rootBusinessUnit.Id, columns);
        }


        public async Task<RoleEntity> GetRoleByNameAsync(string roleName, Guid businessUnitId)
        {
            return await GetRoleByNameAsync(roleName, businessUnitId, DefaultFields);
        }

        public async Task<RoleEntity> GetRoleByNameAsync(string roleName, Guid businessUnitId, string[] columns = null)
        {
            return await GetRoleByNameAsync(roleName, businessUnitId, new ColumnSet(columns));
        }

        public async Task<RoleEntity> GetRoleByNameAsync(string roleName, Guid businessUnitId, ColumnSet columns = null)
        {
            return await RetrieveFirstAsync(new List<ConditionExpression> {
                new ConditionExpression(EntityAttributes.RoleEntityAttributes.Name,ConditionOperator.Equal, roleName),
                new ConditionExpression(EntityAttributes.RoleEntityAttributes.BusinessUnitId,ConditionOperator.Equal, businessUnitId)
            }, columns);
        }


        public async Task<List<RoleEntity>> GetAllRootLevelRolesAsync()
        {
            return await GetAllRootLevelRolesAsync(DefaultFields);
        }

        public async Task<List<RoleEntity>> GetAllRootLevelRolesAsync(string[] columns = null)
        {
            return await GetAllRootLevelRolesAsync(new ColumnSet(columns));
        }

        public async Task<List<RoleEntity>> GetAllRootLevelRolesAsync(ColumnSet columns = null)
        {
            var businessUnitEntityManager = new BusinessUnitManager(context);
            var roobBusinessUnit = await businessUnitEntityManager.GetRootBusinessUnitAsync();

            var task = await RetrieveMultipleAsync(new List<ConditionExpression> {
                new ConditionExpression(EntityAttributes.RoleEntityAttributes.BusinessUnitId,ConditionOperator.Equal, roobBusinessUnit.Id)
            }, columns);

            return task.ToList<RoleEntity>();
        }

    }
}
