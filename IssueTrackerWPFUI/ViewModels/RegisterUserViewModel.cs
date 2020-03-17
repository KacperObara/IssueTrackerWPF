using Caliburn.Micro;
using FluentValidation;
using FluentValidation.Results;
using IssueTrackerWPFUI.Validators;
using System;
using System.Windows;
using System.Windows.Controls;
using TrackerLibrary;
using TrackerLibrary.Models;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace IssueTrackerWPFUI.ViewModels
{
    public class RegisterUserViewModel : PropertyChangedBase
    {
        private string _userLogin;
        public string UserLogin
        {
            get
            {
                return _userLogin;
            }
            set
            {
                _userLogin = value;
                NotifyOfPropertyChange(() => UserLogin);
            }
        }

        private string _userPassword;
        public string UserPassword
        {
            get
            {
                return _userPassword;
            }
            set
            {
                _userPassword = value;
                NotifyOfPropertyChange(() => UserPassword);
            }
        }

        private string _userEmail;
        public string UserEmail
        {
            get
            {
                return _userEmail;
            }
            set
            {
                _userEmail = value;
                NotifyOfPropertyChange(() => UserEmail);
            }
        }

        /// <summary>
        /// Function that binds PasswordBox and UserPassword. Can't be binded automatically,
        /// because Caliburn.Micro doesn't work with PasswordBoxes.
        /// </summary>
        /// <param name="source">PasswordBox containing user password</param>
        public void OnPasswordChanged(PasswordBox source)
        {
            UserPassword = source.Password;
        }

        public void AddPerson()
        {
            PersonModel person = new PersonModel(UserLogin, UserEmail);
            PasswordModel password = new PasswordModel(UserPassword);

            if (Validator.Validate(person, new PersonValidator(), "Login") == true 
             && Validator.Validate(password, new PasswordValidator()) == true)
            {
                GlobalConfig.Connection.CreatePerson(person, password);
            }
        }
    }
}
