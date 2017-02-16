using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Common
{
    public static class CRMConnection
    {
        public static OrganizationServiceProxy ConnectCrm(string userName, string serverName, string password, string domain, string port, string organization, bool useSSL)
        {
            CrmServiceClient _sourceCRMServiceClient = new CrmServiceClient(new NetworkCredential(userName, password, domain), serverName, port, organization, true, useSSL, null);
            return _sourceCRMServiceClient.OrganizationServiceProxy;
        }
    }
}
