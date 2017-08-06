using Mjolnir.CRM.Sdk.Optionsets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Sdk.Entities
{
    public static partial class EntityAttributes
    {
        public static class SystemFormEntityAttributes
        {
            public const string EntityName = "systemform";
            public const string IdFieldName = "formid";
            public const string Name = "name";
            public const string Type = "type";
            public const string UniqueName = "uniquename";
            public const string PublishedOn = "publishedon";
            public const string ObjectTypeCode = "objecttypecode";
            public const string IsManaged = "ismanaged";
            public const string FormActivationState = "formactivationstate";
        }
    }

    public class SystemFormEntity : EntityBase
    {
        public SystemFormEntity()
                : base(EntityAttributes.SystemFormEntityAttributes.EntityName)
        {

        }

        public Guid? IdFieldName
        {
            get
            {
                return GetGuidAttributeValue(EntityAttributes.SystemFormEntityAttributes.IdFieldName);
            }
            set
            {
                Attributes[EntityAttributes.SystemFormEntityAttributes.IdFieldName] = value;
            }
        }

        public string Name
        {
            get
            {
                return GetStringAttributeValue(EntityAttributes.SystemFormEntityAttributes.Name);
            }
            set
            {
                Attributes[EntityAttributes.SystemFormEntityAttributes.Name] = value;
            }
        }

        public SystemFormType? Type
        {
            get
            {
                return (SystemFormType)GetOptionSetValueAttributeValue(EntityAttributes.SystemFormEntityAttributes.Type).Value;
            }
            set
            {
                Attributes[EntityAttributes.SystemFormEntityAttributes.Type] = value;
            }
        }

        public string UniqueName
        {
            get
            {
                return GetStringAttributeValue(EntityAttributes.SystemFormEntityAttributes.UniqueName);
            }
            set
            {
                Attributes[EntityAttributes.SystemFormEntityAttributes.UniqueName] = value;
            }
        }

        public DateTime? PublishedOn
        {
            get
            {
                return GetDateTimeAttributeValue(EntityAttributes.SystemFormEntityAttributes.PublishedOn);
            }
            set
            {
                Attributes[EntityAttributes.SystemFormEntityAttributes.PublishedOn] = value;
            }
        }

        public string ObjectTypeCode
        {
            get
            {
                return GetStringAttributeValue(EntityAttributes.SystemFormEntityAttributes.ObjectTypeCode);
            }
            set
            {
                Attributes[EntityAttributes.SystemFormEntityAttributes.ObjectTypeCode] = value;
            }
        }

        public bool? IsManaged
        {
            get
            {
                return GetBoolAttributeValue(EntityAttributes.SystemFormEntityAttributes.IsManaged);
            }
            set
            {
                Attributes[EntityAttributes.SystemFormEntityAttributes.IsManaged] = value;
            }
        }

        public FormActivationState? FormActivationState
        {
            get
            {
                return (FormActivationState)GetOptionSetValueAttributeValue(EntityAttributes.SystemFormEntityAttributes.FormActivationState).Value;
            }
            set
            {
                Attributes[EntityAttributes.SystemFormEntityAttributes.FormActivationState] = value;
            }
        }

    }
}
