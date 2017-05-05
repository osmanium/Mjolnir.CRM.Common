using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Sdk.Entities
{
    public static partial class EntityAttributes
    {
        public static class BusinessUnitEntityAttributes
        {
            public const string EntityName = "businessunit";
            public const string IdFieldName = "businessunitid";
            public const string ParentBusinessUnitId = "parentbusinessunitid";
            public const string Name = "name";
            public const string CalendarId = "calendarid";
            public const string Description = "description";
            public const string EmailAddress = "emailaddress";
        }
    }

    public class BusinessUnitEntity : EntityBase
    {
        public BusinessUnitEntity()
            : base(EntityAttributes.BusinessUnitEntityAttributes.EntityName)
        {
        }

        public Guid? IdFieldName
        {
            get
            {
                return GetGuidAttributeValue(EntityAttributes.BusinessUnitEntityAttributes.IdFieldName);
            }
            set
            {
                Attributes[EntityAttributes.BusinessUnitEntityAttributes.IdFieldName] = value;
            }
        }

        public Guid? ParentBusinessUnitId
        {
            get
            {
                return GetGuidAttributeValue(EntityAttributes.BusinessUnitEntityAttributes.ParentBusinessUnitId);
            }
            set
            {
                Attributes[EntityAttributes.BusinessUnitEntityAttributes.ParentBusinessUnitId] = value;
            }
        }

        public string Name
        {
            get
            {
                return GetStringAttributeValue(EntityAttributes.BusinessUnitEntityAttributes.Name);
            }
            set
            {
                Attributes[EntityAttributes.BusinessUnitEntityAttributes.Name] = value;
            }
        }

        public Guid? CalendarId
        {
            get
            {
                return GetGuidAttributeValue(EntityAttributes.BusinessUnitEntityAttributes.CalendarId);
            }
            set
            {
                Attributes[EntityAttributes.BusinessUnitEntityAttributes.CalendarId] = value;
            }
        }

        public string Description
        {
            get
            {
                return GetStringAttributeValue(EntityAttributes.BusinessUnitEntityAttributes.Description);
            }
            set
            {
                Attributes[EntityAttributes.BusinessUnitEntityAttributes.Description] = value;
            }
        }

        public string EmailAddress
        {
            get
            {
                return GetStringAttributeValue(EntityAttributes.BusinessUnitEntityAttributes.EmailAddress);
            }
            set
            {
                Attributes[EntityAttributes.BusinessUnitEntityAttributes.EmailAddress] = value;
            }
        }
    }
}
