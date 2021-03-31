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
            Course c = new Course("Computing Science","Advanced Higher",7);

            foreach (Course_Class course in pupils)
            {
                Console.WriteLine($"Before: {course.CourseID}");
                course.AddSelf();
                Console.WriteLine($"After: {course.CourseID}");
            }

            Console.WriteLine($"Before: {c.CourseID}");
            c.AddSelf();
            Console.WriteLine($"After: {c.CourseID}");
        }
    }
}
