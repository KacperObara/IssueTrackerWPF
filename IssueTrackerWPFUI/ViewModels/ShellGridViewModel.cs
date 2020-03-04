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
    class ShellGridViewModel
    {
        public BindableCollection<IssueModel> Issues { get; private set; }

        public ShellGridViewModel()
        {
            Issues = new BindableCollection<IssueModel>(GlobalConfig.Connection.GetIssues());
        }
    }
}
