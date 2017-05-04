using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Mjolnir.CRM.Sdk.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mjolnir.CRM.Sdk.Extensions;

namespace Mjolnir.CRM.Core.EntityManagers
{
    public class PublisherManager : EntityManagerBase<PublisherEntity>
    {
        internal override string[] DefaultFields
        {
            get
            {
                return new string[] {
                    EntityAttributes.PublisherEntityAttributes.FriendlyName,
                    EntityAttributes.PublisherEntityAttributes.UniqueName,
                    EntityAttributes.PublisherEntityAttributes.CustomizationPrefix,
                    EntityAttributes.PublisherEntityAttributes.Description,
                    EntityAttributes.PublisherEntityAttributes.SupportingWebsiteUrl,
                    EntityAttributes.PublisherEntityAttributes.EMailAddress
                };
            }
        }

        public PublisherManager(CrmContext context)
            : base(context, EntityAttributes.PublisherEntityAttributes.EntityName)
        {
        }


        public async Task<PublisherEntity> GetPublisherByUniqueNameAsync(string publisherUniqueName)
        {
            try
            {
                context.TracingService.TraceVerbose("GetPublisherByUniqueName started.");

                return await RetrieveFirstByAttributeExactValueAsync(EntityAttributes.PublisherEntityAttributes.UniqueName, publisherUniqueName);
            }
            catch (Exception ex)
            {
                this.HandleException(ex);
                return null;
            }
        }

    }
}
