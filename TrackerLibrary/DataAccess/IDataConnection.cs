using System.Collections.Generic;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAcess
{
    public interface IDataConnection
    {
        void UpdateIssue(IssueModel issue);
        IssueModel CreateIssue(IssueModel model);
        PersonModel CreatePerson(PersonModel model, PasswordModel password);
        PersonModel GetPersonByLogin(PersonModel model);
        bool Authenticate(string login, string password);
        List<SeverityModel> GetSeverities();
        List<StatusModel> GetStatuses();
        List<PersonModel> GetPeople();
        List<IssueModel> GetIssues();
    }
}
