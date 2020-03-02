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
    public class NewIssueViewModel
    {
        public BindableCollection<SeverityModel> Severities { get; private set; }
        public BindableCollection<SeverityModel> People { get; private set; }

        public NewIssueViewModel()
        {
            Severities = new BindableCollection<SeverityModel>(GlobalConfig.Connection.GetSeverities());
            People = new BindableCollection<PersonModel>(GlobalConfig.Connection.GetPeople());
        }

        public void AddIssue()
        {

        }

        //private void CreateIssue()
        //{
        //    if (ValidateForm())
        //    {
        //        // Get Text from RichTextBox
        //        string DescriptionText = new TextRange(DescriptionBox.Document.ContentStart, DescriptionBox.Document.ContentEnd).Text;

        //        IssueModel model = new IssueModel(TitleBox.Text,
        //                                          DescriptionText,
        //                                          DateTime.Now);

        //        GlobalConfig.Connection.CreateIssue(model);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Invalid form.");
        //    }
        //}

        //private bool ValidateForm()
        //{
        //    bool output = true;

        //    if (TitleBox.Text.Length < 3)
        //        output = false;

        //    // Get Text from RichTextBox
        //    string DescriptionText = new TextRange(DescriptionBox.Document.ContentStart, DescriptionBox.Document.ContentEnd).Text;

        //    if (DescriptionText.Length < 3)
        //        output = false;

        //    //if (SeverityBox.SelectedItem == null)
        //    //    output = false;

        //    return output;
        //}
    }
}
