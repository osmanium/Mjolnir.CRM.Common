using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Sdk.Entities
{
    public static partial class EntityAttributes
    {
        public static class WebResourceEntityAttributes
        {
            public const string EntityName = "webresource";
            public const string IdFieldName = "webresourceid";
            public const string Name = "name";
            public const string DisplayName = "displayname";
            public const string Description = "description";
            public const string Content = "content";
            public const string WebResourceType = "webresourcetype";
        }
    }
    
    public class WebResourceEntity : EntityBase
    {
        public WebResourceEntity()
                : base(EntityAttributes.WebResourceEntityAttributes.EntityName)
        {

        }

        public Guid? IdFieldName
        {
            get
            {
                return GetGuidAttributeValue(EntityAttributes.WebResourceEntityAttributes.IdFieldName);
            }
            set
            {
                Attributes[EntityAttributes.WebResourceEntityAttributes.IdFieldName] = value;
            }
        }

        public string Name
        {
            get
            {
                return GetStringAttributeValue(EntityAttributes.WebResourceEntityAttributes.Name);
            }
            set
            {
                Attributes[EntityAttributes.WebResourceEntityAttributes.Name] = value;
            }
        }

        public string DisplayName
        {
            get
            {
                return GetStringAttributeValue(EntityAttributes.WebResourceEntityAttributes.DisplayName);
            }
            set
            {
                Attributes[EntityAttributes.WebResourceEntityAttributes.DisplayName] = value;
            }
        }

        public string Description
        {
            get
            {
                return GetStringAttributeValue(EntityAttributes.WebResourceEntityAttributes.Description);
            }
            set
            {
                Attributes[EntityAttributes.WebResourceEntityAttributes.Description] = value;
            }
        }

        public string Content
        {
            get
            {
                return GetStringAttributeValue(EntityAttributes.WebResourceEntityAttributes.Content);
            }
            set
            {
                Attributes[EntityAttributes.WebResourceEntityAttributes.Content] = value;
            }
        }

        public OptionSetValue WebResourceType
        {
            get
            {
                return GetOptionSetValueAttributeValue(EntityAttributes.WebResourceEntityAttributes.WebResourceType);
            }
            set
            {
                Attributes[EntityAttributes.WebResourceEntityAttributes.WebResourceType] = value;
            }
        }

    }
}
