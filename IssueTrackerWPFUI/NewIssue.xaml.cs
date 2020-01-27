using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TrackerLibrary;
using TrackerLibrary.DataAcess;
using TrackerLibrary.Models;

namespace IssueTrackerWPFUI
{
    /// <summary>
    /// Interaction logic for NewIssue.xaml
    /// </summary>
    public partial class NewIssue : Window
    {
        public BindableCollection<SeverityModel> Severities { get; private set; }

        public NewIssue()
        {
            InitializeComponent();
        }

        private void LoadSeverityComboBox()
        {
            Severities = new BindableCollection<SeverityModel>(GlobalConfig.Connection.GetSeverities());
        }

        private void CreateIssueButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                // Get Text from RichTextBox
                string DescriptionText = new TextRange(DescriptionBox.Document.ContentStart, DescriptionBox.Document.ContentEnd).Text;

                IssueModel model = new IssueModel(TitleBox.Text,
                                                  DescriptionText,
                                                  DateTime.Now);

                GlobalConfig.Connection.CreateIssue(model);
            }
            else
            {
                MessageBox.Show("Invalid form.");
            }
        }

        private bool ValidateForm()
        {
            bool output = true;

            if (TitleBox.Text.Length < 3)
                output = false;

            // Get Text from RichTextBox
            string DescriptionText = new TextRange(DescriptionBox.Document.ContentStart, DescriptionBox.Document.ContentEnd).Text;

            if (DescriptionText.Length < 3)
                output = false;

            if (SeverityBox.SelectedItem == null)
                output = false;

            return output;
        }
    }
}
