using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Tooling.Connector;
using Mjolnir.CRM.Common.EntityManagers;
using Mjolnir.CRM.Common.Loggers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Common
{
    public static class CrmConnection
    {
        public static CrmContext ConnectCrm(string userName, string serverName, string password, string domain, string port, string organization, bool useSSL, int timeOutInMinutes)
        {
            CrmServiceClient _sourceCRMServiceClient = new CrmServiceClient(new NetworkCredential(userName, password, domain), serverName, port, organization, true, useSSL, null);

            UpdateTimeOutSetting(timeOutInMinutes, _sourceCRMServiceClient);

            CrmContext crmContext = new CrmContext(_sourceCRMServiceClient.OrganizationServiceProxy,
                                  _sourceCRMServiceClient.OrganizationServiceProxy.CallerId,
                                  new CrmLogger(new CrmExternalTracer()),
                                  null,
                                  null);

            UpdateTraceSetting(crmContext);

            return crmContext;
        }

        private static void UpdateTraceSetting(CrmContext crmContext)
        {
            //Get trace configurations
            var crmSettingEntityManager = new CrmSettingEntityManager(crmContext);
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

        private static void UpdateTimeOutSetting(int timeOutInMinutes, CrmServiceClient _sourceCRMServiceClient)
        {
            if (_sourceCRMServiceClient.OrganizationServiceProxy == null)
            {
                throw new CrmBusinessException("CRM connection failed.");
            }
            else
            {
                if (timeOutInMinutes > 0)
                {
                    _sourceCRMServiceClient.OrganizationServiceProxy.Timeout = new TimeSpan(0, timeOutInMinutes, 0);
                }
                else
                {
                    _sourceCRMServiceClient.OrganizationServiceProxy.Timeout = new TimeSpan(0, 10, 0);
                }
            }
        }
    }
}
