using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Sdk.ValueObjects
{
    public class EntityMetadataComparisonConfiguration
    {
        private static EntityMetadataComparisonConfiguration _default;
        public static EntityMetadataComparisonConfiguration Default { get { return _default; } }

        public EntityFilters EntityFilters { get; set; } = EntityFilters.Default;

        public bool ContinueOnDifference { get; set; }

        public List<string> IgnoredAttributeKeys { get; set; }

        public bool IsTargetToSourceAttributeCheck { get; set; }

        static EntityMetadataComparisonConfiguration()
        {
            _default = new EntityMetadataComparisonConfiguration()
            {
                ContinueOnDifference = false,
                IsTargetToSourceAttributeCheck = false,
                IgnoredAttributeKeys = new List<string>(),
                EntityFilters = EntityFilters.Default
            };
        }

        public EntityMetadataComparisonConfiguration()
        {
            IgnoredAttributeKeys = new List<string>();
        }
    }
}
