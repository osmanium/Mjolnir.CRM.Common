using Microsoft.Xrm.Sdk.Metadata;
using Mjolnir.CRM.Sdk.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Sdk.Extensions
{
    public static class EntityMetadataExtensions
    {
        //Entity Metadata Compare
        public static ComparisonResult CompareMetadata(this EntityMetadata sourceMetadata, EntityMetadata targetMetadata, EntityMetadataComparisonConfiguration comparisonConfig = null)
        {
            switch (comparisonConfig.EntityFilters)
            {
                case EntityFilters.Entity:
                    return CompareEntityMetadata(sourceMetadata, targetMetadata, comparisonConfig);
                case EntityFilters.Attributes:
                    return CompareAttributes(sourceMetadata, targetMetadata, comparisonConfig);
                case EntityFilters.Privileges:
                    return ComparePrivileges(sourceMetadata, targetMetadata, comparisonConfig);
                case EntityFilters.Relationships:
                    return CompareRelatonships(sourceMetadata, targetMetadata, comparisonConfig);
                case EntityFilters.All:
                    return CompareAllMetadata(sourceMetadata, targetMetadata, comparisonConfig);
            }

            return CompareEntityMetadata(sourceMetadata, targetMetadata, comparisonConfig);
        }

        private static ComparisonResult CompareEntityMetadata(EntityMetadata sourceMetadata, EntityMetadata targetMetadata, EntityMetadataComparisonConfiguration comparisonConfig = null)
        {
            //TODO : Iterate properties with reflection and compare values


            return null;
        }

        //TODO : Entity Attribute Compare
        private static ComparisonResult CompareAttributes(EntityMetadata sourceMetadata, EntityMetadata targetMetadata, EntityMetadataComparisonConfiguration comparisonConfig = null)
        {
            //TODO : Iterate attribute types

            return null;
        }

        //TODO : Entity Priviletes Metadata Compare
        public static ComparisonResult ComparePrivileges(EntityMetadata sourceMetadata, EntityMetadata targetMetadata, EntityMetadataComparisonConfiguration comparisionConfig = null)
        {

            return null;
        }

        //TODO : Entity Relationships compare
        public static ComparisonResult CompareRelatonships(EntityMetadata sourceMetadata, EntityMetadata targetMetadata, EntityMetadataComparisonConfiguration comparisionConfig = null)
        {

            //TODO : N:N relationships may have Mappings, compare these as well

            return null;
        }

        //TODO : All Metadata Compare
        public static ComparisonResult CompareAllMetadata(EntityMetadata sourceMetadata, EntityMetadata targetMetadata, EntityMetadataComparisonConfiguration comparisionConfig = null)
        {

            return null;
        }


        //TODO : Move below form copares to another class

        //TODO : Entity Specific Form Compare

        //TODO : Entity All Forms Compare

    }
}