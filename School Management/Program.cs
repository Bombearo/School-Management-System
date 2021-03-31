using System;

namespace School_Management
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DateTime dob = new DateTime(2008, 6, 1);
            Pupil t = new Pupil("Michael", "Beeston", dob,"01312019942","LindsayScott@gmail.com");


            t.AddSelf();
            Console.WriteLine(t.Age);
        }
    }
}
