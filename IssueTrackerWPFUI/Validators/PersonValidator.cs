using FluentValidation;
using System;
using System.Text.RegularExpressions;
using TrackerLibrary.Models;

namespace IssueTrackerWPFUI.Validators
{
    public class PersonValidator : AbstractValidator<PersonModel>
    {
        public PersonValidator()
        {
            RuleFor(p => p.Login)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .Length(3, 20)
                .Must(BeAValidLogin).WithMessage("Login cannot start with number");

            //RuleFor(p => p.Password)
            //    .Cascade(CascadeMode.StopOnFirstFailure)
            //    .NotEmpty()
            //    .Length(6, 20).WithMessage("Password is either too short or too long");

            RuleFor(p => p.Email)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .Must(BeAValidEmail).WithMessage("Not a valid Email adress");
        }

        private static bool BeAValidLogin(string login)
        {
            login = login.Replace(" ", "");
            return Char.IsLetter(login[0]);
        }

        private static bool BeAValidEmail(string email)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            if (regex.IsMatch(email) == false)
            {
                return false;
            }
            return true;
        }
    }
}
