using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Sdk.ValueObjects
{
    public class ComparisonError
    {
        public string Reason { get; set; }

        public string SourceValue { get; set; }

        public string TargetValue { get; set; }

        public ComparisonError(string sourceValue, string targetValue, string reason)
        {
            this.Reason = reason;
            this.SourceValue = sourceValue;
            this.TargetValue = targetValue;
        }
    }
}
