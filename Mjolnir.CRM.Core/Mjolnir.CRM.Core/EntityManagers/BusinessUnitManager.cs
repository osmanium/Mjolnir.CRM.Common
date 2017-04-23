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
    public class BusinessUnitManager : EntityManagerBase<BusinessUnitEntity>
    {
        internal override string[] DefaultFields
        {
            get
            {
                return new string[] {
                    EntityAttributes.BusinessUnitEntityAttributes.IdFieldName,
                    EntityAttributes.BusinessUnitEntityAttributes.Name,
                    EntityAttributes.BusinessUnitEntityAttributes.ParentBusinessUnitId
                };
            }
        }

        public BusinessUnitManager(CrmContext context)
            : base(context, EntityAttributes.BusinessUnitEntityAttributes.EntityName)
        { }

        public BusinessUnitEntity GetBusinessUnitByName(string businessUnitName)
        {
            return RetrieveFirstByAttributeExactValue(EntityAttributes.BusinessUnitEntityAttributes.Name, businessUnitName);
        }

        public BusinessUnitEntity GetRootBusinessUnit()
        {
            return RetrieveFirst(new List<ConditionExpression>()
            {
                new ConditionExpression(EntityAttributes.BusinessUnitEntityAttributes.ParentBusinessUnitId, ConditionOperator.Null)
            });
        }
    }
}
