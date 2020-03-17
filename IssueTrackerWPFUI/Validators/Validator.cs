using FluentValidation;
using FluentValidation.Results;
using System.Windows;

namespace IssueTrackerWPFUI.Validators
{
    public static class Validator
    {
        public static bool Validate<T, U>(T model, U validator, string ruleset = "*") where U : AbstractValidator<T>
        {
            ValidationResult results = validator.Validate(model, ruleSet: ruleset);

            if (results.IsValid == false)
            {
                string errorList = "";
                foreach (ValidationFailure failure in results.Errors)
                {
                    errorList += $"{failure.PropertyName}: {failure.ErrorMessage} \n";
                }
                MessageBox.Show(errorList);

                return false;
            }

            return true;
        }
    }
}
