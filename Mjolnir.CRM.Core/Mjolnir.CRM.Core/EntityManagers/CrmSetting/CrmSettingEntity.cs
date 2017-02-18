using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Core.EntityManagers
{
    public static partial class EntityAttributes
    {
        public static class CrmSettingEntityAttributes
        {
            public const string EntityName = "mjolnir_crmsetting";

            public const string SettingKey = "mjolnir_settingkey";

            public const string IntSetting = "mjolnir_intsetting";
            public const string StringSetting = "mjolnir_stringsetting";
            public const string DecimalSetting = "mjolnir_decimalsetting";
            public const string MoneySetting = "mjolnir_moneysetting";
            public const string BoolSetting = "mjolnir_boolsetting";
            public const string DateTimeSetting = "mjolnir_datetimesetting";


            public const string BusinessUnitSettingEntityReference = "mjolnir_crmSettingManager";
            public const string SystemUserSettingEntityReference = "mjolnir_systemusersetting";

            public const string TraceLevelSettingOptionSet = "mjolnir_crmtracelevelsetting";

        }
    }

    public class CrmSettingEntity : EntityBase
    {
        public CrmSettingEntity()
            : base(EntityAttributes.CrmSettingEntityAttributes.EntityName)
        {
        }

        public string SettingKey
        {
            get
            {
                return GetStringAttributeValue(EntityAttributes.CrmSettingEntityAttributes.SettingKey);
            }
            set
            {
                Attributes[EntityAttributes.CrmSettingEntityAttributes.SettingKey] = value;
            }
        }
        
        public int IntSetting
        {
            get
            {
                return GetIntigerAttributeValue(EntityAttributes.CrmSettingEntityAttributes.IntSetting);
            }
            set
            {
                Attributes[EntityAttributes.CrmSettingEntityAttributes.IntSetting] = value;
            }
        }

        public string StringSetting
        {
            get
            {
                return GetStringAttributeValue(EntityAttributes.CrmSettingEntityAttributes.StringSetting);
            }
            set
            {
                Attributes[EntityAttributes.CrmSettingEntityAttributes.StringSetting] = value;
            }
        }

        public decimal DecimalSetting
        {
            get
            {
                return GetDecimalAttributeValue(EntityAttributes.CrmSettingEntityAttributes.DecimalSetting);
            }
            set
            {
                Attributes[EntityAttributes.CrmSettingEntityAttributes.DecimalSetting] = value;
            }
        }

        public Money MoneySetting
        {
            get
            {
                return GetMoneyAttributeValue(EntityAttributes.CrmSettingEntityAttributes.MoneySetting);
            }
            set
            {
                Attributes[EntityAttributes.CrmSettingEntityAttributes.MoneySetting] = value;
            }
        }

        public bool BoolSetting
        {
            get
            {
                return GetBoolAttributeValue(EntityAttributes.CrmSettingEntityAttributes.BoolSetting);
            }
            set
            {
                Attributes[EntityAttributes.CrmSettingEntityAttributes.BoolSetting] = value;
            }
        }

        public DateTime DateTimeSetting
        {
            get
            {
                return GetDateTimeAttributeValue(EntityAttributes.CrmSettingEntityAttributes.DateTimeSetting);
            }
            set
            {
                Attributes[EntityAttributes.CrmSettingEntityAttributes.DateTimeSetting] = value;
            }
        }

        public EntityReference SystemUserSettingEntityReference
        {
            get
            {
                return GetEntityReferenceAttributeValue(EntityAttributes.CrmSettingEntityAttributes.SystemUserSettingEntityReference);
            }
            set
            {
                Attributes[EntityAttributes.CrmSettingEntityAttributes.SystemUserSettingEntityReference] = value;
            }
        }

        public int BusinessUnitSetting
        {
            get
            {
                return GetIntigerAttributeValue(EntityAttributes.CrmSettingEntityAttributes.BusinessUnitSettingEntityReference);
            }
            set
            {
                Attributes[EntityAttributes.CrmSettingEntityAttributes.BusinessUnitSettingEntityReference] = value;
            }
        }

        public OptionSetValue TraceLevelSettingOptionSet
        {
            get
            {
                return GetOptionSetValueAttributeValue(EntityAttributes.CrmSettingEntityAttributes.TraceLevelSettingOptionSet);
            }
            set
            {
                Attributes[EntityAttributes.CrmSettingEntityAttributes.TraceLevelSettingOptionSet] = value;
            }
        }
    }
}
