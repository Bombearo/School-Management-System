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

        //Show Options overloads
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
            int choice;
            bool running = true;

            if (start != 0)
            {
                //Back button logic


            }

            if (end){
                //Next button logic
            }

            //Checks if the position is not null
            static bool ShowPupil(ISchoolMember person = null)
            {
                if (person!= null)
                {
                    //Go to pupil page function
                    ShowPerson(person);

                    return true;
                }
                Console.WriteLine("Your input was not valid, please enter a correct number or nothing to exit.");

                return false;
            }



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
                    case 0:
                        break;
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        ISchoolMember person = students[choice - 1];
                        ShowPupil(person);
                        break;


                    default:
                        ShowPupil();
                        break;
                }

            } while (running);
            back();
        }

        private static void ShowOptions(Action option1, Action option2, Action option3, Action option4)
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
                    case 3:
                        option3();
                        break;
                    case 4:
                        option4();
                        break;
                    default:
                        Console.WriteLine("Your input was not valid, please enter a correct number or nothing to exit.");
                        break;
                }

            } while (running);
        }

        //Pages
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
            ShowOptions(ViewStuff,AddStuff,UpdateStuff,RemoveStuff);
        }



        private static void ViewStuff()
        {
            string options = "Welcome! Please Enter one of the following options to proceed!";
            string option1 = "1. View Pupil/Teacher/Course/Class details";
            string option2 = "2. Add New Pupils/Teachers/Courses/Classes";

            Console.WriteLine(options);
            Console.WriteLine(option1);
            Console.WriteLine(option2);
            Console.WriteLine("Or enter nothing to quit");
            ShowOptions(ViewPeople, ViewCourseClasses,HomePage);
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

            if (students.Count < 5)
            {
                int i = 0;
                foreach (ISchoolMember pupil in students)
                {
                    pupilList[i] = pupil;
                    i++;
                }
            }
            else
            {
                int j = 0;
                for (int i = start; i < start + 4; i++)
                {
                    pupilList[j] = students[i];
                    j++;
                }

            }
            

            int counter = 0;
            foreach(Pupil student in pupilList)
            {
                if (student != null)
                {
                    Console.WriteLine($"{++counter}. Name:{student.Name} Age:{student.Age}");
                }
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

        //ViewPupil route
        private static void ShowPerson(ISchoolMember person)
        {
            Console.WriteLine(person.ShowDetails());
            Console.WriteLine("Would you like to update these details? (Y/N)");
            string choice = Console.ReadLine();
        }

        private static void AddStuff()
        {
            string options = "Which kind of object do you want to add?";
            string option1 = "1. Pupil";
            string option2 = "2. Teacher";
            string option3 = "3. Course";
            string option4 = "4. Class";

            Console.WriteLine(options);
            Console.WriteLine(option1);
            Console.WriteLine(option2);
            Console.WriteLine(option3);
            Console.WriteLine(option4);
            Console.WriteLine("Or enter nothing to go back to the HomePage");
            ShowOptions(AddPupil, AddTeacher,AddCourse,AddClass);
        }

        private static void AddPupil()
        {
            string choice = "";
            Pupil person;
            var possibleAnswers = new string[] {"y","ye","yes" };
            do {
                Console.WriteLine();
                Console.Write("Enter pupil Forename:");
                string forename = Console.ReadLine();
                Console.Write("Enter pupil surname:");
                string surname = Console.ReadLine();
                DateTime dob = GetDate();
                string contactNo = GetContactNo(forename);
                Console.Write("Enter email contact:");
                string emailAddress = Console.ReadLine();
                Console.WriteLine();

                person = new Pupil(forename,surname,dob,contactNo,emailAddress);
                Console.WriteLine(person.ShowDetails());

                Console.WriteLine("Is this okay? (Y/N)");
                choice = Console.ReadLine();
            }
            while (!Array.Exists(possibleAnswers,answer => answer == choice.ToLower()));
            person.AddSelf();
        }
        private static void AddTeacher()
        {

        }
        private static void AddCourse()
        {

        }
        private static void AddClass()
        {

        }

        private static DateTime GetDate()
        {
            DateTime dateToReturn;
            string date;
            while (true)
            {
                Console.Write("Enter pupil date of birth (YY/MM/DD):");
                date = Console.ReadLine();
                if (DateTime.TryParse(date, out dateToReturn))
                    return dateToReturn;
                Console.WriteLine("Sorry, you have entered an invalid date format");
                Console.WriteLine();
            }
        }

        private static string GetContactNo(string name)
        {
            string contactNo;
            while (true)
            {
                Console.Write($"Enter a contact number for {name}:");
                contactNo = Console.ReadLine();
                if (contactNo.Length == 11 && (contactNo.StartsWith("07")||contactNo.StartsWith("0131")))
                    return contactNo;
                Console.WriteLine("Sorry, you have entered an invalid contact number. Please enter a valid UK number e.g.(07111122233,01314441123)");
                Console.WriteLine();
            }
        }

        private static void RemoveStuff()
        {
            throw new NotImplementedException();
        }

        private static void UpdateStuff()
        {
            throw new NotImplementedException();
        }

    }
}
