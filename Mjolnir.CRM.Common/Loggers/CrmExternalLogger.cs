using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;

namespace Mjolnir.CRM.Common.Loggers
{
    public class CrmExternalTracer : ITracingService
    {
        public void Trace(string format, params object[] args)
        {
            //TODO : Create trace record in crm
        }
    }
}
