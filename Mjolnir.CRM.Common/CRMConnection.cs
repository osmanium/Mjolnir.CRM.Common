using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Tooling.Connector;
using Mjolnir.CRM.Common.Loggers;
using System;
using System.Collections.Generic;
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

            CrmContext crmContext = null;

            return new CrmContext(_sourceCRMServiceClient.OrganizationServiceProxy,
                                  _sourceCRMServiceClient.OrganizationServiceProxy.CallerId,
                                  new CrmLogger(new CrmExternalTracer()),//TODO : fix here
                                  null,
                                  null);
        }
    }
}
