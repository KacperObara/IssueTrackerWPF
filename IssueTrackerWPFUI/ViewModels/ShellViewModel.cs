using Caliburn.Micro;
using System.Windows;
using TrackerLibrary.Models;

namespace IssueTrackerWPFUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private IssueModel _selectedIssue;
        public IssueModel SelectedIssue
        {
            get
            {
                return _selectedIssue;
            }
            set
            {
                _selectedIssue = value;
                NotifyOfPropertyChange(() => SelectedIssue);
            }
        }

        private PersonModel _loggedUser;
        public PersonModel LoggedUser
        {
            get
            {
                return _loggedUser;
            }
            set
            {
                _loggedUser = value;
                NotifyOfPropertyChange(() => LoggedUser);
            }
        }

        public ShellViewModel()
        {
            Login();
        }
        public void ShowIssues()
        {
            ActivateItem(new ShellGridViewModel(this));
        }        
        
        public void CreateIssue()
        {
            if (LoggedUser == null)
            {
                ActivateItem(new LoginViewModel(this));
            }
            else
            {
                ActivateItem(new CreateIssueViewModel(this));
            }
        }

        public void Register()
        {
            ActivateItem(new RegisterUserViewModel(this));
        }

        public void Login()
        {
            ActivateItem(new LoginViewModel(this));
        }

        public void EditIssue()
        {
            if(SelectedIssue != null)
            {
                ActivateItem(new EditIssueViewModel(this));
            }
            else
            {
                MessageBox.Show("No issue selected");
            }

        }
    }
}
