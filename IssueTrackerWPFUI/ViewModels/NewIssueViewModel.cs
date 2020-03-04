using Caliburn.Micro;
using FluentValidation.Results;
using IssueTrackerWPFUI.Validators;
using System;
using System.Windows;
using TrackerLibrary;
using TrackerLibrary.Models;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace IssueTrackerWPFUI.ViewModels
{
    public class NewIssueViewModel : PropertyChangedBase
    {
        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                NotifyOfPropertyChange(() => Title);
            }
        }

        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                NotifyOfPropertyChange(() => Description);
            }
        }

        private PersonModel _assignee;
        public PersonModel Assignee
        {
            get
            {
                return _assignee;
            }
            set
            {
                _assignee = value;
                NotifyOfPropertyChange(() => Assignee);
            }
        }

        private SeverityModel _activeSeverity;
        public SeverityModel ActiveSeverity
        {
            get
            {
                return _activeSeverity;
            }
            set
            {
                _activeSeverity = value;
                NotifyOfPropertyChange(() => ActiveSeverity);
            }
        }

        public BindableCollection<SeverityModel> Severities { get; private set; }
        public BindableCollection<PersonModel> People { get; private set; }

        public NewIssueViewModel()
        {
            Severities = new BindableCollection<SeverityModel>(GlobalConfig.Connection.GetSeverities());
            People = new BindableCollection<PersonModel>(GlobalConfig.Connection.GetPeople());
        }

        public void AddIssue()
        {
            IssueModel issue = new IssueModel(Title, Description, DateTime.Now, Assignee, ActiveSeverity);

            if (ValidateForm(issue) == true)
            {
                GlobalConfig.Connection.CreateIssue(issue);
            }
        }

        private static bool ValidateForm(IssueModel issue)
        {
            IssueValidator validator = new IssueValidator();
            ValidationResult results = validator.Validate(issue);

            // Shows errors in MessageBox (TODO: Change it so it doesn't violate DRY)
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
