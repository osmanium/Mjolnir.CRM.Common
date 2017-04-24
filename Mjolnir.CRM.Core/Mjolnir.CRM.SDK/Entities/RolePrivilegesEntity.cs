using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Sdk.Entities
{
    public static partial class EntityAttributes
    {
        public static class RolePrivilegesEntityAttributes
        {
            public const string EntityName = "roleprivileges";
            public const string IdFieldName = "roleprivilegeid";
            public const string RoleIdFieldName = "roleid";
            public const string PrivilegeId = "privilegeid";
            public const string SolutionId = "solutionid";
            public const string PrivilegeDepthMask = "privilegedepthmask";
            public const string IsManaged = "ismanaged";


            //Relation Model
            public const string Role_Alias = "roles";
            public const string Privilege_Alias = "privileges";
        }
    }

    public class RolePrivilegesEntity : EntityBase
    {
        public RolePrivilegesEntity()
                : base(EntityAttributes.RolePrivilegesEntityAttributes.EntityName)
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

        public Guid RoleIdFieldName
        {
            get
            {
                return GetGuidAttributeValue(EntityAttributes.RolePrivilegesEntityAttributes.RoleIdFieldName);
            }
            set
            {
                Attributes[EntityAttributes.RolePrivilegesEntityAttributes.RoleIdFieldName] = value;
            }
        }

        public Guid PrivilegeId
        {
            get
            {
                return GetGuidAttributeValue(EntityAttributes.RolePrivilegesEntityAttributes.PrivilegeId);
            }
            set
            {
                Attributes[EntityAttributes.RolePrivilegesEntityAttributes.PrivilegeId] = value;
            }
        }

        public Guid SolutionId
        {
            get
            {
                return GetGuidAttributeValue(EntityAttributes.RolePrivilegesEntityAttributes.SolutionId);
            }
            set
            {
                Attributes[EntityAttributes.RolePrivilegesEntityAttributes.SolutionId] = value;
            }
        }

        public int PrivilegeDepthMask
        {
            get
            {
                return GetIntigerAttributeValue(EntityAttributes.RolePrivilegesEntityAttributes.PrivilegeDepthMask);
            }
            set
            {
                Attributes[EntityAttributes.RolePrivilegesEntityAttributes.PrivilegeDepthMask] = value;
            }
        }

        public bool IsManaged
        {
            get
            {
                return GetBoolAttributeValue(EntityAttributes.RolePrivilegesEntityAttributes.IsManaged);
            }
            set
            {
                Attributes[EntityAttributes.RolePrivilegesEntityAttributes.IsManaged] = value;
            }
        }


        #region RELATIONS
        private RoleEntity _roleLinkedEntity;
        public RoleEntity RoleLinkedEntity
        {
            get
            {
                if (_roleLinkedEntity == null)
                    _roleLinkedEntity = new RoleEntity(this.Attributes, EntityAttributes.RolePrivilegesEntityAttributes.Role_Alias);
                return _roleLinkedEntity;
            }
        }


        private PrivilegeEntity _privilegeLinkedEntity;
        public PrivilegeEntity PrivilegeLinkedEntity
        {
            get
            {
                if (_privilegeLinkedEntity == null)
                    _privilegeLinkedEntity = new PrivilegeEntity(this.Attributes, EntityAttributes.RolePrivilegesEntityAttributes.Privilege_Alias);
                return _privilegeLinkedEntity;
            }
        } 
        #endregion
    }
}
