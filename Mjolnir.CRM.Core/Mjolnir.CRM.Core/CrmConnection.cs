using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Tooling.Connector;
using Mjolnir.CRM.Core.EntityManagers;
using Mjolnir.CRM.Core.Loggers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Core
{
    public static class CrmConnection
    {
        public static CrmContext ConnectCrm(string connectionString)
        {
            var sourceCrmServiceClient = new CrmServiceClient(connectionString);
            
            var crmContext = new CrmContext(sourceCrmServiceClient.OrganizationServiceProxy,
                                  sourceCrmServiceClient.OrganizationServiceProxy.CallerId,
                                  new CrmLogger(new CrmExternalTracer()));
            
            return crmContext;
        }

        public static async void UpdateTraceSettingFromCRM(CrmContext crmContext)
        {
            //Get trace configurations
            var crmSettingEntityManager = new CrmSettingManager(crmContext);
            var configuration = await crmSettingEntityManager.GetCrmSettingByKeyAsync(Constants.CrmSettingKeys.CrmTraceLevel);

            if (configuration != null && configuration.TraceLevelSettingOptionSet != null)
            {
                //Update trace level based on configuration
                crmContext.TraceLevel = (TraceLevel)configuration.TraceLevelSettingOptionSet.Value;
            }
            else
            {
                crmContext.TracingService.TraceWarning("Trace Level configuration is not found in CrmSettings, default confuguration is applied.");
            }
        }

        public static void UpdateTimeOutSetting(int timeOutInMinutes, OrganizationServiceProxy organizationServiceProxy)
        {
            if (organizationServiceProxy == null)
            {
                throw new CrmBusinessException("CRM connection failed.");
            }
            else
            {
                if (timeOutInMinutes > 0)
                {
                    organizationServiceProxy.Timeout = new TimeSpan(0, timeOutInMinutes, 0);
                }
                else
                {
                    organizationServiceProxy.Timeout = new TimeSpan(0, 10, 0);
                }
            }
        }
    }
}
