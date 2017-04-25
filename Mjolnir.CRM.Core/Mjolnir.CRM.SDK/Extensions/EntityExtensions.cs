using Microsoft.Xrm.Sdk;
using Mjolnir.CRM.Sdk.ValueObjects;
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

        public static EntityComparisionResult Compare(this Entity sourceEntity, Entity targetEntity, EntityComparisionConfiguration comparisionConfig = null)
        {
            var isEqual = false;
            var reasons = new List<string>();

            if (comparisionConfig == null)
                comparisionConfig = EntityComparisionConfiguration.Default;

            if (sourceEntity.Id != targetEntity.Id)
            {
                reasons.Add($"Id's are different");
                if (!comparisionConfig.IsFullComparision)
                    return new EntityComparisionResult(isEqual, reasons);
            }

            if (sourceEntity.LogicalName != targetEntity.LogicalName)
            {
                reasons.Add($"LogicalName'a are different");
                if (!comparisionConfig.IsFullComparision)
                    return new EntityComparisionResult(isEqual, reasons);
            }

            foreach (var sourceKey in sourceEntity.Attributes.Keys)
            {
                if (targetEntity.Contains(sourceKey))
                {
                    if (!CompareValue(sourceEntity[sourceKey], targetEntity[sourceKey]))
                    {
                        reasons.Add($"{sourceKey} Attributes are different, source : {sourceEntity[sourceKey]}, target {targetEntity[sourceKey]}");
                        if (!comparisionConfig.IsFullComparision)
                            return new EntityComparisionResult(isEqual, reasons);
                    }
                }
                else
                {
                    reasons.Add($"Target does not contain key {sourceKey}");
                    if (!comparisionConfig.IsFullComparision)
                        return new EntityComparisionResult(isEqual, reasons);
                }
            }

            isEqual = true;

            return new EntityComparisionResult(isEqual, reasons);
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

            else if (sourceValue is AliasedValue)
            {
                var tmpSource = sourceValue as AliasedValue;
                var tmpTarget = targetValue as AliasedValue;

                return CompareValue(tmpSource.Value, tmpTarget.Value);
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

            else if (sourceValue is Money)
            {
                var tmpSource = sourceValue as Money;
                var tmpTarget = targetValue as Money;

                if (tmpSource.Value != tmpTarget.Value)
                    return false;
            }

            else if (sourceValue is long)
            {
                if (!long.Equals((long)sourceValue, (long)targetValue))
                    return false;
            }

            else if (sourceValue is double)
            {
                if (!double.Equals((double)sourceValue, (double)targetValue))
                    return false;
            }

            //TODO : Check for customer lookup is regular lookup

            return true;
        }
    }
}
