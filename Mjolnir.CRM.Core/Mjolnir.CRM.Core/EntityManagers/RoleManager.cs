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


        public RoleEntity GetRoleByName(string roleName)
        {
            return GetRoleByName(roleName, DefaultFields);
        }

        public RoleEntity GetRoleByName(string roleName, string[] columns = null)
        {
            return GetRoleByName(roleName, new ColumnSet(columns));
        }

        public RoleEntity GetRoleByName(string roleName, ColumnSet columns = null)
        {
            var businessUnitEntityManager = new BusinessUnitManager(context);
            var roobBusinessUnit = businessUnitEntityManager.GetRootBusinessUnit();

            return GetRoleByName(roleName, roobBusinessUnit.Id, columns);
        }


        public RoleEntity GetRoleByName(string roleName, Guid businessUnitId)
        {
            return GetRoleByName(roleName, businessUnitId, DefaultFields);
        }

        public RoleEntity GetRoleByName(string roleName, Guid businessUnitId, string[] columns = null)
        {
            return GetRoleByName(roleName, businessUnitId, new ColumnSet(columns));
        }

        public RoleEntity GetRoleByName(string roleName, Guid businessUnitId, ColumnSet columns = null)
        {
            return RetrieveFirst(new List<ConditionExpression> {
                new ConditionExpression(EntityAttributes.RoleEntityAttributes.Name,ConditionOperator.Equal, roleName),
                new ConditionExpression(EntityAttributes.RoleEntityAttributes.BusinessUnitId,ConditionOperator.Equal, businessUnitId)
            }, columns);
        }


        public List<RoleEntity> GetAllRootLevelRoles()
        {
            return GetAllRootLevelRoles(DefaultFields);
        }

        public List<RoleEntity> GetAllRootLevelRoles(string[] columns = null)
        {
            return GetAllRootLevelRoles(new ColumnSet(columns));
        }

        public List<RoleEntity> GetAllRootLevelRoles(ColumnSet columns = null)
        {
            var businessUnitEntityManager = new BusinessUnitManager(context);
            var roobBusinessUnit = businessUnitEntityManager.GetRootBusinessUnit();

            return RetrieveMultiple(new List<ConditionExpression> {
                new ConditionExpression(EntityAttributes.RoleEntityAttributes.BusinessUnitId,ConditionOperator.Equal, roobBusinessUnit.Id)
            }, columns).ToList<RoleEntity>();
        }
        
    }
}
