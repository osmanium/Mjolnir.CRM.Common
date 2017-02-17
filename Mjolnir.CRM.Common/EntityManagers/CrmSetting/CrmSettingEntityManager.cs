using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Common.EntityManagers
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
                };
            }
        }

        public CrmSettingEntityManager(CrmContext context) 
            : base(context, EntityAttributes.CrmSettingEntityAttributes.EntityName)
        {
        }
    }
}
