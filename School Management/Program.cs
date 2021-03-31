using System;

namespace School_Management
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DateTime dob = new DateTime(2008, 6, 1);

            Course c = new Course();
            c.Scqf = 4;
            c.Subject = "English";
            c.Level = "National 5";

            c.AddSelf();
        }
    }
}
