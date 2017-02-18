using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Core.Enums
{
    [System.Runtime.Serialization.DataContractAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "8.1.0.239")]
    public enum SolutionComponentRootComponentBehavior
    {

        [System.Runtime.Serialization.EnumMemberAttribute()]
        IncludeSubcomponents = 0,

        [System.Runtime.Serialization.EnumMemberAttribute()]
        Donotincludesubcomponents = 1,

        [System.Runtime.Serialization.EnumMemberAttribute()]
        IncludeAsShellOnly = 2,
    }
}
