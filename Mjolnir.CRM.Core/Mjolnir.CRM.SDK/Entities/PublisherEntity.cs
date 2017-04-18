using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.SDK.Entities
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

    public class PublisherEntity : EntityBase
    {
        public PublisherEntity()
            : base(EntityAttributes.PublisherEntityAttributes.EntityName)
        {

        }

        public string FriendlyName
        {
            get
            {
                return GetStringAttributeValue(EntityAttributes.PublisherEntityAttributes.FriendlyName);
            }
            set
            {
                Attributes[EntityAttributes.PublisherEntityAttributes.FriendlyName] = value;
            }
        }

        public string CustomizationPrefix
        {
            get
            {
                return GetStringAttributeValue(EntityAttributes.PublisherEntityAttributes.CustomizationPrefix);
            }
            set
            {
                Attributes[EntityAttributes.PublisherEntityAttributes.CustomizationPrefix] = value;
            }
        }

        public string UniqueName
        {
            get
            {
                return GetStringAttributeValue(EntityAttributes.PublisherEntityAttributes.UniqueName);
            }
            set
            {
                Attributes[EntityAttributes.PublisherEntityAttributes.UniqueName] = value;
            }
        }

        public string SupportingWebsiteUrl
        {
            get
            {
                return GetStringAttributeValue(EntityAttributes.PublisherEntityAttributes.SupportingWebsiteUrl);
            }
            set
            {
                Attributes[EntityAttributes.PublisherEntityAttributes.SupportingWebsiteUrl] = value;
            }
        }

        public string EMailAddress
        {
            get
            {
                return GetStringAttributeValue(EntityAttributes.PublisherEntityAttributes.EMailAddress);
            }
            set
            {
                Attributes[EntityAttributes.PublisherEntityAttributes.EMailAddress] = value;
            }
        }

        public string Description
        {
            get
            {
                return GetStringAttributeValue(EntityAttributes.PublisherEntityAttributes.Description);
            }
            set
            {
                Attributes[EntityAttributes.PublisherEntityAttributes.Description] = value;
            }
        }
    }
}
