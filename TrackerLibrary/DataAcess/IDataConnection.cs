using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAcess
{
    public interface IDataConnection
    {
        IssueModel CreateIssue(IssueModel model);
        PersonModel CreatePerson(PersonModel model);
        List<SeverityModel> GetSeverities();
    }
}
