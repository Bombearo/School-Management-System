
using System;
using School_Management.Utilities;

namespace School_Management.App
{
    public static partial class Views
    {
        

        private static void ViewStuff()
        {
            const string options = "Which kind of object do you want to add?";
            const string option1 = "1. Pupil";
            const string option2 = "2. Teacher";
            const string option3 = "3. Course";
            const string option4 = "4. Class";

            Console.WriteLine(options);
            Console.WriteLine(option1);
            Console.WriteLine(option2);
            Console.WriteLine(option3);
            Console.WriteLine(option4);
            Console.WriteLine("Or enter nothing to go back to the HomePage");
            ShowOptions(ViewPupils, ViewTeachers,ViewCourses,ViewClasses,HomePage);
        }

        //Get the details from DB and display. 
        private static void ViewPupils(int start =0,string mode = "View")
        {
            var db = new DataAccess();
            var students = db.GetStudents();

            var length = students.Count;
            var pupilArray = GetPeople(start, students,length);

            DisplayPeopleOptions(pupilArray);
            switch (mode)
            {
                case "View":
                    ShowOptions(pupilArray, ShowPerson, ViewStuff,start, start + 4 >= length,mode:mode);
                    break;
                case "Update":
                    ShowOptions(pupilArray, UpdatePupil, UpdateStuff,start, start + 4 >= length,mode:mode);
                    break;
                case "Remove":
                    ShowOptions(pupilArray, RemovePupil, RemoveStuff,start, start + 4 >= length,mode:mode);
                    break;
            }
            
        }

        private static void ViewTeachers(int start = 0, string mode = "View")
        {
            var db = new DataAccess();
            var teachers = db.GetTeachers();

            var length = teachers.Count;
            var teacherList = GetPeople(start, teachers, length);
            DisplayPeopleOptions(teacherList);

            switch (mode)
            {
                case "View":
                    ShowOptions(teacherList, ShowPerson, ViewStuff, start, start + 4 >= length, true, mode);
                    break;
                case "Update":
                    ShowOptions(teacherList, UpdateTeacher, UpdateStuff, start, start + 4 >= length, true, mode);
                    break;
                case "Remove":
                    ShowOptions(teacherList, RemoveTeacher, RemoveStuff, start, start + 4 >= length, true, mode);
                    break;
            }

        }

        private static void ViewCourses(int start = 0, string mode="View")
        {
            var db = new DataAccess();
            var courses = db.GetCourses();

            var length = courses.Count;
            var courseList = GetCourses(start, courses, length);

            DisplayCourseOptions(courseList);
            switch (mode)
            {
                case "View":
                    ShowOptions(courseList, ShowCourse, ViewStuff,start, start + 4 >= length,mode:mode);
                    break;
                case "Update":
                    ShowOptions(courseList, UpdateCourse, UpdateStuff,start, start + 4 >= length,mode:mode);
                    break;
                case "Remove":
                    ShowOptions(courseList, RemoveCourse, RemoveStuff,start, start + 4 >= length,mode:mode);
                    break;
            }
        }
        private static void ViewClasses(int start = 0, string mode="View")
        {
            var db = new DataAccess();
            var classes = db.GetClasses();
            foreach(var classItem in classes){
                Console.WriteLine(classItem.ShowDetails());
                Console.WriteLine();
            }
        }
    }
}