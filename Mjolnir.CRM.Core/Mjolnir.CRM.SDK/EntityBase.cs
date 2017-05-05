using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Sdk
{
    public class EntityBase : Entity
    {
        public string Alias { get; private set; }
        public bool IsAliased { get; private set; }

        #region CTORS
        public EntityBase(string entityName)
            : base(entityName)
        {
        }

        public EntityBase(string entityName, AttributeCollection attributes, string alias = null)
            : base(entityName)
        {
            this.Attributes = new AttributeCollection();

            if (string.IsNullOrWhiteSpace(alias))
            {
                //Get only attributes without alias
                Attributes.AddRange(attributes.Where(w => !w.Key.Contains('.')));
            }
            else
            {
                this.Alias = alias;
                IsAliased = true;

                //Get only attributes with alias
                Attributes.AddRange(attributes.Where(w => w.Key.StartsWith($"{alias}."))
                                                               .Select(s => new KeyValuePair<string, object>(s.Key.TrimStart($"{alias}.".ToCharArray()), s.Value)));
            }
        }
        #endregion


        #region GetAttribute Helpers

        public Guid? GetGuidAttributeValue(string attributeKey)
        {
            if (Attributes.ContainsKey(attributeKey))
            {
                if (IsAliased)
                {
                    return (Guid)this.GetAliasedValue(attributeKey).Value;
                }
                else
                {
                    return this.GetAttributeValue<Guid>(attributeKey);
                }
            }
            else return null;
        }

        public string GetStringAttributeValue(string attributeKey)
        {
            if (Attributes.ContainsKey(attributeKey))
            {
                if (IsAliased)
                {
                    return (string)this.GetAliasedValue(attributeKey).Value;
                }
                else
                {
                    return this.GetAttributeValue<string>(attributeKey);
                }
            }
            else return null;
        }

        public int? GetIntigerAttributeValue(string attributeKey)
        {
            if (Attributes.ContainsKey(attributeKey))
            {
                if (IsAliased)
                {
                    return (int)this.GetAliasedValue(attributeKey).Value;
                }
                else
                {
                    return this.GetAttributeValue<int>(attributeKey);
                }
            }
            else return null;
        }

        public Money GetMoneyAttributeValue(string attributeKey)
        {
            if (Attributes.ContainsKey(attributeKey))
            {
                if (IsAliased)
                {
                    return (Money)this.GetAliasedValue(attributeKey).Value;
                }
                else
                {
                    return this.GetAttributeValue<Money>(attributeKey);
                }
            }
            else return null;
        }

        public bool? GetBoolAttributeValue(string attributeKey)
        {
            if (Attributes.ContainsKey(attributeKey))
            {
                if (IsAliased)
                {
                    return (bool)this.GetAliasedValue(attributeKey).Value;
                }
                else
                {
                    return this.GetAttributeValue<bool>(attributeKey);
                }
            }
            else return null;
        }

        public DateTime? GetDateTimeAttributeValue(string attributeKey)
        {
            if (Attributes.ContainsKey(attributeKey))
            {
                if (IsAliased)
                {
                    return (DateTime)this.GetAliasedValue(attributeKey).Value;
                }
                else
                {
                    return this.GetAttributeValue<DateTime>(attributeKey);
                }
            }
            else return null;
        }

        public decimal? GetDecimalAttributeValue(string attributeKey)
        {
            if (Attributes.ContainsKey(attributeKey))
            {
                if (IsAliased)
                {
                    return (decimal)this.GetAliasedValue(attributeKey).Value;
                }
                else
                {
                    return this.GetAttributeValue<decimal>(attributeKey);
                }
            }
            else return null;
        }

        public EntityReference GetEntityReferenceAttributeValue(string attributeKey)
        {
            if (Attributes.ContainsKey(attributeKey))
            {
                if (IsAliased)
                {
                    return (EntityReference)this.GetAliasedValue(attributeKey).Value;
                }
                else
                {
                    return this.GetAttributeValue<EntityReference>(attributeKey);
                }
            }
            else return null;
        }

        public OptionSetValue GetOptionSetValueAttributeValue(string attributeKey)
        {
            if (Attributes.ContainsKey(attributeKey))
            {
                if (IsAliased)
                {
                    return (OptionSetValue)this.GetAliasedValue(attributeKey).Value;
                }
                else
                {
                    return this.GetAttributeValue<OptionSetValue>(attributeKey);
                }
            }
            else return null;
        }
        
        public AliasedValue GetAliasedValue(string attributeKey)
        {
            if (Attributes.ContainsKey(attributeKey))
                return this.GetAttributeValue<AliasedValue>(attributeKey);
            else return null;
        }

        #endregion
        
    }
}
