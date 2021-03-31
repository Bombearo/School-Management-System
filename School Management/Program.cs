using System;

namespace School_Management
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DataAccess db = new DataAccess();
            var pupils = db.GetStudents();

            foreach (Pupil pupil in pupils)
            {
                Console.WriteLine($"Age: {pupil.Age}");
                Console.WriteLine($"Name: {pupil.Name}");
            }
        }
    }
}
