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
        public static CrmContext ConnectCrm(string userName, string serverName, string password, string domain, string port, string organization, bool useSSL, int timeOutInMinutes)
        {
            CrmServiceClient _sourceCRMServiceClient = new CrmServiceClient(new NetworkCredential(userName, password, domain), serverName, port, organization, true, useSSL, null);
            
            CrmContext crmContext = new CrmContext(_sourceCRMServiceClient.OrganizationServiceProxy,
                                  _sourceCRMServiceClient.OrganizationServiceProxy.CallerId,
                                  new CrmLogger(new CrmExternalTracer()),
                                  null,
                                  null);
            
            return crmContext;
        }

        public static void UpdateTraceSettingFromCRM(CrmContext crmContext)
        {
            //Get trace configurations
            var crmSettingEntityManager = new CrmSettingManager(crmContext);
            var configuration = crmSettingEntityManager.GetCrmSettingByKey(Constants.CrmSettingKeys.CrmTraceLevel);

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
