using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Tooling.Connector;
using Mjolnir.CRM.Common.Loggers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Common
{
    public abstract class PluginBase : IPlugin
    {
        protected CrmContext PluginContext { get; private set; }

        public void Execute(IServiceProvider serviceProvider)
        {
            var pluginExecutionContext = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            var organizationServiceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            var organizationService = organizationServiceFactory.CreateOrganizationService(pluginExecutionContext.UserId);
            var tracingService = new CrmLogger((ITracingService)serviceProvider.GetService(typeof(ITracingService)));
            
            this.PluginContext = new CrmContext(organizationService, pluginExecutionContext.UserId, tracingService, pluginExecutionContext, serviceProvider);

            //TODO : Get configurations

            //TODO : Update trace level based on configuration

            this.PluginContext.TracingService.TraceError("CrmSettings Hash : " + CrmContext.CrmSettings.GetHashCode().ToString());

            ExecuteInternal(this.PluginContext);

        }

        public abstract void ExecuteInternal(CrmContext pluginContext);
    }
}
