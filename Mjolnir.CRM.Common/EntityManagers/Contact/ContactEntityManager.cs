using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Common.EntityManagers
{
    public class ContactEntityManager : EntityManagerBase<ContactEntity>
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
