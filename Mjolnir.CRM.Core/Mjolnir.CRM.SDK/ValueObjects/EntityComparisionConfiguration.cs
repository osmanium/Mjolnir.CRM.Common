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

        public bool IsIdIgnore { get; set; }

        public bool IsLogicalNameIgnore { get; set; }

        public bool IsFullComparision { get; set; }

        public List<string> IgnoredAttributeKeys { get; set; }

        public bool IsTargetToSourceAttributeCheck { get; set; }

        static EntityComparisionConfiguration()
        {
            _default = new EntityComparisionConfiguration()
            {
                IsFullComparision = false,
                IsIdIgnore = false,
                IsLogicalNameIgnore = false,
                IsTargetToSourceAttributeCheck = false,
                IgnoredAttributeKeys = new List<string>()
            };
        }

        public EntityComparisionConfiguration()
        {
            IgnoredAttributeKeys = new List<string>();
        }
    }
}
