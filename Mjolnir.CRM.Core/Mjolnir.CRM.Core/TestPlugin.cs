using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Common
{
#if DEBUG
    public class TestPlugin : PluginBase
    {
        public override void ExecuteInternal(CrmContext pluginContext)
        {
        }
    }
#endif
}
