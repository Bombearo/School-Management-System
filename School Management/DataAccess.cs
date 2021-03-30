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
            string expertise,
            int salary,
            string contactInfo,
            string emailAddress)
        {
            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString("SchoolDB")))
            {
                Console.WriteLine("Connection Opened!");
                // Do work here; connection closed on following line.

                List<Teacher> teachers = new List<Teacher>();
                teachers.Add(new Teacher(forename,surname,dateOfBirth,expertise,salary,contactInfo,emailAddress));
                connection.Execute("dbo.InsertTeacher @Forename,@Surname,@DateOfBirth,@DateJoined,@Salary,@BonusAdded,@Expertise,@EmailAddress,@ContactNo", teachers);

            }
        }
    }

}
