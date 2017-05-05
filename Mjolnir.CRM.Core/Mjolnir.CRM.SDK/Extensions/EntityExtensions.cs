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

        public static T ToSpecificEntity<T>(this Entity sourceEntity)
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

        public static ComparisonResult CompareValues(this Entity sourceEntity, Entity targetEntity, EntityComparisonConfiguration comparisonConfig = null)
        {
            ComparisonResult comparisonResult = null;
            var comparisonErrors = new List<ComparisonError>();

            if (comparisonConfig == null)
                comparisonConfig = EntityComparisonConfiguration.Default;

            if (sourceEntity.Id != targetEntity.Id)
            {
                comparisonErrors.Add(new ComparisonError(GetValueInString(sourceEntity.Id), GetValueInString(targetEntity.Id), $"Id's are different"));
                if (!comparisonConfig.ContinueOnDifference)
                    return new ComparisonResult(false, comparisonErrors);
            }

            if (sourceEntity.LogicalName != targetEntity.LogicalName)
            {
                comparisonErrors.Add(new ComparisonError(sourceEntity.LogicalName, targetEntity.LogicalName, $"LogicalName'a are different"));
                if (!comparisonConfig.ContinueOnDifference)
                    return new ComparisonResult(false, comparisonErrors);
            }

            foreach (var sourceKey in sourceEntity.Attributes.Keys)
            {
                if (comparisonConfig.IgnoredAttributeKeys.Contains(sourceKey))
                    continue;

                if (targetEntity.Contains(sourceKey))
                {
                    if (!CompareValue(sourceEntity[sourceKey], targetEntity[sourceKey]))
                    {
                        comparisonErrors.Add(new ComparisonError(GetValueInString(sourceEntity[sourceKey]), GetValueInString(targetEntity[sourceKey]), $"{sourceKey} attributes have different values"));
                        if (!comparisonConfig.ContinueOnDifference)
                            return new ComparisonResult(false, comparisonErrors);
                    }
                }
                else
                {
                    comparisonErrors.Add(new ComparisonError(GetValueInString(sourceEntity[sourceKey]), null, $"Target does not contain key {sourceKey}"));
                    if (!comparisonConfig.ContinueOnDifference)
                        return new ComparisonResult(false, comparisonErrors);
                }
            }

            //Check only keys which are in target but not in source
            foreach (var targetKey in targetEntity.Attributes.Where(w => !sourceEntity.Attributes.Keys.Contains(w.Key)))
            {
                if (comparisonConfig.IgnoredAttributeKeys.Contains(targetKey.Key))
                    continue;

                comparisonErrors.Add(new ComparisonError(null, GetValueInString(targetEntity[targetKey.Key]), $"Source does not contain key {targetKey.Key}"));
                if (!comparisonConfig.ContinueOnDifference)
                    return new ComparisonResult(false, comparisonErrors);
            }


            if (comparisonResult != null)
                return comparisonResult;
            else
                return new ComparisonResult(true, null);
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

        public static string GetValueInString(object valueObject)
        {
            if (valueObject == null)
            {
                return "{null}";
            }

            else if (valueObject is string)
            {
                return valueObject as string;
            }

            else if (valueObject is EntityReference)
            {
                var tmpObject = valueObject as EntityReference;

                return $"{{Id: {tmpObject.Id}, Name: {tmpObject.Name}, LogicalName: {tmpObject.LogicalName}}}";
            }

            else if (valueObject is AliasedValue)
            {
                return GetValueInString(valueObject as AliasedValue);
            }

            else if (valueObject is int)
            {
                return ((int)valueObject).ToString();
            }

            else if (valueObject is Guid)
            {
                return ((Guid)valueObject).ToString();
            }

            else if (valueObject is OptionSetValue)
            {
                return (valueObject as OptionSetValue).Value.ToString();
            }

            else if (valueObject is bool)
            {
                return ((bool)valueObject).ToString();
            }

            else if (valueObject is DateTime)
            {
                return ((DateTime)valueObject).Ticks.ToString();
            }

            else if (valueObject is decimal)
            {
                return ((decimal)valueObject).ToString();
            }

            else if (valueObject is Money)
            {
                return ((Money)valueObject).Value.ToString();
            }

            else if (valueObject is long)
            {
                return ((long)valueObject).ToString();
            }

            else if (valueObject is double)
            {
                return ((double)valueObject).ToString();
            }


            return $"Not Implemented Type for String: {valueObject.GetType()}";
        }
    }
}
