using System;

namespace Octopus.Data.Resources.Attributes
{
    /// <summary>
    /// Use this attribute to specify whether a given property is applicable based on the value of another property
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyApplicabilityAttribute : Attribute
    {
        internal PropertyApplicabilityAttribute(PropertyApplicabilityMode mode, string propertyName, object propertyValue)
        {
            Mode = mode;
            PropertyName = propertyName;
            PropertyValue = propertyValue;
        }
        
        public PropertyApplicabilityMode Mode { get; }
        
        /// <summary>
        /// The name of the property that the property the attribute has been applied to depends on
        /// </summary>
        public string PropertyName { get; }
        
        public object PropertyValue { get; }
    }

    public class ApplicableWhenAnyValueAttribute : PropertyApplicabilityAttribute
    {
        public ApplicableWhenAnyValueAttribute(string propertyName) : 
            base(PropertyApplicabilityMode.ApplicableIfHasAnyValue, propertyName, null)
        {}
    }

    public class ApplicableWhenNoValueAttribute : PropertyApplicabilityAttribute
    {
        public ApplicableWhenNoValueAttribute(string propertyName) : 
            base(PropertyApplicabilityMode.ApplicableIfHasNoValue, propertyName, null)
        {}
    }

    public class ApplicableWhenSpecificValueAttribute : PropertyApplicabilityAttribute
    {
        public ApplicableWhenSpecificValueAttribute(string propertyName, object propertyValue) : 
            base(PropertyApplicabilityMode.ApplicableIfSpecificValue, propertyName, propertyValue)
        {}
    }

    public class ApplicableWhenNotSpecificValueAttribute : PropertyApplicabilityAttribute
    {
        public ApplicableWhenNotSpecificValueAttribute(string propertyName, object propertyValue) : 
            base(PropertyApplicabilityMode.ApplicableIfNotSpecificValue, propertyName, propertyValue)
        {}
    }
}