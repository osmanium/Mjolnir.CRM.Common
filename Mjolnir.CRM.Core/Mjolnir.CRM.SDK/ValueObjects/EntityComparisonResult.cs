using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Sdk.ValueObjects
{
    public class EntityComparisonResult
    {
        public bool IsEqual { get; set; } = false;

        public List<string> Reason { get; set; }


        public EntityComparisonResult(bool isEqual, List<string> reason)
        {
            this.IsEqual = isEqual;
            this.Reason = reason;
        }
    }
}
