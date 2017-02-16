using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Common.EntityManagers
{
    public static partial class EntityAttributes
    {
        public static class PublisherEntityAttributes
        {
            public const string EntityName = "publisher";
            public const string FriendlyName = "friendlyname";
            public const string UniqueName = "uniquename";
            public const string SupportingWebsiteUrl = "supportingwebsiteurl";
            public const string CustomizationPrefix = "customizationprefix";
            public const string EMailAddress = "emailaddress";
            public const string Description = "description";
        }
    }
    


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

        public PublisherManager(CrmContext context)
            : base(context, EntityAttributes.PublisherEntityAttributes.EntityName)
        {
        }


    }
}
