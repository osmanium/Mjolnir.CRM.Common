using Microsoft.Xrm.Sdk;
using Mjolnir.CRM.Common.Tracers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Common.Tests
{
    public class CrmUnitTestTracer : BaseTracer
    {
        public CrmUnitTestTracer(CrmContext context)
            : base(context)
        {
        }

        public void Trace(TraceLevel traceLevel, string format, params object[] args)
        {
            if (context.TraceLevel <= traceLevel)
                System.Diagnostics.Trace.WriteLine(string.Format(format, args));
        }
    }
}
