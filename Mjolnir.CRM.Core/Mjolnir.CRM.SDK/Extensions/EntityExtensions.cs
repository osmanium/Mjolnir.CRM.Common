using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Sdk.Extensions
{
    public static class EntityExtensions
    {
        public static void ShallowCopyTo(this Entity source, Entity target)
        {
            if (target != null && target != source)
            {
                target.Id = source.Id;
                target.LogicalName = source.LogicalName;
                target.EntityState = source.EntityState;
                target.Attributes = source.Attributes;
                target.ExtensionData = source.ExtensionData;
                target.RowVersion = source.RowVersion;
                target.KeyAttributes = source.KeyAttributes;
            }
        }

        public static T ToGenericEntity<T>(this Entity sourceEntity)
        where T : Entity, new()
        {
            if (typeof(T) == typeof(Entity))
            {
                var resultEntity = new Entity();
                sourceEntity.ShallowCopyTo(resultEntity);
                return (T)(resultEntity as T);
            }
            if (string.IsNullOrWhiteSpace(sourceEntity.LogicalName))
            {
                throw new NotSupportedException("LogicalName must be set before calling ToGenericEntity()");
            }

            T t = new T();
            sourceEntity.ShallowCopyTo(t);
            return t;
        }
    }
}
