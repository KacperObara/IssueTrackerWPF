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
    public class ShellGridViewModel : PropertyChangedBase
    {
        private ShellViewModel shellViewModel;

        public IssueModel SelectedIssue
        {
            get
            {
                return shellViewModel.SelectedIssue;
            }
            set
            {
                shellViewModel.SelectedIssue = value;
            }
        }

        public BindableCollection<IssueModel> Issues { get; private set; }


        public ShellGridViewModel(ShellViewModel shellViewModel)
        {
            this.shellViewModel = shellViewModel;
            Issues = new BindableCollection<IssueModel>(GlobalConfig.Connection.GetIssues());
        }
    }
}
