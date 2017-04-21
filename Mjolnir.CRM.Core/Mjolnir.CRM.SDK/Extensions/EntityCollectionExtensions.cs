using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Sdk.Extensions
{
    public static class EntityCollectionExtensions
    {
        public static List<TEntity> ToList<TEntity>(this EntityCollection entityCollection)
            where TEntity : EntityBase, new()
        {
            if (entityCollection != null && entityCollection.Entities.Any())
                return entityCollection.Entities.Select(s => s.ToGenericEntity<TEntity>()).ToList();

            return null;
        }
    }
}
