using System;

namespace School_Management
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DataAccess db = new DataAccess();
            var pupils = db.GetClasses();
            /*
                     string subject,
        string level,
        int scqf,
        int teacherId,
        TimeSpan classTime,
        string dayOfWeek
             */
            TimeSpan t = new TimeSpan(9,30,0);
            var c = new Course_Class("Computing Science","Advanced Higher",7,3,t,"Wednesday");

            foreach (Course_Class course in pupils)
            {
                Console.WriteLine($"Before: {course.CourseID}");
                course.AddSelf();
                Console.WriteLine($"After: {course.CourseID}");
            }
            c.AddSelf();
        }
    }
}
