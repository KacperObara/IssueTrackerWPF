using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace IssueTrackerWPFUI.ViewModels
{
    public class EditIssueViewModel : PropertyChangedBase
    {
        IssueModel issueModel;

        public EditIssueViewModel(IssueModel issueModel)
        {
            this.issueModel = issueModel;


        }
    }
}
