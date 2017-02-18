using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Core
{
    public class EntityBase : Entity
    {
        public EntityBase(string entityName)
            : base(entityName)
        {
        }

        public string GetStringAttributeValue(string attributeKey)
        {
            if (Attributes.ContainsKey(attributeKey))
                return this.GetAttributeValue<string>(attributeKey);
            else return string.Empty;
        }

        public int GetIntigerAttributeValue(string attributeKey)
        {
            if (Attributes.ContainsKey(attributeKey))
                return this.GetAttributeValue<int>(attributeKey);
            else return 0;
        }

        public Money GetMoneyAttributeValue(string attributeKey)
        {
            if (Attributes.ContainsKey(attributeKey))
                return this.GetAttributeValue<Money>(attributeKey);
            else return new Money(0);
        }

        public bool GetBoolAttributeValue(string attributeKey)
        {
            if (Attributes.ContainsKey(attributeKey))
                return this.GetAttributeValue<bool>(attributeKey);
            else return false;
        }

        public DateTime GetDateTimeAttributeValue(string attributeKey)
        {
            if (Attributes.ContainsKey(attributeKey))
                return this.GetAttributeValue<DateTime>(attributeKey);
            else return DateTime.MinValue;
        }

        public decimal GetDecimalAttributeValue(string attributeKey)
        {
            if (Attributes.ContainsKey(attributeKey))
                return this.GetAttributeValue<decimal>(attributeKey);
            else return 0;
        }

        public EntityReference GetEntityReferenceAttributeValue(string attributeKey)
        {
            if (Attributes.ContainsKey(attributeKey))
                return this.GetAttributeValue<EntityReference>(attributeKey);
            else return null;
        }

        public OptionSetValue GetOptionSetValueAttributeValue(string attributeKey)
        {
            if (Attributes.ContainsKey(attributeKey))
                return this.GetAttributeValue<OptionSetValue>(attributeKey);
            else return null;
        }
    }
}
