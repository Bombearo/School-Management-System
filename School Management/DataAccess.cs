using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using System.Data;

namespace School_Management
{
    class DataAccess
    {

        public void AddTeacher(string forename,
            string surname,
            DateTime dateOfBirth,
            DateTime dateJoined,
            string expertise,
            bool bonusAdded,
            int salary,
            string contactInfo,
            string emailAddress)
        {

            int personId = AddPerson(forename, surname, dateOfBirth, contactInfo, emailAddress);

            var parameters = new DynamicParameters();
            parameters.Add("@DateJoined", dateJoined);
            parameters.Add("@Salary", salary);
            parameters.Add("@BonusAdded", bonusAdded);
            parameters.Add("@Expertise", expertise);
            parameters.Add("@PersonId", personId);


            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString("SchoolDB")))
            {
                Console.WriteLine("Connection Opened!");
                // Do work here; connection closed on following line.

                
                connection.Execute("dbo.InsertTeacher",
                    parameters,
                    commandType: CommandType.StoredProcedure);

            }
        }

        public void AddStudent(string forename,
        string surname,
        DateTime dateOfBirth,
        DateTime dateJoined,
        string contactInfo,
        string emailAddress)
        {

            int personId = AddPerson(forename, surname, dateOfBirth, contactInfo, emailAddress);

            var parameters = new DynamicParameters();
            parameters.Add("@DateJoined", dateJoined);
            parameters.Add("@PersonId", personId);


            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString("SchoolDB")))
            {
                connection.Execute("dbo.Pupil_Insert",
                    parameters,
                    commandType: CommandType.StoredProcedure);

            }
        }

        public int AddPerson(string forename,
        string surname,
        DateTime dateOfBirth,
        string contactInfo,
        string emailAddress)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Forename",forename);
            parameters.Add("@Surname", surname);
            parameters.Add("@DateOfBirth", dateOfBirth);
            parameters.Add("@ContactNo", contactInfo);
            parameters.Add("@EmailAddress", emailAddress);

            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString("SchoolDB")))
            {
                int PersonId = connection.QuerySingle<int>("dbo.People_Insert",
                    parameters,
                    commandType: CommandType.StoredProcedure);
                connection.Close();
                return PersonId;
            }
        }
    }

}
