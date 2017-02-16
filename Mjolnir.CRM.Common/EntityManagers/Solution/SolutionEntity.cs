using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Common.EntityManagers
{
    public static partial class EntityAttributes
    {
        public static class SolutionEntityAttributes
        {
            public const string EntityName = "solution";
            public const string IdFieldName = "solutionid";
            public const string VersionFieldName = "version";
            public const string FriendlyNameFieldName = "friendlyname";
            public const string UniqueNameFieldName = "uniquename";
            public const string ParentSolutionIdFieldName = "parentsolutionid";
            public const string IsManagedFieldName = "ismanaged";
            public const string PublisherId = "publisherid";
            public const string Description = "description";
        }
    }

    public class SolutionEntity : EntityBase
    {
        public SolutionEntity()
            :base(EntityAttributes.SolutionEntityAttributes.EntityName)
        {
        }
    }
}
