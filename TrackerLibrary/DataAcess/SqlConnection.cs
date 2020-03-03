using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAcess
{
    class SqlConnection : IDataConnection
    {
        /// <summary>
        /// Saves a new Issue to the database
        /// </summary>
        /// <param name="model">The issue information</param>
        /// <returns>Issue including an unique identifier</returns>
        public IssueModel CreateIssue(IssueModel model)
        {
            // using in order to prevent memory leaks
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("IssueTracker")))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Title", model.Title);
                parameter.Add("@Description", model.Description);
                parameter.Add("@CreationDate", model.CreationDate);
                parameter.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spIssue_Insert", parameter, commandType: CommandType.StoredProcedure);

                model.Id = parameter.Get<int>("@id");

                return model;
            }
        }

        public PersonModel CreatePerson(PersonModel model, string password)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("IssueTracker")))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Login", model.Login);
                parameter.Add("@Password", password);
                parameter.Add("@Email", model.Email);
                parameter.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spPerson_Insert", parameter, commandType: CommandType.StoredProcedure);

                model.Id = parameter.Get<int>("@id");

                return model;
            }
        }

        public List<PersonModel> GetPeople()
        {
            List<PersonModel> output = new List<PersonModel>();

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("IssueTracker")))
            {
                output = connection.Query<PersonModel>("spPerson_GetAll").ToList();
            }

            return output;
        }

        public List<SeverityModel> GetSeverities()
        {
            List<SeverityModel> output = new List<SeverityModel>();

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("IssueTracker")))
            {
                output = connection.Query<SeverityModel>("spSeverity_GetAll").ToList();
            }

            return output;
        }
    }
}
