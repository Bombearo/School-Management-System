using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using School_Management.Classes;
using School_Management.Interfaces;

namespace School_Management.Utilities
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
                var teacher = connection.QuerySingle<Teacher>("dbo.FindTeacher",
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
                var personId = connection.QuerySingle<int>("dbo.People_Insert",
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
                connection.Close();
                return pupilList.Cast<ISchoolMember>().ToList();
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
                connection.Close();
                return teacherList.Cast<ISchoolMember>().ToList();
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

        public void UpdateCourse(int courseId, string subject, string level, int scqf)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@Subject",subject);
            parameters.Add("@Level", level);
            parameters.Add("@Scqf", scqf);
            parameters.Add("@CourseId", courseId);

            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString("SchoolDB")))
            {
                connection.Execute("dbo.Course_Update",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public List<ICourse> GetCourses()
        {
            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString("SchoolDB")))
            {
                var courseList = connection.Query<Course>("dbo.Get_Course_By_Level").ToList();
                connection.Close();
                return courseList.Cast<ICourse>().ToList();
            }
        }

        public void UpdateClass(int classId, int courseId, TimeSpan time, string dayOfWeek, int teacherId)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@ClassId",classId);
            parameters.Add("@CourseId", courseId);
            parameters.Add("@Time", time);
            parameters.Add("@DayOfWeek", dayOfWeek);
            parameters.Add("@TeacherId", teacherId);
            

            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString("SchoolDB")))
            {
                connection.Execute("dbo.Class_Update",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void RemovePupil(int personId,int pupilId)
        {
            var parameters = new DynamicParameters();
            
            parameters.Add("@PersonId",personId);
            parameters.Add("@PupilId", pupilId);
            
            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString("SchoolDB")))
            {
                connection.Execute("dbo.Pupil_Delete",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void RemoveTeacher(int personId)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@PersonId", personId);
            

            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString("SchoolDB")))
            {
                connection.Execute("dbo.Teacher_Delete",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void RemoveClass(int classId)
        {
            throw new NotImplementedException();
        }

        public void RemoveCourse(int courseId)
        {
            throw new NotImplementedException();
        }
    }

}
