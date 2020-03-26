using Caliburn.Micro;
using FluentValidation.Results;
using IssueTrackerWPFUI.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TrackerLibrary;
using TrackerLibrary.Models;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace IssueTrackerWPFUI.ViewModels
{
    public class LoginViewModel : PropertyChangedBase
    {
        ShellViewModel shellViewModel;

        public LoginViewModel(ShellViewModel shellViewModel)
        {
            this.shellViewModel = shellViewModel;
        }

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

        /// <summary>
        /// Function that binds PasswordBox and UserPassword. Can't be binded automatically,
        /// because Caliburn.Micro doesn't work with PasswordBoxes.
        /// </summary>
        /// <param name="source">PasswordBox containing user password</param>
        public void OnPasswordChanged(PasswordBox source)
        {
            UserPassword = source.Password;
        }

        public void Login()
        {
            PersonModel person = new PersonModel(UserLogin);
            PasswordModel password = new PasswordModel(UserPassword);

            if (Validator.Validate(person, new PersonValidator(), "Login")
             && Validator.Validate(password, new PasswordValidator()) == true)
            {
                password.Hash();
                if (GlobalConfig.Connection.Authenticate(person.Login, password.Password))
                {
                    person = GlobalConfig.Connection.GetPersonByLogin(person);
                    shellViewModel.LoggedUser = person;
                    shellViewModel.ShowIssues();
                }
                else
                {
                    MessageBox.Show("Wrong username or password");
                }
            }
        }

        public void Register()
        {
            shellViewModel.Register();
        }
    }
}
