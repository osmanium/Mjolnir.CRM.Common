using Microsoft.Xrm.Sdk.Query;
using Mjolnir.CRM.Sdk.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mjolnir.CRM.Sdk.Extensions;

namespace Mjolnir.CRM.Core.EntityManagers
{
    public class RolePrivilegesManager : EntityManagerBase<RolePrivilegesEntity>
    {
        internal override string[] DefaultFields
        {
            get
            {
                return new string[] {
                    EntityAttributes.RolePrivilegesEntityAttributes.IdFieldName,
                    EntityAttributes.RolePrivilegesEntityAttributes.RoleIdFieldName,
                    EntityAttributes.RolePrivilegesEntityAttributes.IsManaged,
                    EntityAttributes.RolePrivilegesEntityAttributes.PrivilegeDepthMask,
                    EntityAttributes.RolePrivilegesEntityAttributes.PrivilegeId,
                    EntityAttributes.RolePrivilegesEntityAttributes.SolutionId,
                };
            }
        }

        public RolePrivilegesManager(CrmContext context)
            : base(context, EntityAttributes.RolePrivilegesEntityAttributes.EntityName)
        { }

        public async Task<List<RolePrivilegesEntity>> GetRolePrivilegesAsync(Guid RoleId)
        {
            var fetchXml = $@"<fetch version='1.0' mapping='logical' distinct='false'>
                               <entity name='roleprivileges'>
                                  <attribute name='privilegeid'/>
                                  <attribute name='privilegedepthmask'/>
                                    <filter type='and'>
                                        <condition attribute = 'roleid' operator= 'eq' value = '{ RoleId.ToString() }' />
                                    </filter>
                                  <link-entity name='role' alias='roles' to='roleid' from='roleid' link-type='inner'>
                                     <attribute name='name'/>
                                  </link-entity>
                                  <link-entity name='privilege' alias='privileges' to='privilegeid' from='privilegeid' link-type='inner'>
                                     <attribute name='name'/>
                                     <attribute name='accessright'/>
                                     <attribute name='canbebasic'/>
                                     <attribute name='canbedeep'/>
                                     <attribute name='canbeentityreference'/>
                                     <attribute name='canbeglobal'/>
                                     <attribute name='canbeparententityreference'/>
                                     <attribute name='canbelocal'/>
                                  </link-entity>
                               </entity>
                            </fetch>";

            var task = await RetrieveMultipleAsync(fetchXml);
            
            return task.ToList<RolePrivilegesEntity>();
        }
    }
}
