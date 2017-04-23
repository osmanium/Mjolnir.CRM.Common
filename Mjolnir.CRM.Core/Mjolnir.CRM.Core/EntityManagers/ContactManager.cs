using Mjolnir.CRM.Sdk.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Core.EntityManagers
{
    public class ContactManager : EntityManagerBase<CrmSettingEntity>
    {
        public ContactManager(CrmContext context) 
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
