using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Sdk.ValueObjects
{
    public class EntityComparisonConfiguration
    {
        private static EntityComparisonConfiguration _default;
        public static EntityComparisonConfiguration Default { get { return _default; } }

        public bool IsIdIgnore { get; set; }

        public bool IsLogicalNameIgnore { get; set; }

        public bool ContinueOnDifference { get; set; }

        public List<string> IgnoredAttributeKeys { get; set; }

        public bool IsTargetToSourceAttributeCheck { get; set; }

        static EntityComparisonConfiguration()
        {
            _default = new EntityComparisonConfiguration()
            {
                ContinueOnDifference = false,
                IsIdIgnore = false,
                IsLogicalNameIgnore = false,
                IsTargetToSourceAttributeCheck = false,
                IgnoredAttributeKeys = new List<string>()
            };
        }

        public EntityComparisonConfiguration()
        {
            IgnoredAttributeKeys = new List<string>();
        }
    }
}
