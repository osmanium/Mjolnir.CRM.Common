using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Sdk.ValueObjects
{
    public class EntityComparisionConfiguration
    {
        private static EntityComparisionConfiguration _default;
        public static EntityComparisionConfiguration Default { get { return _default; } }

        public bool IsIdIgnore { get; private set; }

        public bool IsLogicalNameIgnore { get; private set; }

        public bool IsFullComparision { get; private set; }

        static EntityComparisionConfiguration()
        {
            _default = new EntityComparisionConfiguration()
            {
                IsFullComparision = false,
                IsIdIgnore = false,
                IsLogicalNameIgnore = false
            };
        }

        public EntityComparisionConfiguration()
        {
           
        }
    }
}
