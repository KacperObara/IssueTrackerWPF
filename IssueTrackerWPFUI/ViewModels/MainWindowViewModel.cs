using Caliburn.Micro;
using IssueTrackerWPFUI.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTrackerWPFUI.ViewModels
{
    public class MainWindowViewModel : Conductor<object>
    {
        public void NewIssue()
        {
            ActivateItem(new NewIssueViewModel());
        }

        public void NewPerson()
        {
            ActivateItem(new NewPersonViewModel());
        }
    }
}
