using System;
using System.Collections.Generic;
using School_Management.Classes;
using School_Management.Interfaces;

namespace School_Management.App
{
    public static partial class Views
    {
        private static void DisplayPeopleOptions(IEnumerable<ISchoolMember> peopleList)
        {
            var counter = 0;
            foreach (var person in peopleList)
            {
                if (person != null)
                {
                    Console.WriteLine($"{++counter}. Name:{person.Name} Age:{person.Age}");
                }
            }
        }
        
        private static void DisplayCourseOptions(IEnumerable<ICourse> courseList)
        {
            var counter = 0;
            foreach (ICourse course in courseList)
            {
                if (course != null)
                {
                    Console.WriteLine($"{++counter}. Subject:{course.Subject} Level:{course.Level} SCQF:{course.Scqf}");
                }
            }
        }
        private static void ShowCourse(ICourse course)
        {
            Console.WriteLine(course.ShowDetails());
            Console.WriteLine("Would you like to update these details? (Y/N)");
            var choice = Console.ReadLine();
            choice = choice?.ToLower();
            switch (choice)
            {
                case "y":
                case "ye":
                case "yes":

                    if (course is not CourseClass c)
                    {
                       
                        UpdateCourse(course);
                        break;
                    }

                    UpdateClass(c);


                    break;
            }
            AddStuff();
        }
        //ViewPupil route
        private static void ShowPerson(ISchoolMember person)
        {
            Console.WriteLine(person.ShowDetails());
            Console.WriteLine("Would you like to update these details? (Y/N)");
            var choice = Console.ReadLine();
            choice = choice?.ToLower();
            switch (choice)
            {
                case "y":
                case "ye":
                case "yes":

                    if (person is not Teacher)
                    {

                        UpdatePupil(person);
                        break;
                    }
                    UpdateTeacher(person);


                    break;
            }
            AddStuff();
        }



    }
}