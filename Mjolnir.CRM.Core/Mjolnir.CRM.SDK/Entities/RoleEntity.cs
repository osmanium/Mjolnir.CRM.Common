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
        public static class RoleEntityAttributes
        {
            public const string EntityName = "role";
            public const string IdFieldName = "roleid";
            public const string Name = "name";
            public const string BusinessUnitId = "businessunitid";
            public const string ParentRoleId = "parentroleid";
            public const string ParentRootRoleId = "parentrootroleid";
            public const string RoleTemplateId = "roletemplateid";
            public const string SolutionId = "solutionid";
            public const string IsManaged = "ismanaged";
            public const string IsCustomizable = "iscustomizable";
        }
    }

    public class RoleEntity : EntityBase
    {
        public RoleEntity()
                : base(EntityAttributes.RoleEntityAttributes.EntityName)
        {

        }

        public RoleEntity(AttributeCollection attributes, string alias)
                : base(EntityAttributes.RoleEntityAttributes.EntityName, attributes, alias)
        {

        }

        public Guid IdFieldName
        {
            get
            {
                return GetGuidAttributeValue(EntityAttributes.RoleEntityAttributes.IdFieldName);
            }
            set
            {
                Attributes[EntityAttributes.RoleEntityAttributes.IdFieldName] = value;
            }
        }
        
        public string Name
        {
            get
            {
                return GetStringAttributeValue(EntityAttributes.RoleEntityAttributes.Name);
            }
            set
            {
                Attributes[EntityAttributes.RoleEntityAttributes.Name] = value;
            }
        }

        public Guid BusinessUnitId
        {
            get
            {
                return GetGuidAttributeValue(EntityAttributes.RoleEntityAttributes.BusinessUnitId);
            }
            set
            {
                Attributes[EntityAttributes.RoleEntityAttributes.BusinessUnitId] = value;
            }
        }

        public Guid ParentRoleId
        {
            get
            {
                return GetGuidAttributeValue(EntityAttributes.RoleEntityAttributes.ParentRoleId);
            }
            set
            {
                Attributes[EntityAttributes.RoleEntityAttributes.ParentRoleId] = value;
            }
        }

        public Guid ParentRootRoleId
        {
            get
            {
                return GetGuidAttributeValue(EntityAttributes.RoleEntityAttributes.ParentRootRoleId);
            }
            set
            {
                Attributes[EntityAttributes.RoleEntityAttributes.ParentRootRoleId] = value;
            }
        }

        public Guid RoleTemplateId
        {
            get
            {
                return GetGuidAttributeValue(EntityAttributes.RoleEntityAttributes.RoleTemplateId);
            }
            set
            {
                Attributes[EntityAttributes.RoleEntityAttributes.RoleTemplateId] = value;
            }
        }

        public Guid SolutionId
        {
            get
            {
                return GetGuidAttributeValue(EntityAttributes.RoleEntityAttributes.SolutionId);
            }
            set
            {
                Attributes[EntityAttributes.RoleEntityAttributes.SolutionId] = value;
            }
        }

        public bool IsManaged
        {
            get
            {
                return GetBoolAttributeValue(EntityAttributes.RoleEntityAttributes.IsManaged);
            }
            set
            {
                Attributes[EntityAttributes.RoleEntityAttributes.IsManaged] = value;
            }
        }

        public bool IsCustomizable
        {
            get
            {
                return GetBoolAttributeValue(EntityAttributes.RoleEntityAttributes.IsCustomizable);
            }
            set
            {
                Attributes[EntityAttributes.RoleEntityAttributes.IsCustomizable] = value;
            }
        }
    }
}
