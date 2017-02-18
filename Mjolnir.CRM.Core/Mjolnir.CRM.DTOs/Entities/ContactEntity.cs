using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.DTOs.Entities
{
    public static partial class EntityAttributes
    {
        public static class ContactEntityAttributes
        {
            public const string EntityName = "contact";
        }
    }

    public class ContactEntity : EntityBase
    {
        public ContactEntity()
            : base(EntityAttributes.ContactEntityAttributes.EntityName)
        {

        }
    }
}
