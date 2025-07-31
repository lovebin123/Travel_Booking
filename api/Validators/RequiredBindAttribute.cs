using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace api.Validators
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter, AllowMultiple = false)]
    public class SmartRequiredAttribute : ValidationAttribute, IModelNameProvider, IPropertyValidationFilter
    {
        private readonly RequiredAttribute _required = new RequiredAttribute();

        public string? Name { get; set; }

        public SmartRequiredAttribute()
        {
            ErrorMessage = "This field is required.";
        }

        public override bool IsValid(object? value)
        {
            return _required.IsValid(value);
        }

        public override string FormatErrorMessage(string name)
        {
            return _required.FormatErrorMessage(name);
        }

        public bool ShouldValidateEntry(ValidationEntry entry, ValidationEntry parentEntry)
        {
            return true;
        }
    }
}
