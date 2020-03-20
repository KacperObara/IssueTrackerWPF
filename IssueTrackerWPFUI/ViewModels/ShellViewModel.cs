using Caliburn.Micro;
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
            ShowIssues();
        }
        public void ShowIssues()
        {
            ActivateItem(new ShellGridViewModel(this));
        }        
        
        public void CreateIssue()
        {
            ActivateItem(new CreateIssueViewModel(LoggedUser));
        }

        public void Register()
        {
            ActivateItem(new RegisterUserViewModel());
        }

        public void Login()
        {
            ActivateItem(new LoginViewModel(this));
        }

        public void EditIssue()
        {
            ActivateItem(new EditIssueViewModel(SelectedIssue));
        }
    }
}
