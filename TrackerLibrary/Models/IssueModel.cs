using System;
using System.Collections.Generic;

namespace TrackerLibrary.Models
{
    public class IssueModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public PersonModel Author { get; set; }
        public List<PersonModel> Assignees { get; set; }
        public SeverityModel Severity { get; set; }
        public StatusModel Status { get; set; }

        public string GetAssignees
        {
            get
            {
                string output = "";
                foreach (PersonModel assignee in Assignees)
                {
                    output += $"{assignee.Login}\n";
                }
                return output;
            }
        }

        public IssueModel()
        {

        }

        public IssueModel(string title, string description, DateTime creationDate)
        {
            this.Title = title;
            this.Description = description;
            this.CreationDate = creationDate;
        }
    }
}
