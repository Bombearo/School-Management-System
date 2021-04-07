using System;
using System.Collections.Generic;
using System.Linq;

namespace School_Management
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            /*DataAccess db = new DataAccess();
            var pupils = db.GetClasses();
            TimeSpan t = new TimeSpan(9, 30, 0);
            var c = new Course_Class("Computing Science", "Advanced Higher", 7, 3, t, "Wednesday");

            foreach (Course_Class course in pupils)
            {
                Console.WriteLine($"ClassId: {course.ClassId} TeacherId: {course.TeacherId} Day of week: {course.DayOfWeek}");

            }
            c.AddSelf();
            */
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

            void ShowBack()
            {
                if (start != 0)
                {
                    //Back button logic
                    ViewPupils(start - 5);

                }
                ShowPupil();

            }


            void ShowNext()
            {
                if (!end)
                {
                    //Next button logic
                    ViewPupils(start + 5);
                }
                ShowPupil();
            }

            //Checks if the position is not null
            static void ShowPupil(ISchoolMember person = null)
            {
                if (person!= null)
                {
                    //Go to pupil page function
                    ShowPerson(person);

                    return;
                }
                Console.WriteLine("Your input was not valid, please enter a correct number or nothing to exit.");

                return;
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
                        ShowBack();
                        break;
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        ISchoolMember person = students[choice - 1];
                        ShowPupil(person);
                        break;
                    case 5:
                        ShowNext();
                        break;
                    default:
                        ShowPupil();
                        break;
                }

            } while (running);
            back();
        }

        private static void ShowOptions(Action option1, Action option2, Action option3, Action option4,Action back=null)
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
            if (back != null)
            {
                back();
            }
            System.Environment.Exit(0);
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
            ShowOptions(ViewStuff, AddStuff, UpdateStuff, RemoveStuff);
            return;
        }

        private static void ViewStuff()
        {
            string options = "Welcome! Please Enter one of the following options to proceed!";
            string option1 = "1. View Pupil/Teacher details";
            string option2 = "2. View Course/Class details";

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
            ShowOptions(ViewPupils,ViewTeachers,ViewStuff);
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
            ShowOptions(ViewCourses,ViewClasses,ViewStuff);
        }

        //Get the details from DB and display. 
        private static void ViewPupils(int start =0)
        {
            DataAccess db = new DataAccess();
            ISchoolMember[] pupilList = new ISchoolMember[5];
            var students = db.GetStudents();

            int length = students.Count;
            var pupilArray = GetPeople(start, students,length);

            DisplayPeopleOptions(pupilList);


            ShowOptions(pupilList, ViewPeople, start, start + 5 >= length);
        }
        private static void ViewTeachers(int start = 0)
        {
            DataAccess db = new DataAccess();
            var teachers = db.GetTeachers();

            int length = teachers.Count;
            var teacherList = GetPeople(start, teachers, length);
            DisplayPeopleOptions(teacherList);

            ShowOptions(teacherList, ViewPeople, start, start + 5 >= length);
        }

        private static ISchoolMember[] GetPeople(int start,List<ISchoolMember> students,int length)
        {
            var studentArray = new ISchoolMember[5];
            List<ISchoolMember> student;
            if (length < 5)
            {
                student = students.GetRange(0, length);
            }
            else
            {
                int end = Math.Min(length,start+5);
                student = students.GetRange(start, end);
            }

            //Allows for null values in array
            for (int i = 0; i < student.Count; i++)
            {
                studentArray[i] = student[i];
            }

            return studentArray;
        }

 

        private static void DisplayPeopleOptions(ISchoolMember[] peopleList)
        {
            int counter = 0;
            foreach (ISchoolMember person in peopleList)
            {
                if (person != null)
                {
                    Console.WriteLine($"{++counter}. Name:{person.Name} Age:{person.Age}");
                }
            }
        }

        private static void ViewCourses(int start = 0)
        {

        }
        private static void ViewClasses(int start = 0)
        {
            DataAccess db = new DataAccess();
            var classes = db.GetClasses();
            foreach(Course_Class class_item in classes){
                Console.WriteLine(class_item.ShowDetails());
                Console.WriteLine();
            }
        }

        //ViewPupil route
        private static void ShowPerson(ISchoolMember person)
        {
            Console.WriteLine(person.ShowDetails());
            Console.WriteLine("Would you like to update these details? (Y/N)");
            string choice = Console.ReadLine();
            choice = choice.ToLower();
            switch (choice)
            {
                case "y":
                case "ye":
                case "yes":
                    var updatee = (Teacher)person;
                    if (updatee == null)
                    {
                        UpdatePupil(person.PersonId);
                        break;
                    }
                    UpdateTeacher(person.PersonId);
                    break;
                default:
                    break;
            }
            AddStuff();
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
            ShowOptions(AddPupil, AddTeacher,AddCourse,AddClass,HomePage);
        }

        private static void AddPupil()
        {
            string addAnother = "";
            var possibleAnswers = new string[] { "y", "ye", "yes" };
            do
            {
                string choice = "";
                Pupil person;

                do
                {
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

                    person = new Pupil(forename, surname, dob, contactNo, emailAddress);
                    Console.WriteLine(person.ShowDetails());

                    Console.WriteLine("Is this okay? (Y/N)");
                    choice = Console.ReadLine();
                }
                while (!Array.Exists(possibleAnswers, answer => answer == choice.ToLower()));
                person.AddSelf();
                Console.WriteLine("Add another pupil? (Y/N)");
                addAnother = Console.ReadLine();
            } while(Array.Exists(possibleAnswers, answer => answer == addAnother.ToLower()));
            AddStuff();
        }
        private static void AddTeacher()
        {
            static int GetSalary()
            {
                int salary;
                while (true)
                {
                    Console.WriteLine("Enter teacher salary: ");
                    string input = Console.ReadLine();
                    if (Int32.TryParse(input,out salary) && salary > 0)
                    {
                        return salary;
                    }
                    Console.WriteLine("You must enter a valid number, or a number greater than 0");
                }
            }

            string addAnother = "";
            var possibleAnswers = new string[] { "y", "ye", "yes" };
            do
            {
                string choice = "";
                Teacher person;

                while(true)
                {
                    Console.WriteLine();
                    Console.Write("Enter teacher Forename:");
                    string forename = Console.ReadLine();
                    Console.Write("Enter teacher surname:");
                    string surname = Console.ReadLine();
                    DateTime dob = GetDate();

                    string expertise = Console.ReadLine();
                    int salary = GetSalary();

                    string contactNo = GetContactNo(forename);
                    Console.Write("Enter email contact:");
                    string emailAddress = Console.ReadLine();
                    Console.WriteLine();

                    person = new Teacher(forename, surname, dob,expertise,salary, contactNo, emailAddress);
                    Console.WriteLine(person.ShowDetails());

                    Console.WriteLine("Is this okay? (Y/N)");
                    choice = Console.ReadLine();
                    if(!Array.Exists(possibleAnswers, answer => answer == choice.ToLower()))
                    {
                        break;
                    }
                    if (CheckCancel(possibleAnswers))
                    {
                        AddStuff();
                        return;
                    }
                }
                person.AddSelf();
                Console.WriteLine("Add another teacher? (Y/N)");
                addAnother = Console.ReadLine();
            } while (Array.Exists(possibleAnswers, answer => answer == addAnother.ToLower()));
            AddStuff();

        }
        private static void AddCourse()
        {
            string addAnother = "";
            var possibleAnswers = new string[] { "y", "ye", "yes" };
            do
            {
                string choice = "";
                Course course;

                while(true)
                {
                    Console.WriteLine();
                    Console.Write("Enter course subject:");
                    string subject = Console.ReadLine();
                    int scqf = GetScqf();
                    string level = GetLevel(scqf);
                    course = new Course(subject,level,scqf);
                    Console.WriteLine(course.ShowDetails());

                    Console.WriteLine("Is this okay? (Y/N)");
                    choice = Console.ReadLine();
                    if(!Array.Exists(possibleAnswers, answer => answer == choice.ToLower()))
                    {
                        break;
                    }
                    if (CheckCancel(possibleAnswers))
                    {
                        AddStuff();
                        return;
                    }

                }
                
                course.AddSelf();
                Console.WriteLine("Add another course? (Y/N)");
                addAnother = Console.ReadLine();
            } while (Array.Exists(possibleAnswers, answer => answer == addAnother.ToLower()));
            AddStuff();
        }

        private static bool CheckCancel(string[] possibleAnswers)
        {
            Console.WriteLine("Would you like to cancel?");
            string input = Console.ReadLine();
            return (!Array.Exists(possibleAnswers, answer => answer == input.ToLower()));
        }

        private static int GetScqf()
        {
            int scqf;
            while (true)
            {
                Console.Write("Enter SCQF Level(1-8): ");
                string input = Console.ReadLine();
                if (Int32.TryParse(input, out scqf)&&scqf < 9 && scqf > 0)
                    return scqf;
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
                    choices = new string [] { "National 2", "NPA", "National Certificate" };
                    return ChooseLevel(choices);
                case 3:
                    choices = new string[] { "National 3", "NPA", "National Certificate", "Skills for Work" };
                    return ChooseLevel(choices);
                case 4:
                    choices = new string[] { "National 4", "NPA", "National Certificate", "Skills for Work" };
                    return ChooseLevel(choices); 
                case 5:
                    choices = new string[] { "National 5", "NPA", "National Certificate", "Skills for Work" };
                    return ChooseLevel(choices);
                case 6:
                    choices = new string[] { "Higher", "NPA", "National Certificate", "Skills for Work", "PDA" };
                    return ChooseLevel(choices);
                case 7:
                    choices = new string[] { "Advanced Higher", "Advanced Certificate", "Scottish Baccalaureate", "PDA", "HNC" };
                    return ChooseLevel(choices);
                default:
                    choices = new string[] {"HND","Advanced Diploma", "PDA"};
                    return ChooseLevel(choices);
            }
        }

        private static string ChooseLevel(string[] choices)
        {
            string options = "Please choose an appropriate level";
            int choice;
            int limit = choices.Length;
            while (true)
            {
                Console.WriteLine(options);
                for (int i=0; i < limit; i++)
                {
                    Console.WriteLine($"{i+1}. {choices[i]}");
                }

                string input = Console.ReadLine();
                if (Int32.TryParse(input, out choice) && 1 <= choice && choice <= limit)
                {
                    return choices[choice - 1];
                }

                Console.WriteLine($"Invalid Choice. Please enter a number between 1 and {limit}");
                Console.WriteLine();

            }
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


        private static void UpdatePupil(int personId)
        {
            throw new NotImplementedException();
        }

        private static void UpdateTeacher(int personId)
        {
            throw new NotImplementedException();
        }

    }
}
