using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using System.Text.RegularExpressions;
using TrackerLibrary.Models;

namespace IssueTrackerWPFUI.Validators
{
    public class PasswordValidator : AbstractValidator<PasswordModel>
    {
        public PasswordValidator()
        {
            RuleFor(p => p.Password)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Password cannot be empty")
                .Length(6, 20).WithMessage("Password is either too short or too long");
        }
    }
}
