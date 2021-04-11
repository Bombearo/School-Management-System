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

            var personId = AddPerson(forename, surname, dateOfBirth, contactInfo, emailAddress);

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

        public int AddClass(string dayOfWeek, int teacherId, TimeSpan classTime,int courseId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@DayOfWeek", dayOfWeek);
            parameters.Add("@TeacherId", teacherId);
            parameters.Add("@ClassTime", classTime);
            parameters.Add("@CourseId", courseId);

            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString("SchoolDB")))
            {
                var classId = connection.QuerySingle<int>("dbo.Class_Insert",
                    parameters,
                    commandType: CommandType.StoredProcedure);
                connection.Close();
                return classId;
            }
        }

        public Teacher FindTeacher(int teacherId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TeacherID",teacherId);

            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString("SchoolDB")))
            {
                Teacher teacher = connection.QuerySingle<Teacher>("dbo.FindTeacher",
                    parameters,
                    commandType: CommandType.StoredProcedure);
                connection.Close();
                return teacher;
            }
        }

        public int AddCourse(int scqf, string level, string subject)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Scqf", scqf);
            parameters.Add("@Level", level);
            parameters.Add("@Subject", subject);

            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString("SchoolDB")))
            {
                var courseId = connection.QuerySingle<int>("dbo.Course_Insert",
                    parameters,
                    commandType: CommandType.StoredProcedure);
                connection.Close();
                return courseId;
            }
        }

        public void AddStudent(string forename,
        string surname,
        DateTime dateOfBirth,
        DateTime dateJoined,
        string contactInfo,
        string emailAddress)
        {

            var personId = AddPerson(forename, surname, dateOfBirth, contactInfo, emailAddress);

            var parameters = new DynamicParameters();
            parameters.Add("@DateJoined", dateJoined);
            parameters.Add("@PersonId", personId);


            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString("SchoolDB")))
            {
                var _ = connection.QuerySingle<int>("dbo.Pupil_Insert",
                    parameters,
                    commandType: CommandType.StoredProcedure);

            }
        }

        private int AddPerson(string forename,
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
                int personId = connection.QuerySingle<int>("dbo.People_Insert",
                    parameters,
                    commandType: CommandType.StoredProcedure);
                connection.Close();
                return personId;
            }
        }

        private void UpdatePerson(int personId,
            string forename,
            string surname,
            DateTime dateOfBirth,
            string contactInfo,
            string emailAddress)
        {
            var parameters = new DynamicParameters();
            Console.WriteLine($"{personId} {forename} {surname} {dateOfBirth} {emailAddress} {contactInfo}");

            parameters.Add("@PersonID",personId);
            parameters.Add("@Forename", forename);
            parameters.Add("@Surname", surname);
            parameters.Add("@DateOfBirth", dateOfBirth);
            parameters.Add("@ContactNo", contactInfo);
            parameters.Add("@EmailAddress", emailAddress);

            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString("SchoolDB")))
            {
                connection.Execute("dbo.People_Update",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdatePupil(int personId,
        string forename,
        string surname,
        DateTime dateOfBirth,
        string contactInfo,
        string emailAddress,
        DateTime dateJoined)
        {
            UpdatePerson(personId,forename,surname,dateOfBirth,contactInfo,emailAddress);
            var parameters = new DynamicParameters();
            parameters.Add("@DateJoined", dateJoined);
            parameters.Add("@PersonID", personId);

            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString("SchoolDB")))
            {
                connection.Execute("dbo.Pupil_Update",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
            
        }
        

        public List<ISchoolMember> GetStudents() {

            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString("SchoolDB"))) {
                var pupilList = connection.Query<Pupil>("dbo.Get_Students_By_Age").ToList();
                var schoolMembers = new List<ISchoolMember>();
                connection.Close();
                foreach (ISchoolMember pupil in pupilList)
                {
                    schoolMembers.Add(pupil);
                }
                return schoolMembers;
            }
        }
        public List<CourseClass> GetClasses()
        {

            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString("SchoolDB")))
            {
                var classList = connection.Query<CourseClass>("dbo.Get_Class_By_Subject_Name").ToList();
                connection.Close();
                return classList;
            }
        }

        public List<ISchoolMember> GetTeachers()
        {
            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString("SchoolDB")))
            {
                var teacherList = connection.Query<Teacher>("dbo.Get_Teacher_By_Surname").ToList();
                var schoolMembers = new List<ISchoolMember>();
                connection.Close();
                foreach (ISchoolMember teacher in teacherList)
                {
                    schoolMembers.Add(teacher);
                }
                return schoolMembers;
            }
        }

        public void UpdateTeacher(int personId,string forename, string surname, DateTime dateOfBirth, DateTime dateJoined, string expertise, bool bonusAdded, int salary, string contactNo, string emailAddress)
        {
            UpdatePerson(personId,forename,surname,dateOfBirth,contactNo,emailAddress);
            var parameters = new DynamicParameters();
            parameters.Add("@DateJoined", dateJoined);
            parameters.Add("@Salary",salary);
            parameters.Add("@Expertise",expertise);
            parameters.Add("@bonusAdded",bonusAdded);
            parameters.Add("@PersonID", personId);

            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString("SchoolDB")))
            {
                connection.Execute("dbo.Teacher_Update",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }

}
