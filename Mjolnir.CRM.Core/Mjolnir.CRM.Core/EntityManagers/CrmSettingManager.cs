using Mjolnir.CRM.Sdk.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mjolnir.CRM.Sdk.Extensions;

namespace Mjolnir.CRM.Core.EntityManagers
{
    public class CrmSettingManager : EntityManagerBase<CrmSettingEntity>
    {
        internal override string[] DefaultFields
        {
            get
            {
                return new string[] {
                    EntityAttributes.CrmSettingEntityAttributes.SettingKey,
                    EntityAttributes.CrmSettingEntityAttributes.BoolSetting,
                    EntityAttributes.CrmSettingEntityAttributes.DateTimeSetting,
                    EntityAttributes.CrmSettingEntityAttributes.DecimalSetting,
                    EntityAttributes.CrmSettingEntityAttributes.IntSetting,
                    EntityAttributes.CrmSettingEntityAttributes.MoneySetting,
                    EntityAttributes.CrmSettingEntityAttributes.StringSetting,
                    EntityAttributes.CrmSettingEntityAttributes.SystemUserSettingEntityReference,
                    EntityAttributes.CrmSettingEntityAttributes.BusinessUnitSettingEntityReference,
                    EntityAttributes.CrmSettingEntityAttributes.TraceLevelSettingOptionSet
                };
            }
        }

        public CrmSettingManager(CrmContext context)
            : base(context, EntityAttributes.CrmSettingEntityAttributes.EntityName)
        {
        }

        public CrmSettingEntity GetCrmSettingByKey(string key)
        {
            return RetrieveFirstByAttributeExactValue(EntityAttributes.CrmSettingEntityAttributes.SettingKey, key);
        }
    }
}
