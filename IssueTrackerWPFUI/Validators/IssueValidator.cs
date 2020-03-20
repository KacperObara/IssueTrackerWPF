using FluentValidation;
using System;
using TrackerLibrary.Models;

namespace IssueTrackerWPFUI.Validators
{
    public class IssueValidator : AbstractValidator<IssueModel>
    {
        public IssueValidator()
        {
            RuleFor(p => p.Title)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .Length(3, 20).WithMessage("Title is either too short or too long");

            RuleFor(p => p.Description)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .Length(3, 200).WithMessage("Description is either too short or too long");

            RuleFor(p => p.CreationDate)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.Now);

            RuleFor(p => p.Severity)
                .NotEmpty();
        }
    }
}
