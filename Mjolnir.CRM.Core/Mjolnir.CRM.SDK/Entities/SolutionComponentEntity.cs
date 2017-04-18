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
        public static class SolutionComponentEntityAttributes
        {
            public const string EntityName = "solutioncomponent";
            public const string ComponentType = "componenttype";
            public const string ObjectId = "objectid";
            public const string SolutionComponentId = "solutioncomponentid";
            public const string SolutionId = "solutionid";
            public const string IsMetadata = "ismetadata";
            public const string RootComponentBehavior = "rootcomponentbehavior";
        }
    }


    public class SolutionComponentEntity : EntityBase
    {
        public SolutionComponentEntity()
            : base(EntityAttributes.SolutionComponentEntityAttributes.EntityName)
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
    }
}
