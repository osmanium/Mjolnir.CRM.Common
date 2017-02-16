using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Common.EntityManagers
{
    public static partial class EntityAttributes
    {
        public static class ContactEntityAttributes
        {
            public const string EntityName = "contact";
        }
    }
    

    public class ContactEntityManager : EntityManagerBase
    {
        public ContactEntityManager(CrmContext context) 
            : base(context, EntityAttributes.ContactEntityAttributes.EntityName)
        {
        }

        internal override string[] DefaultFields
        {
            get
            {
                return null;
            }
        }
    }
}
