using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Common.Loggers
{
    public class CrmLogger
    {
        private readonly ITracingService _tracingService;
        private readonly TraceLevel _allowedLogLevel;

        public CrmLogger(ITracingService tracingService, TraceLevel traceLevel = TraceLevel.Error)
        {
            _tracingService = tracingService;
            _allowedLogLevel = traceLevel;
        }

        public void TraceInfo(string format, params object[] args)
        {
            Trace(TraceLevel.Info, format, args);
        }

        public void TraceError(string format, params object[] args)
        {
            Trace(TraceLevel.Error, format, args);
        }
        public void TraceWarning(string format, params object[] args)
        {
            Trace(TraceLevel.Warning, format, args);
        }

        public void TraceVerbose(string format, params object[] args)
        {
            Trace(TraceLevel.Verbose, format, args);
        }

        private void Trace(TraceLevel requestedLogLevel, string format, params object[] args)
        {
            if (_allowedLogLevel == TraceLevel.Off)
                return;

            //Error = 1,
            //Warning = 2,
            //Info = 3,
            //Verbose = 4

            //Allowed log level     : Info
            //Requested log level   : Error

            //Info(3) >= Error(1)

            if (_allowedLogLevel >= requestedLogLevel)
                if (_tracingService != null)
                    _tracingService.Trace(format, args);
        }

        public void LogException(Exception ex)
        {
            //TODO : Log to crm
        }
    }
}
