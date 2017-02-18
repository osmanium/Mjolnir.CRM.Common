using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Mjolnir.CRM.Core.EntityManagers;
using Mjolnir.CRM.Core.Loggers;
using Mjolnir.CRM.DTOs.Entities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Core
{
    public class CrmContext : IDisposable
    {
        public CrmLogger TracingService { get; private set; }
        public IPluginExecutionContext PluginExecutionContext { get; private set; }
        public IOrganizationService OrganizationService { get; private set; }
        public IServiceProvider ServiceProvider { get; private set; }

        public Guid UserId { get; private set; }

        public bool IsPlugin { get { return PluginExecutionContext != null; } }

        public TraceLevel TraceLevel { get; set; }

        public static readonly ConcurrentDictionary<Guid, Dictionary<string, CrmSettingEntity>> CrmSettings = new ConcurrentDictionary<Guid, Dictionary<string, CrmSettingEntity>>();


        public CrmContext(IOrganizationService OrganizationService, Guid UserId,
            CrmLogger TracingService, 
            IPluginExecutionContext PluginExecutionContext = null, 
            IServiceProvider ServiceProvider = null,
            TraceLevel TraceLevel = TraceLevel.Off)
        {
            this.TracingService = TracingService;
            this.PluginExecutionContext = PluginExecutionContext;
            this.OrganizationService = OrganizationService;
            this.ServiceProvider = ServiceProvider;
            this.UserId = UserId;
            this.TraceLevel = TraceLevel;
        }

        public void Dispose()
        {
            OrganizationService = null;
        }
    }
}
