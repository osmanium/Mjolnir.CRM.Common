using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Sdk.ValueObjects
{
    public class ComparisonResult
    {
        public bool IsEqual { get; private set; } = false;
        
        public List<ComparisonError> Errors { get; private set; }

        public ComparisonResult(bool isEqual, List<ComparisonError> errors)
        {
            this.IsEqual = isEqual;
            this.Errors = errors;
        }
    }
}