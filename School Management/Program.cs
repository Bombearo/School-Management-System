using System;

namespace School_Management
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DateTime dob = new DateTime(2008, 6, 1);
            Person p = new Person("John", dob);

            Console.WriteLine(p.Age);
        }
    }
}
