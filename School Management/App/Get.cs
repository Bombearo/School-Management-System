using System;
using System.Collections.Generic;
using School_Management.Interfaces;

namespace School_Management.App
{
    public static partial class Views
    {
        private static ISchoolMember[] GetPeople(int start,List<ISchoolMember> students,int length)
        {
            var studentArray = new ISchoolMember[4];
            List<ISchoolMember> student;
            if (length < 4)
            {
                student = students.GetRange(0, length);
            }
            else
            {
                var end = Math.Min(length,start+4);

                end = Math.Min(end, end-start);

                student = students.GetRange(start, end);
            }

            //Allows for null values in array
            for (var i = 0; i < student.Count; i++)
            {
                studentArray[i] = student[i];
            }

            return studentArray;
        }


        private static int GetScqf(string mode ="Add")
        {
            while (true)
            {
                Console.Write("Enter SCQF Level(1-8): ");
                var input = Console.ReadLine();
                if (int.TryParse(input, out var scqf) && scqf is < 9 and > 0)
                {
                    return scqf;
                }
                if (input != null && mode != "Add" && input.Length == 0)
                {
                    return 0;
                }
                Console.WriteLine("Sorry, you have entered an invalid SCQF level. Please enter a number between 1 and 8");
                Console.WriteLine();
            }
        }

        private static string GetLevel(int scqf)
        {
            string[] choices;
            switch (scqf)
            {
                case 1:
                    return "National 1";
                case 2:
                    choices = new[] { "National 2", "NPA", "National Certificate" };
                    return ChooseLevel(choices);
                case 3:
                    choices = new[] { "National 3", "NPA", "National Certificate", "Skills for Work" };
                    return ChooseLevel(choices);
                case 4:
                    choices = new[] { "National 4", "NPA", "National Certificate", "Skills for Work" };
                    return ChooseLevel(choices); 
                case 5:
                    choices = new[] { "National 5", "NPA", "National Certificate", "Skills for Work" };
                    return ChooseLevel(choices);
                case 6:
                    choices = new[] { "Higher", "NPA", "National Certificate", "Skills for Work", "PDA" };
                    return ChooseLevel(choices);
                case 7:
                    choices = new[] { "Advanced Higher", "Advanced Certificate", "Scottish Baccalaureate", "PDA", "HNC" };
                    return ChooseLevel(choices);
                default:
                    choices = new[] {"HND","Advanced Diploma", "PDA"};
                    return ChooseLevel(choices);
            }
        }
        private static int GetSalary()
        {
            while (true)
            {
                Console.WriteLine("Enter teacher salary: ");
                var input = Console.ReadLine();
                if (int.TryParse(input, out var salary) && salary > 0)
                {
                    return salary;
                }
                Console.WriteLine("You must enter a valid number, or a number greater than 0");
            }
        }
        private static DateTime GetDate(ISchoolMember person = null,string type = "of birth")
        {
            while (true)
            {
                Console.Write($"Enter pupil date {type} (YY/MM/DD):");
                var date = Console.ReadLine();
                if (DateTime.TryParse(date, out var dateToReturn))
                    return dateToReturn;
                if (date is {Length: 0} && person != null)
                {
                    return type == "of birth" ? person.DateOfBirth : person.DateJoined;
                }
                Console.WriteLine("Sorry, you have entered an invalid date format");
                Console.WriteLine();
            }
        }

        private static string GetContactNo(string name,ISchoolMember person=null)
        {
            while (true)
            {
                Console.Write($"Enter a contact number for {name}:");
                var contactNo = Console.ReadLine();
                switch (contactNo)
                {
                    case {Length: 11} when (contactNo.StartsWith("07")||contactNo.StartsWith("0131")):
                        return contactNo;
                    case {Length: 0} when person != null:
                        return person.ContactNo;
                    default:
                        Console.WriteLine("Sorry, you have entered an invalid contact number. Please enter a valid UK number with no formatting e.g.(07111122233,01314441123)");
                        Console.WriteLine();
                        break;
                }
            }
        }
        private static ICourse[] GetCourses(int start,List<ICourse> courses,int length)
        {
            var courseArray = new ICourse[4];
            List<ICourse> course;
            if (length < 4)
            {
                course = courses.GetRange(0, length);
            }
            else
            {
                var end = Math.Min(length,start+4);

                end = Math.Min(end, end-start);

                course = courses.GetRange(start, end);
            }

            //Allows for null values in array
            for (var i = 0; i < course.Count; i++)
            {
                courseArray[i] = course[i];
            }

            return courseArray;
        }

    }
}