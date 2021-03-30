using System;

namespace School_Management
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DateTime dob = new DateTime(2008, 6, 1);
            Teacher t = new Teacher("John", "Hathorne", dob,"Maths",10000);


            t.AddSelf();
            Console.WriteLine(t.Age);
        }
    }
}
