using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using TrackerLibrary.Models;

namespace IssueTrackerWPFUI
{
    /// <summary>
    /// Interaction logic for NewPerson.xaml
    /// </summary>
    public partial class NewPerson : Window
    {
        public NewPerson()
        {
            InitializeComponent();
        }

        private void CreatePersonButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                PersonModel model = new PersonModel(LoginBox.Text, PasswordBox.Password, EmailBox.Text);

                GlobalConfig.Connection.CreatePerson(model);
            }
            else
            {
                MessageBox.Show("Invalid form.");
            }
        }

        private bool ValidateForm()
        {
            bool output = true;

            if (LoginBox.Text.Length < 3)
                output = false;

            if (PasswordBox.Password.Length < 3)
                output = false;

            // Email validation
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            if (regex.IsMatch(EmailBox.Text) == false)
                output = false;

            return output;
        }
    }
}
