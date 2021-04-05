using System;
using System.Collections.Generic;

namespace School_Management
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DataAccess db = new DataAccess();
            var pupils = db.GetClasses();
            TimeSpan t = new TimeSpan(9, 30, 0);
            var c = new Course_Class("Computing Science", "Advanced Higher", 7, 3, t, "Wednesday");

            foreach (Course_Class course in pupils)
            {
                Console.WriteLine($"ClassId: {course.ClassId} TeacherId: {course.TeacherId} Day of week: {course.DayOfWeek}");

            }
            c.AddSelf();
            HomePage();

        }

        private static void ShowOptions(Action option1,Action option2)
        {
            int choice;
            bool running = true;
            do
            {

                string input = Console.ReadLine();
                if (!int.TryParse(input, out choice) && input == ""){
                    choice = -1;
                }
                switch (choice)
                {
                    case -1: 
                        running = false;
                        break;
                    case 1:
                        option1();
                        break;
                    case 2:
                        option2();
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Your input was not valid, please enter a correct number or nothing to exit.");
                        break;
                }

            } while (running);
        }

        private static void ShowOptions(Action option1, Action option2, Action back)
        {
            int choice;
            bool running = true;
            do
            {

                string input = Console.ReadLine();
                if (!int.TryParse(input, out choice) && input == "")
                {
                    choice = -1;
                }
                switch (choice)
                {
                    case -1:
                        running = false;
                        break;
                    case 1:
                        option1();
                        break;
                    case 2:
                        option2();
                        break;
                    default:
                        Console.WriteLine("Your input was not valid, please enter a correct number or nothing to exit.");
                        break;
                }

            } while (running);
            back();
        }

        private static void ShowOptions(Action<int> option1, Action<int> option2, Action back,int start = 0)
        {
            int choice;
            bool running = true;
            do
            {

                string input = Console.ReadLine();
                if (!int.TryParse(input, out choice) && input == "")
                {
                    choice = -1;
                }
                switch (choice)
                {
                    case -1:
                        running = false;
                        break;
                    case 1:
                        option1(start);
                        break;
                    case 2:
                        option2(start);
                        break;
                    default:
                        Console.WriteLine("Your input was not valid, please enter a correct number or nothing to exit.");
                        break;
                }

            } while (running);
            back();
        }

        private static void ShowOptions(ISchoolMember[] students, Action back, int start = 0, bool end = false)
        {
            throw new NotImplementedException();
        }



        private static void HomePage()
        {
            string options = "Welcome! Please Enter one of the following options to proceed!";
            string option1 = "1. View Pupil/Teacher/Course/Class details";
            string option2 = "2. Add New Pupils/Teachers/Courses/Classes";
            string option3 = "3. Update Existing Pupils/Teachers/Courses/Classes";
            string option4 = "4. Remove Pupils/Teachers/Courses/Classes";

            Console.WriteLine(options);
            Console.WriteLine(option1);
            Console.WriteLine(option2);
            Console.WriteLine(option3);
            Console.WriteLine(option4);
            Console.WriteLine("Or enter nothing to quit");
            ShowOptions(ViewPeople,ViewCourseClasses);
        }
        private static void ViewPeople()
        {
            string options = "Welcome! Please Enter one of the following options to proceed!";
            string option1 = "1. View Pupils Details";
            string option2 = "2. View Teacher Details";


            Console.WriteLine(options);
            Console.WriteLine(option1);
            Console.WriteLine(option2);
            Console.WriteLine("Or enter nothing to go back");
            ShowOptions(ViewPupils,ViewTeachers,HomePage);
        }

        private static void ViewCourseClasses()
        {
            string options = "Welcome! Please Enter one of the following options to proceed!";
            string option1 = "1. View Course Details";
            string option2 = "2. View Class Details";


            Console.WriteLine(options);
            Console.WriteLine(option1);
            Console.WriteLine(option2);
            Console.WriteLine("Or enter nothing to go back");
            ShowOptions(ViewCourses,ViewClasses,HomePage);
        }

        //Get the details from DB and display. 
        private static void ViewPupils(int start =0)
        {
            DataAccess db = new DataAccess();
            ISchoolMember[] pupilList = new ISchoolMember[5];
            var students = db.GetStudents();
            int j = 0;
            for (int i = start; i< start + 5;i++) {
                pupilList[j] = students[i];
                j++;
            }

            int counter = 0;
            foreach(Pupil student in pupilList)
            {
                Console.WriteLine($"{++counter}. Name:{student.Name} Age:{student.Age}"); 
            }


            ShowOptions(pupilList,ViewPeople);
        }


        private static void ViewTeachers(int start = 0)
        {

        }

        private static void ViewCourses(int start = 0)
        {

        }
        private static void ViewClasses(int start = 0)
        {

        }

    }
}
