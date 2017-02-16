using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Mjolnir.CRM.Common.Tracers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Common
{
    public class CrmContext
    {
        public BaseTracer TracingService { get; private set; }
        public IPluginExecutionContext PluginExecutionContext { get; private set; }
        public OrganizationServiceProxy OrganizationService { get; private set; }
        public IServiceProvider ServiceProvider { get; private set; }

        public Guid UserId { get; private set; }

        public TraceLevel TraceLevel { get; }

        public CrmContext(OrganizationServiceProxy OrganizationService, Guid UserId,
            BaseTracer TracingService, 
            IPluginExecutionContext PluginExecutionContext = null, 
            IServiceProvider ServiceProvider = null,
            TraceLevel TraceLevel = TraceLevel.Warning)
        {
            this.TracingService = TracingService;
            this.PluginExecutionContext = PluginExecutionContext;
            this.OrganizationService = OrganizationService;
            this.ServiceProvider = ServiceProvider;
            this.UserId = UserId;
            this.TraceLevel = TraceLevel;
        }
    }
}
