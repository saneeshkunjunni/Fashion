using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

public class NumericGreaterThanAttribute : ValidationAttribute, IClientValidatable
{
    private const string GreaterThanErrorMessage = "{0} must be greater than {1}.";
    private const string GreaterThanOrEqualToErrorMessage = "{0} must be greater than or equal to {1}.";

    public string OtherProperty { get; private set; }

    private bool allowEquality;

    public bool AllowEquality
    {
        get { return this.allowEquality; }
        set
        {
            this.allowEquality = value;

            // Set the error message based on whether or not
            // equality is allowed
            this.ErrorMessage = (value ? GreaterThanOrEqualToErrorMessage : GreaterThanErrorMessage);
        }
    }
    public NumericGreaterThanAttribute(string otherProperty)
        : base(GreaterThanErrorMessage)
    {
        if (otherProperty == null) { throw new ArgumentNullException("otherProperty"); }
        this.OtherProperty = otherProperty;
    }
    public override string FormatErrorMessage(string name)
    {
        return String.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, this.OtherProperty);
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        PropertyInfo otherPropertyInfo = validationContext.ObjectType.GetProperty(OtherProperty);

        if (otherPropertyInfo == null)
        {
            return new ValidationResult(String.Format(CultureInfo.CurrentCulture, "Could not find a property named {0}.", OtherProperty));
        }

        object otherPropertyValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);

        decimal decValue;
        decimal decOtherPropertyValue;

        // Check to ensure the validating property is numeric
        if (!decimal.TryParse(value.ToString(), out decValue))
        {
            return new ValidationResult(String.Format(CultureInfo.CurrentCulture, "{0} is not a numeric value.", validationContext.DisplayName));
        }

        // Check to ensure the other property is numeric
        if (!decimal.TryParse(otherPropertyValue.ToString(), out decOtherPropertyValue))
        {
            return new ValidationResult(String.Format(CultureInfo.CurrentCulture, "{0} is not a numeric value.", OtherProperty));
        }

        // Check for equality
        if (AllowEquality && decValue == decOtherPropertyValue)
        {
            return null;
        }
        // Check to see if the value is greater than the other property value
        else if (decValue < decOtherPropertyValue)
        {
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }

        return null;
    }
    public static string FormatPropertyForClientValidation(string property)
    {
        if (property == null)
        {
            throw new ArgumentException("Value cannot be null or empty.", "property");
        }
        return "*." + property;
    }
    public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
    {
        ModelClientValidationRule mvr = new ModelClientValidationRule();
        mvr.ErrorMessage = FormatErrorMessage(metadata.DisplayName);
        mvr.ValidationType = "numericgreaterthan";
        mvr.ValidationParameters["other"] = FormatPropertyForClientValidation(this.OtherProperty);
        mvr.ValidationParameters["allowequality"] = this.AllowEquality;
        yield return mvr;
    }
}

