using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AttributePlay.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = true)]
    public sealed class GreaterThanAttribute : ValidationAttribute, IClientValidatable
    {
        public string OtherProperty { get; private set; }
        private const string DefaultErrorMessage = "{0} must be greated than {1}.";
        // This is a positional argument
        public GreaterThanAttribute(string otherProperty)
            : base(DefaultErrorMessage)
        {
            if (string.IsNullOrEmpty(otherProperty)) throw new ArgumentNullException("Other property is null");
            this.OtherProperty = otherProperty;

        }


        public override string FormatErrorMessage(string name)
        {
            return string.Format(DefaultErrorMessage, name, OtherProperty);
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var firstComparable = value as IComparable;
            var secondComparable = GetSecondComparable(validationContext);
            if (firstComparable != null && secondComparable != null && firstComparable.CompareTo(secondComparable) < 1)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            return ValidationResult.Success;
        }

        private object GetSecondComparable(ValidationContext validationContext)
        {
            var propertyInfo = validationContext.ObjectType.GetProperty(OtherProperty);
            if (propertyInfo == null) return null;
            var secondValue = propertyInfo.GetValue(validationContext.ObjectInstance, null);
            return secondValue as IComparable;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var clientValidationRule = new ModelClientValidationRule()
            {
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
                ValidationType = "greaterthan"

            };
            clientValidationRule.ValidationParameters.Add("otherproperty", OtherProperty);
            yield return clientValidationRule;
        }
    }
}