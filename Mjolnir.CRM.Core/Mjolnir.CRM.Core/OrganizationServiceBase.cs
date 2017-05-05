using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Core
{
    public class OrganizationServiceCore
    {
        public CrmContext Context { get; private set; }

        public OrganizationServiceCore(CrmContext context)
        {
            this.Context = context;
        }
        
        public T Execute<T>(OrganizationRequest request)
            where T : OrganizationResponse
        {
            return Context.OrganizationService.Execute(request) as T;
        }
        public async Task<T> ExecuteAsync<T>(OrganizationRequest request)
            where T : OrganizationResponse
        {
            var t = Task.Factory.StartNew(() =>
            {
                return Execute<T>(request);
            });

            return await t;
        }

    }
}
