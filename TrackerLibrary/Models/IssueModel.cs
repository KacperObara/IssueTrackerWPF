using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class IssueModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public PersonModel Assignee { get; set; }
        public SeverityModel Severity { get; set; }

        public IssueModel()
        {

        }

        public IssueModel(string title, string description, DateTime creationDate, PersonModel assignee, SeverityModel severity)
        {
            this.Title = title;
            this.Description = description;
            this.CreationDate = creationDate;
            this.Assignee = assignee;
            this.Severity = severity;
        }
    }
}
