using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Common.Tracers
{
    public class BaseTracer : ITracingService
    {
        public readonly CRMContext context = null;
        public BaseTracer(CRMContext context)
        {
            this.context = context;
        }

        public void Trace(string format, params object[] args)
        {
            context.TracingService.Trace(format, args);
        }
    }
}
