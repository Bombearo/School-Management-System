using System;
using School_Management.Interfaces;

namespace School_Management.App
{
    public partial class Views
    {
        private static void RemoveStuff()
        {
            const string options = "Which kind of object do you want to Remove?";
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
            ShowOptions(RemovePupils, RemoveTeachers,RemoveCourses,RemoveClasses, HomePage);
        }
        

        private static void RemoveClasses(int start=0)
        {
            ViewClasses(start,"Remove");
        }

        private static void RemoveCourses(int start=0)
        {
            ViewCourses(start,"Remove");
        }

        private static void RemoveTeachers(int start=0)
        {
            ViewTeachers(start,"Remove");
        }

        private static void RemovePupils(int start=0)
        {
            ViewPupils(start,"Remove");
        }
        private static void RemoveClass(ICourse courseClass)
        {
            courseClass.RemoveSelf();
        }

        private static void RemoveCourse(ICourse course)
        {
            course.RemoveSelf();
        }

        private static void RemoveTeacher(ISchoolMember person)
        {
            person.RemoveSelf();
        }

        private static void RemovePupil(ISchoolMember person)
        {
            person.RemoveSelf();
        }
    }
}