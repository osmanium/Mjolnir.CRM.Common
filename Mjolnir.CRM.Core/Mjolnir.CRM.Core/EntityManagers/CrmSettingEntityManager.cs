using Mjolnir.CRM.Sdk.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Core.EntityManagers
{
    public class CrmSettingEntityManager : EntityManagerBase<CrmSettingEntity>
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

        public CrmSettingEntityManager(CrmContext context)
            : base(context, EntityAttributes.CrmSettingEntityAttributes.EntityName)
        {
        }

        public CrmSettingEntity GetCrmSettingByKey(string key)
        {
            var settings = RetrieveMultipleByAttributeExactValue(EntityAttributes.CrmSettingEntityAttributes.SettingKey, key);

            if (settings != null)
                return settings.Entities.First().ToEntity<CrmSettingEntity>();

            return null;
        }
    }
}
