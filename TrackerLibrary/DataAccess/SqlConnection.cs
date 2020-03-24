using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAcess
{
    class SqlConnection : IDataConnection
    {
        public void UpdateIssue(IssueModel issue)
        {
            /// Inserting into the Issue table
            // using in order to prevent memory leaks
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("IssueTracker")))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@id", issue.Id);
                parameter.Add("@Title", issue.Title);
                parameter.Add("@Description", issue.Description);
                parameter.Add("@CreationDate", issue.CreationDate);
                parameter.Add("@Id_status", issue.Status.Id);
                parameter.Add("@Id_severity", issue.Severity.Id);
                parameter.Add("@Id_author", issue.Author.Id);

                connection.Execute("dbo.spIssue_Update", parameter, commandType: CommandType.StoredProcedure);
            }

            CreateAssignees(issue.Assignees, issue.Id);
        }

        /// <summary>
        /// Saves a new Issue to the database (includes Assignee table)
        /// </summary>
        /// <param name="issue">The issue information</param>
        /// <returns>Issue including an unique identifier</returns>
        public IssueModel CreateIssue(IssueModel issue)
        {
            /// Inserting into the Issue table
            // using in order to prevent memory leaks
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("IssueTracker")))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Title", issue.Title);
                parameter.Add("@Description", issue.Description);
                parameter.Add("@CreationDate", issue.CreationDate);

                if (issue.Status != null)
                {
                    parameter.Add("@Id_status", issue.Status.Id);
                }

                parameter.Add("@Id_severity", issue.Severity.Id);
                parameter.Add("@Id_author", issue.Author.Id);
                parameter.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spIssue_Insert", parameter, commandType: CommandType.StoredProcedure);

                issue.Id = parameter.Get<int>("@id");
            }

            CreateAssignees(issue.Assignees, issue.Id);

            return issue;
        }

        public void CreateAssignees(List<PersonModel> Assignees, int issueId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("IssueTracker")))
            {
                foreach (PersonModel assignee in Assignees)
                {
                    var parameter = new DynamicParameters();
                    parameter.Add("@Id_person", assignee.Id);
                    parameter.Add("@Id_issue", issueId);

                    connection.Execute("dbo.spAssignee_Insert", parameter, commandType: CommandType.StoredProcedure);
                }
            }
        }


        public PersonModel CreatePerson(PersonModel model, PasswordModel password)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("IssueTracker")))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Login", model.Login);
                parameter.Add("@Password", password.Password);
                parameter.Add("@Email", model.Email);
                parameter.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spPerson_Insert", parameter, commandType: CommandType.StoredProcedure);

                model.Id = parameter.Get<int>("@id");

                return model;
            }
        }

        public PersonModel GetPersonByLogin(PersonModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("IssueTracker")))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Login", model.Login);

                model = connection.Query<PersonModel>("dbo.spPerson_GetByLogin", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();

                return model;
            }
        }

        public bool Authenticate(string login, string password)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@login", login);
            parameter.Add("@password", password);

            bool output = false;
            parameter.Add("@output", output);

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("IssueTracker")))
            {
                output = connection.Query<bool>("dbo.spPerson_Authenticate", parameter, commandType: CommandType.StoredProcedure).First();
            }

            return output;
        }

        public List<PersonModel> GetPeople()
        {
            List<PersonModel> output = new List<PersonModel>();

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("IssueTracker")))
            {
                output = connection.Query<PersonModel>("dbo.spPerson_GetAll").ToList();
            }

            return output;
        }

        public List<SeverityModel> GetSeverities()
        {
            List<SeverityModel> output = new List<SeverityModel>();

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("IssueTracker")))
            {
                output = connection.Query<SeverityModel>("dbo.spSeverity_GetAll").ToList();
            }

            return output;
        }

        public List<StatusModel> GetStatuses()
        {
            List<StatusModel> output = new List<StatusModel>();

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("IssueTracker")))
            {
                output = connection.Query<StatusModel>("dbo.spStatus_GetAll").ToList();
            }

            return output;
        }

        public List<IssueModel> GetIssues()
        {
            List<IssueModel> output = new List<IssueModel>();

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("IssueTracker")))
            {
                output = connection.Query<IssueModel>("dbo.spIssue_GetAll").ToList();

                foreach (IssueModel issue in output)
                {
                    var parameter = new DynamicParameters();
                    parameter.Add("@PersonId", issue.Id);

                    issue.Author = connection.Query<PersonModel>("dbo.spPerson_GetByIssue", parameter, commandType: CommandType.StoredProcedure).First();
                }

                foreach (IssueModel issue in output)
                {
                    var parameter = new DynamicParameters();
                    parameter.Add("@PersonId", issue.Id);

                    issue.Assignees = connection.Query<PersonModel>("dbo.spAssignees_GetByIssue", parameter, commandType: CommandType.StoredProcedure).ToList();
                }

                foreach (IssueModel issue in output)
                {
                    var parameter = new DynamicParameters();
                    parameter.Add("@SeverityId", issue.Id);

                    issue.Severity = connection.Query<SeverityModel>("dbo.spSeverity_GetByIssue", parameter, commandType: CommandType.StoredProcedure).First();
                }

                foreach (IssueModel issue in output)
                {
                    var parameter = new DynamicParameters();
                    parameter.Add("@StatusId", issue.Id);

                    issue.Status = connection.Query<StatusModel>("dbo.spStatus_GetByIssue", parameter, commandType: CommandType.StoredProcedure).First();
                }
            }

            return output;
        }


    }
}
