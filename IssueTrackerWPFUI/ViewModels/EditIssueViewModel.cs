using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace IssueTrackerWPFUI.ViewModels
{
    public class EditIssueViewModel : PropertyChangedBase
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

        //private List<PersonModel> _assignees;
        //public List<PersonModel> Assignees
        //{
        //    get
        //    {
        //        return _assignees;
        //    }
        //    set
        //    {
        //        _assignees = value;
        //        NotifyOfPropertyChange(() => Assignees);
        //    }
        //}

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

        private StatusModel _activeStatus;
        public StatusModel ActiveStatus
        {
            get
            {
                return _activeStatus;
            }
            set
            {
                _activeStatus = value;
                NotifyOfPropertyChange(() => ActiveStatus);
            }
        }

        public BindableCollection<PersonModel> Assignees { get; private set; }
        public BindableCollection<SeverityModel> Severities { get; private set; }
        public BindableCollection<StatusModel> Statuses { get; private set; }
        public BindableCollection<PersonModel> People { get; private set; }

        public int DefaultSeverity
        {
            get
            {
                return Severities.Select((item, index) => new { index, item }).Where(x => x.item.Id == ActiveSeverity.Id).First().index;
            }
        }

        public int DefaultStatus
        {
            get
            {
                return Statuses.Select((item, index) => new { index, item }).Where(x => x.item.Id == ActiveStatus.Id).First().index;
            }
        }

        private PersonModel _selectedPerson;
        public PersonModel SelectedPerson
        {
            get
            {
                return _selectedPerson;
            }
            set
            {
                _selectedPerson = value;
                NotifyOfPropertyChange(() => SelectedPerson);
            }
        }

        private PersonModel _selectedAssignee;
        public PersonModel SelectedAssignee
        {
            get
            {
                return _selectedAssignee;
            }
            set
            {
                _selectedAssignee = value;
                NotifyOfPropertyChange(() => SelectedAssignee);
            }
        }

        private IssueModel issueModel;

        public EditIssueViewModel(IssueModel issueModel)
        {
            this.issueModel = issueModel;
            this.Title = issueModel.Title;
            this.Description = issueModel.Description;
            this.ActiveSeverity = issueModel.Severity;
            this.ActiveStatus = issueModel.Status;
            this.Assignees = new BindableCollection<PersonModel>(issueModel.Assignees);

            Severities = new BindableCollection<SeverityModel>(GlobalConfig.Connection.GetSeverities());
            Statuses = new BindableCollection<StatusModel>(GlobalConfig.Connection.GetStatuses());
            People = new BindableCollection<PersonModel>(GlobalConfig.Connection.GetPeople());
        }

        public void RemoveAssignee()
        {
            People.Add(SelectedAssignee);
            Assignees.Remove(SelectedAssignee);
        }

        public void AddAssignee()
        {
            Assignees.Add(SelectedPerson);
            People.Remove(SelectedPerson);
        }

        public void AcceptChanges()
        {
            //IssueModel issueModel = new IssueModel();
        }
    }
}
