using Caliburn.Micro;
using FluentValidation.Results;
using IssueTrackerWPFUI.Validators;
using System;
using System.Collections.Generic;
using System.Windows;
using TrackerLibrary;
using TrackerLibrary.Models;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace IssueTrackerWPFUI.ViewModels
{
    public class CreateIssueViewModel : PropertyChangedBase
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

        private PersonModel _author;
        public PersonModel Author
        {
            get
            {
                return _author;
            }
            set
            {
                _author = value;
                NotifyOfPropertyChange(() => Author);
            }
        }

        private List<PersonModel> _assignees;
        public List<PersonModel> Assignees
        {
            get
            {
                return _assignees;
            }
            set
            {
                _assignees = value;
                NotifyOfPropertyChange(() => Assignees);
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

        private StatusModel _status;
        public StatusModel Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                NotifyOfPropertyChange(() => Status);
            }
        }

        public BindableCollection<SeverityModel> Severities { get; private set; }
        public BindableCollection<PersonModel> People { get; private set; }

        public CreateIssueViewModel()
        {
            Severities = new BindableCollection<SeverityModel>(GlobalConfig.Connection.GetSeverities());
            People = new BindableCollection<PersonModel>(GlobalConfig.Connection.GetPeople());
        }

        public void AddIssue()
        {
            IssueModel issue = new IssueModel(Title, Description, DateTime.Now);

            if (Validator.Validate(issue, new IssueValidator()) == true)
            {
                GlobalConfig.Connection.CreateIssue(issue);
            }
        }
    }
}
