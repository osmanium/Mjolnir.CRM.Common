using Mjolnir.CRM.SDK.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Core.EntityManagers
{
    public class ContactEntityManager : EntityManagerBase<CrmSettingEntity>
    {
        public ContactEntityManager(CrmContext context) 
            : base(context, EntityAttributes.ContactEntityAttributes.EntityName)
        {
        }

        internal override string[] DefaultFields
        {
            get
            {
                //TODO : Implement fields
                return null;
            }
        }
    }
}
