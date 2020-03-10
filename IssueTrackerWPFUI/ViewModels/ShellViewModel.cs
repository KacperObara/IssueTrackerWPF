using Caliburn.Micro;

namespace IssueTrackerWPFUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        public ShellViewModel()
        {
            ExistingIssues();
        }
        public void ExistingIssues()
        {
            ActivateItem(new ShellGridViewModel());
        }        
        
        public void NewIssue()
        {
            ActivateItem(new NewIssueViewModel());
        }

        public void NewPerson()
        {
            ActivateItem(new RegisterUserViewModel());
        }
    }
}
