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

        internal int CheckCourse(int scqf, string level, string subject)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Scqf", scqf);
            parameters.Add("@Level", level);
            parameters.Add("@Subject", subject);

            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString("SchoolDB")))
            {
                int CourseId = connection.QuerySingle<int>("dbo.CheckCourseExists",
                    parameters,
                    commandType: CommandType.StoredProcedure);
                connection.Close();
                return CourseId;
            }
        }

        internal int AddClass(string dayOfWeek, int teacherId, TimeSpan classTime,int courseId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@DayOfWeek", dayOfWeek);
            parameters.Add("@TeacherId", teacherId);
            parameters.Add("@ClassTime", classTime);
            parameters.Add("@CourseId", courseId);

            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString("SchoolDB")))
            {
                int classId = connection.QuerySingle<int>("dbo.Class_Insert",
                    parameters,
                    commandType: CommandType.StoredProcedure);
                connection.Close();
                return classId;
            }
        }

        internal int AddCourse(int scqf, string level, string subject)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Scqf", scqf);
            parameters.Add("@Level", level);
            parameters.Add("@Subject", subject);

            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString("SchoolDB")))
            {
                int CourseId = connection.QuerySingle<int>("dbo.Course_Insert",
                    parameters,
                    commandType: CommandType.StoredProcedure);
                connection.Close();
                return CourseId;
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
            parameters.Add("@Forename", forename);
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

        public List<Pupil> GetStudents() {

            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString("SchoolDB"))) {
                var pupilList = connection.Query<Pupil>("dbo.Get_Students_By_Age").ToList();
                connection.Close();
                return pupilList;
            }
        }
        public List<Course_Class> GetClasses()
        {

            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString("SchoolDB")))
            {
                var classList = connection.Query<Course_Class>("dbo.Get_Class_By_Subject_Name").ToList();
                connection.Close();
                return classList;
            }
        }
    }

}
