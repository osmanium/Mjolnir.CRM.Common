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

        public static bool Compare(this Entity sourceEntity, Entity targetEntity)
        {
            if (sourceEntity.Id != targetEntity.Id)
                return false;

            if (sourceEntity.LogicalName != targetEntity.LogicalName)
                return false;

            foreach (var sourceKey in sourceEntity.Attributes.Keys)
            {
                if (targetEntity.Contains(sourceKey))
                {
                    if (!CompareValue(sourceEntity[sourceKey], targetEntity[sourceKey]))
                    {
                        return false;
                    }
                }
                else return false;
            }

            return true;
        }

        private static bool CompareValue(object sourceValue, object targetValue)
        {
            if (sourceValue.GetType() != targetValue.GetType())
                return false;


            if (sourceValue is string)
            {
                if (!string.Equals(sourceValue, targetValue))
                    return false;
            }

            else if (sourceValue is EntityReference)
            {
                var tmpSource = sourceValue as EntityReference;
                var tmpTarget = targetValue as EntityReference;

                if (tmpSource.Id != tmpTarget.Id)
                    return false;

                if (tmpSource.Name != tmpTarget.Name)
                    return false;

                if (tmpSource.LogicalName != tmpTarget.LogicalName)
                    return false;
            }
            
            else if (sourceValue is int)
            {
                if (!int.Equals((int)sourceValue, (int)targetValue))
                    return false;
            }

            else if (sourceValue is Guid)
            {
                if (!Guid.Equals((Guid)sourceValue, (Guid)targetValue))
                    return false;
            }

            else if (sourceValue is double)
            {
                if (!double.Equals((double)sourceValue, (double)targetValue))
                    return false;
            }

            else if (sourceValue is OptionSetValue)
            {
                var tmpSource = sourceValue as OptionSetValue;
                var tmpTarget = targetValue as OptionSetValue;

                if (tmpSource.Value != tmpTarget.Value)
                    return false;
            }

            else if (sourceValue is bool)
            {
                if (!bool.Equals((bool)sourceValue, (bool)targetValue))
                    return false;
            }

            else if (sourceValue is DateTime)
            {
                if (!DateTime.Equals((DateTime)sourceValue, (DateTime)targetValue))
                    return false;
            }

            else if (sourceValue is decimal)
            {
                if (!decimal.Equals((decimal)sourceValue, (decimal)targetValue))
                    return false;
            }

            else if (sourceValue is long)
            {
                if (!long.Equals((long)sourceValue, (long)targetValue))
                    return false;
            }

            else if (sourceValue is Money)
            {
                var tmpSource = sourceValue as Money;
                var tmpTarget = targetValue as Money;

                if (tmpSource.Value != tmpTarget.Value)
                    return false;
            }


            return true;
        }
    }
}
