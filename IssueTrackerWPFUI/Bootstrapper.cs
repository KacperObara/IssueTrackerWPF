using Caliburn.Micro;
using System.Windows;
using IssueTrackerWPFUI.ViewModels;

namespace IssueTrackerWPFUI
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
