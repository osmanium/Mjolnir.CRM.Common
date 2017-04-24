using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Sdk.Entities
{
    public static partial class EntityAttributes
    {
        public static class PrivilegeEntityAttributes
        {
            public const string EntityName = "privilege";
            public const string IdFieldName = "privilegeid";
            public const string Name = "name";
            public const string AccessRight = "accessright";
            public const string CanBeBasic = "canbebasic";
            public const string CanBeDeep = "canbedeep";
            public const string CanBeEntityReference = "canbeentityreference";
            public const string CanBeGlobal = "canbeglobal";
            public const string CanBeLocal = "canbelocal";
            public const string CanBeParentEntityReference = "canbeparententityreference";
            public const string IsDisabledWhenIntegrated = "isdisabledwhenitegrated";
        }
    }

    public class PrivilegeEntity : EntityBase
    {
        public PrivilegeEntity()
                : base(EntityAttributes.PrivilegeEntityAttributes.EntityName)
        {

        }

        public PrivilegeEntity(AttributeCollection attributes, string alias)
                : base(EntityAttributes.PrivilegeEntityAttributes.EntityName, attributes, alias)
        {

        }

        public Guid IdFieldName
        {
            get
            {
                return GetGuidAttributeValue(EntityAttributes.RolePrivilegesEntityAttributes.IdFieldName);
            }
            set
            {
                Attributes[EntityAttributes.RolePrivilegesEntityAttributes.IdFieldName] = value;
            }
        }

        public string Name
        {
            get
            {
                return GetStringAttributeValue(EntityAttributes.PrivilegeEntityAttributes.Name);
            }
            set
            {
                Attributes[EntityAttributes.PrivilegeEntityAttributes.Name] = value;
            }
        }

        public int AccessRight
        {
            get
            {
                return GetIntigerAttributeValue(EntityAttributes.PrivilegeEntityAttributes.AccessRight);
            }
            set
            {
                Attributes[EntityAttributes.PrivilegeEntityAttributes.AccessRight] = value;
            }
        }

        public bool CanBeBasic
        {
            get
            {
                return GetBoolAttributeValue(EntityAttributes.PrivilegeEntityAttributes.CanBeBasic);
            }
            set
            {
                Attributes[EntityAttributes.PrivilegeEntityAttributes.CanBeBasic] = value;
            }
        }

        public bool CanBeDeep
        {
            get
            {
                return GetBoolAttributeValue(EntityAttributes.PrivilegeEntityAttributes.CanBeDeep);
            }
            set
            {
                Attributes[EntityAttributes.PrivilegeEntityAttributes.CanBeDeep] = value;
            }
        }

        public bool CanBeEntityReference
        {
            get
            {
                return GetBoolAttributeValue(EntityAttributes.PrivilegeEntityAttributes.CanBeEntityReference);
            }
            set
            {
                Attributes[EntityAttributes.PrivilegeEntityAttributes.CanBeEntityReference] = value;
            }
        }

        public bool CanBeGlobal
        {
            get
            {
                return GetBoolAttributeValue(EntityAttributes.PrivilegeEntityAttributes.CanBeGlobal);
            }
            set
            {
                Attributes[EntityAttributes.PrivilegeEntityAttributes.CanBeGlobal] = value;
            }
        }

        public bool CanBeLocal
        {
            get
            {
                return GetBoolAttributeValue(EntityAttributes.PrivilegeEntityAttributes.CanBeLocal);
            }
            set
            {
                Attributes[EntityAttributes.PrivilegeEntityAttributes.CanBeLocal] = value;
            }
        }

        public bool CanBeParentEntityReference
        {
            get
            {
                return GetBoolAttributeValue(EntityAttributes.PrivilegeEntityAttributes.CanBeParentEntityReference);
            }
            set
            {
                Attributes[EntityAttributes.PrivilegeEntityAttributes.CanBeParentEntityReference] = value;
            }
        }
    }
}
