using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Common.EntityManagers
{
    public class PublisherManager : EntityManagerBase
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

        public PublisherManager(CRMContext context)
            : base(context, EntityAttributes.PublisherEntityAttributes.EntityName)
        {
        }


    }
}
