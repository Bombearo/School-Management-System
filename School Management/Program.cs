﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace School_Management
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            HomePage();

        }

        //Show Options overloads
        private static void ShowOptions(Action option1, Action option2, Action back)
        {
            
            var running = true;
            do
            {
                var input = Console.ReadLine();
                if (!int.TryParse(input, out var choice) && input == "")
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
        private static void ShowOptions(Action<int, string> option1, Action<int, string> option2, Action back,int start = 0)
        {
            var running = true;
            do
            {

                var input = Console.ReadLine();
                if (!int.TryParse(input, out var choice) && input == "")
                {
                    choice = -1;
                }
                switch (choice)
                {
                    case -1:
                        running = false;
                        break;
                    case 1:
                        option1(start,"View");
                        break;
                    case 2:
                        option2(start,"View");
                        break;
                    default:
                        Console.WriteLine("Your input was not valid, please enter a correct number or nothing to exit.");
                        break;
                }

            } while (running);
            back();
        }


        private static void ShowOptions(Action<int> option1, Action<int> option2,Action<int> option3,Action<int> option4, Action back,int start = 0)
        {
            var running = true;
            do
            {

                var input = Console.ReadLine();
                if (!int.TryParse(input, out var choice) && input == "")
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
                    case 3:
                        option3(start);
                        break;
                    case 4:
                        option4(start);
                        break;
                    default:
                        Console.WriteLine("Your input was not valid, please enter a correct number or nothing to exit.");
                        break;
                }

            } while (running);
            back();
        }
        private static void ShowOptions(Action<int,string> option1, Action<int,string> option2,Action<int,string> option3,Action<int,string> option4, Action back,int start = 0,string mode="View")
        {
            var running = true;
            do
            {

                var input = Console.ReadLine();
                if (!int.TryParse(input, out var choice) && input == "")
                {
                    choice = -1;
                }
                switch (choice)
                {
                    case -1:
                        running = false;
                        break;
                    case 1:
                        option1(start,mode);
                        break;
                    case 2:
                        option2(start,mode);
                        break;
                    case 3:
                        option3(start,mode);
                        break;
                    case 4:
                        option4(start,mode);
                        break;
                    default:
                        Console.WriteLine("Your input was not valid, please enter a correct number or nothing to exit.");
                        break;
                }

            } while (running);
            back();
        }

        private static void ShowOptions(Action option1, Action option2, Action option3, Action option4,Action back=null)
        {
            var running = true;
            do
            {

                var input = Console.ReadLine();
                if (!int.TryParse(input, out var choice) && input == "")
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

            back?.Invoke();
            Environment.Exit(0);
        }

        private static void ShowOptions(IReadOnlyList<ISchoolMember> students, Action<ISchoolMember> func, Action back,
            int start = 0, bool end = false, bool teacher = false,string mode = "View")
        {
            var running = true;

            void ShowBack()
            {
                if (start != 0)
                {
                    if (teacher)
                    {
                        ViewTeachers(start - 4,mode);
                        return;
                    }

                    //Back button logic
                    ViewPupils(start - 4,mode);
                    return;
                }
                ShowSchoolMember();

            }


            void ShowNext()
            {
                if (!end)
                {
                    //Next button logic
                    if (teacher)
                    {
                        ViewTeachers(start + 4,mode);
                        return;
                    }
                    ViewPupils(start + 4,mode);
                    return;
                }
                ShowSchoolMember();
            }


            //Checks if the position is not null
            void ShowSchoolMember(ISchoolMember person = null)
            {
                if (person!= null)
                {
                    //Go to pupil page function
                    func(person);

                    return;
                }
                Console.WriteLine("Your input was not valid, please enter a correct number or nothing to exit.");
            }



            do
            {
                var input = Console.ReadLine();
                if (!int.TryParse(input, out var choice) && input == "")
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
                        var person = students[choice - 1];
                        ShowSchoolMember(person);
                        break;
                    case 5:
                        ShowNext();
                        break;
                    default:
                        ShowSchoolMember();
                        break;
                }

            } while (running);
            back();
        }
                
        private static void ShowOptions(IReadOnlyList<ICourse> courses,Action<ICourse> func, Action back, int start = 0, bool end = false,bool isClass = false,string mode = "View")
        {
            var running = true;

            void ShowBack()
            {
                if (start != 0)
                {
                    if (isClass)
                    {
                        ViewClasses(start - 4,mode);
                        return;
                    }

                    //Back button logic
                    ViewCourses(start - 4,mode);
                    return;
                }
                ShowCurrentCourse();
            }


            void ShowNext()
            {
                if (!end)
                {
                    //Next button logic
                    if (isClass)
                    {
                        ViewClasses(start + 4,mode);
                        return;
                    }
                    ViewCourses(start + 4,mode);
                    return;
                }
                ShowCurrentCourse();
            }


            //Checks if the position is not null
            void ShowCurrentCourse(ICourse course = null)
            {
                if (course!= null)
                {
                    //Go to pupil page function
                    func(course);

                    return;
                }
                Console.WriteLine("Your input was not valid, please enter a correct number or nothing to exit.");
            }



            do
            {

                var input = Console.ReadLine();
                if (!int.TryParse(input, out var choice) && input == "")
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
                        var person = courses[choice - 1];
                        ShowCurrentCourse(person);
                        break;
                    case 5:
                        ShowNext();
                        break;
                    default:
                        ShowCurrentCourse();
                        break;
                }

            } while (running);
            back();
        }

        //Pages
        private static void HomePage()
        {
            const string options = "Welcome! Please Enter one of the following options to proceed!";
            const string option1 = "1. View Pupil/Teacher/Course/Class details";
            const string option2 = "2. Add New Pupils/Teachers/Courses/Classes";
            const string option3 = "3. Update Existing Pupils/Teachers/Courses/Classes";
            const string option4 = "4. Remove Pupils/Teachers/Courses/Classes";

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
            const string options = "Which kind of object do you want to add?";
            const string option1 = "1. Pupil";
            const string option2 = "2. Teacher";
            const string option3 = "3. Course";
            const string option4 = "4. Class";

            Console.WriteLine(options);
            Console.WriteLine(option1);
            Console.WriteLine(option2);
            Console.WriteLine(option3);
            Console.WriteLine(option4);
            Console.WriteLine("Or enter nothing to go back to the HomePage");
            ShowOptions(ViewPupils, ViewTeachers,ViewCourses,ViewClasses,HomePage);
        }

        //Get the details from DB and display. 
        private static void ViewPupils(int start =0,string mode = "View")
        {
            var db = new DataAccess();
            var students = db.GetStudents();

            var length = students.Count;
            var pupilArray = GetPeople(start, students,length);

            DisplayPeopleOptions(pupilArray);
            switch (mode)
            {
                case "View":
                    ShowOptions(pupilArray, ShowPerson, ViewStuff,start, start + 4 >= length,mode:mode);
                    break;
                case "Update":
                    ShowOptions(pupilArray, UpdatePupil, UpdateStuff,start, start + 4 >= length,mode:mode);
                    break;
                case "Remove":
                    ShowOptions(pupilArray, RemovePupil, RemoveStuff,start, start + 4 >= length,mode:mode);
                    break;
            }
            
        }
        private static void ViewTeachers(int start = 0,string mode = "View")
        {
            var db = new DataAccess();
            var teachers = db.GetTeachers();

            var length = teachers.Count;
            var teacherList = GetPeople(start, teachers, length);
            DisplayPeopleOptions(teacherList);

            switch (mode)
            {
                case "View":
                    ShowOptions(teacherList, ShowPerson, ViewStuff,start, start + 4 >= length,true,mode);
                    break;
                case "Update":
                    ShowOptions(teacherList, UpdateTeacher, UpdateStuff,start, start + 4 >= length,true,mode);
                    break;
                case "Remove":
                    ShowOptions(teacherList, RemoveTeacher, RemoveStuff,start, start + 4 >= length,true,mode);
                    break;
            }
               
               
        }

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

 

        private static void DisplayPeopleOptions(IEnumerable<ISchoolMember> peopleList)
        {
            var counter = 0;
            foreach (ISchoolMember person in peopleList)
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

        private static void ViewCourses(int start = 0, string mode="View")
        {
            var db = new DataAccess();
            var courses = db.GetCourses();

            var length = courses.Count;
            var courseList = GetCourses(start, courses, length);

            DisplayCourseOptions(courseList);
            switch (mode)
            {
                case "View":
                    ShowOptions(courseList, ShowCourse, ViewStuff,start, start + 4 >= length,mode:mode);
                    break;
                case "Update":
                    ShowOptions(courseList, UpdateCourse, UpdateStuff,start, start + 4 >= length,mode:mode);
                    break;
                case "Remove":
                    ShowOptions(courseList, RemoveCourse, RemoveStuff,start, start + 4 >= length,mode:mode);
                    break;
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

        private static void ViewClasses(int start = 0, string mode="View")
        {
            var db = new DataAccess();
            var classes = db.GetClasses();
            foreach(var classItem in classes){
                Console.WriteLine(classItem.ShowDetails());
                Console.WriteLine();
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


        private static void AddStuff()
        {
            const string options = "Which kind of object do you want to add?";
            const string option1 = "1. Pupil";
            const string option2 = "2. Teacher";
            const string option3 = "3. Course";
            const string option4 = "4. Class";

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
            string addAnother;
            var possibleAnswers = new string[] { "y", "ye", "yes" };
            do
            {
                string choice;
                Pupil person;

                do
                {
                    Console.WriteLine();
                    Console.Write("Enter pupil Forename:");
                    var forename = Console.ReadLine();
                    Console.Write("Enter pupil surname:");
                    var surname = Console.ReadLine();
                    var dob = GetDate();
                    var contactNo = GetContactNo(forename);
                    Console.Write("Enter email contact:");
                    var emailAddress = Console.ReadLine();
                    Console.WriteLine();

                    person = new Pupil(forename, surname, dob, contactNo, emailAddress);
                    Console.WriteLine(person.ShowDetails());

                    Console.WriteLine("Is this okay? (Y/N)");
                    choice = Console.ReadLine();
                }
                while (!Array.Exists(possibleAnswers, answer => choice != null && answer == choice.ToLower()));
                person.AddSelf();
                Console.WriteLine("Add another pupil? (Y/N)");
                addAnother = Console.ReadLine();
            } while(Array.Exists(possibleAnswers, answer => addAnother != null && answer == addAnother.ToLower()));
            AddStuff();
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
        private static void AddTeacher()
        { 

            var addAnother = "";
            var possibleAnswers = new[] { "y", "ye", "yes" };
            do
            {
                var choice = "";
                Teacher person;

                while(true)
                {
                    Console.WriteLine();
                    Console.Write("Enter teacher Forename:");
                    var forename = Console.ReadLine();
                    Console.Write("Enter teacher surname:");
                    var surname = Console.ReadLine();
                    var dob = GetDate();

                    var expertise = Console.ReadLine();
                    var salary = GetSalary();

                    var contactNo = GetContactNo(forename);
                    Console.Write("Enter email contact:");
                    var emailAddress = Console.ReadLine();
                    Console.WriteLine();

                    person = new Teacher(forename, surname, dob,expertise,salary, contactNo, emailAddress);
                    Console.WriteLine(person.ShowDetails());

                    Console.WriteLine("Is this okay? (Y/N)");
                    choice = Console.ReadLine();
                    if(!Array.Exists(possibleAnswers, answer => choice != null && answer == choice.ToLower()))
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
            } while (Array.Exists(possibleAnswers, answer => addAnother != null && answer == addAnother.ToLower()));
            AddStuff();

        }
        private static void AddCourse()
        {
            var addAnother = "";
            var possibleAnswers = new[] { "y", "ye", "yes" };
            do
            {
                var choice = "";
                Course course;

                while(true)
                {
                    Console.WriteLine();
                    Console.Write("Enter course subject:");
                    var subject = Console.ReadLine();
                    var scqf = GetScqf();
                    var level = GetLevel(scqf);
                    course = new Course(subject,level,scqf);
                    Console.WriteLine(course.ShowDetails());

                    Console.WriteLine("Is this okay? (Y/N)");
                    choice = Console.ReadLine();
                    if(!Array.Exists(possibleAnswers, answer => choice != null && answer == choice.ToLower()))
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
            } while (Array.Exists(possibleAnswers, answer => addAnother != null && answer == addAnother.ToLower()));
            AddStuff();
        }

        private static bool CheckCancel(string[] possibleAnswers)
        {
            Console.WriteLine("Would you like to cancel?");
            var input = Console.ReadLine();
            return (!Array.Exists(possibleAnswers, answer => input != null && answer == input.ToLower()));
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

        private static string ChooseLevel(IReadOnlyList<string> choices)
        {
            const string options = "Please choose an appropriate level";
            var limit = choices.Count;
            while (true)
            {
                Console.WriteLine(options);
                for (var i=0; i < limit; i++)
                {
                    Console.WriteLine($"{i+1}. {choices[i]}");
                }

                var input = Console.ReadLine();
                if (int.TryParse(input, out var choice) && 1 <= choice && choice <= limit)
                {
                    return choices[choice - 1];
                }

                Console.WriteLine($"Invalid Choice. Please enter a number between 1 and {limit}");
                Console.WriteLine();

            }
        }

        private static void AddClass()
        {
            var addAnother = "";
            var possibleAnswers = new[] { "y", "ye", "yes" };
            do
            {
                var choice = "";
                CourseClass courseClass;

                while(true)
                {
                    Console.WriteLine();
                    var course = ChooseCourse();
                    var time = ChooseTime();
                    var day = ChooseDay();
                    var t = ChooseTeacher();
                    courseClass = new CourseClass(course.Subject,course.Level,course.Scqf,course.CourseId,t.TeacherId,time,day);
                    Console.WriteLine(courseClass.ShowDetails());

                    Console.WriteLine("Is this okay? (Y/N)");
                    choice = Console.ReadLine();
                    if(!Array.Exists(possibleAnswers, answer => choice != null && answer == choice.ToLower()))
                    {
                        break;
                    }
                    if (CheckCancel(possibleAnswers))
                    {
                        AddStuff();
                        return;
                    }

                }
                
                courseClass.AddSelf();
                Console.WriteLine("Add another course? (Y/N)");
                addAnother = Console.ReadLine();
            } while (Array.Exists(possibleAnswers, answer => addAnother != null && answer == addAnother.ToLower()));
            AddStuff();
        }

        private static Teacher ChooseTeacher()
        {
            throw new NotImplementedException();
        }

        private static Course ChooseCourse()
        {
            throw new NotImplementedException();
        }

        private static TimeSpan ChooseTime()
        {
            var periods = new[] { "P1","P2","P3","P4","P5","P6"};
            var times = new[]
            {
                new TimeSpan(8,30,0),
                new TimeSpan(9,40,0),
                new TimeSpan(11,05,0),
                new TimeSpan(12,10,0),
                new TimeSpan(13,35,0),
                new TimeSpan(14,45,0)
            };
            
            var details = periods.Select((t, i) => $"{i+1}. {t}|{times[i]}").ToList();
            foreach (var detail in details)
            {
                Console.WriteLine(detail);
            }
            while (true)
            {
                Console.Write("Choose the appropriate number");
                var input = Console.ReadLine();
                if (int.TryParse(input, out var day))
                {
                    switch (day)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                            return times[day-1];
                        default:
                            Console.WriteLine("You have chosen an invalid day. Please enter a number between 1 to 6");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Your input was not a valid number, please try again:");
                }
            }
        }

        private static string ChooseDay()
        {
            var days = new[] { "Monday","Tuesday","Wednesday","Thursday","Friday"};
            while (true)
            {
                string[] choices;
                var input = Console.ReadLine();
                if (int.TryParse(input, out var day))
                {
                    switch (day)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                            return days[day-1];
                        default:
                            Console.WriteLine("You have chosen an invalid day. Please enter a number between 1 to 5");
                            break;
                    }
                }
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

        

        private static void UpdateStuff()
        {
            const string options = "Which kind of object do you want to add?";
            const string option1 = "1. Pupil";
            const string option2 = "2. Teacher";
            const string option3 = "3. Course";
            const string option4 = "4. Class";

            Console.WriteLine(options);
            Console.WriteLine(option1);
            Console.WriteLine(option2);
            Console.WriteLine(option3);
            Console.WriteLine(option4);
            Console.WriteLine("Or enter nothing to go back to the HomePage");
            ShowOptions(UpdatePupils, UpdateTeachers,UpdateCourses,UpdateClasses, HomePage);
        }
        
        private static void UpdateCourses(int start=0)
        {
            ViewCourses(start,"Update");
        }

        private static void UpdatePupils(int start = 0)
        {
            ViewPupils(start,"Update");
        }

        private static void UpdateTeachers(int start = 0)
        {
            ViewTeachers(start,"Update");
        }


        private static void UpdatePupil(ISchoolMember person)
        {
            var p = (Pupil)person;
            var possibleAnswers = new[] { "y", "ye", "yes" };
            var choice = "";
            string forename;
            string surname;
            DateTime dob;
            string contactNo;
            string emailAddress;
            DateTime dateJoined;

            while(true)
            {
                Console.WriteLine();
                Console.WriteLine("Leave input blank if you do not wish to change the detail");
                Console.Write("Enter pupil Forename:");
                forename = Console.ReadLine();
                if (forename is {Length: 0})
                {
                    forename = p.Forename;
                }
                Console.Write("Enter pupil surname:");
                surname = Console.ReadLine();
                if (surname is {Length: 0})
                {
                    surname = p.Surname;
                }
                dob = GetDate(person);
                contactNo = GetContactNo(forename,person);
                Console.Write("Enter email contact:");
                emailAddress = Console.ReadLine();
                if (emailAddress is {Length: 0})
                {
                    emailAddress = p.EmailAddress;
                }

                dateJoined = GetDate(person,"joined");

                Console.WriteLine();
                var temp = new Pupil(forename,surname,dob,contactNo,emailAddress,dateJoined);
                Console.WriteLine(temp.ShowDetails());

                Console.WriteLine("Is this okay? (Y/N)");
                choice = Console.ReadLine();
                if (Array.Exists(possibleAnswers, answer => choice != null && answer == choice.ToLower()))
                {
                    break;
                }
            }

            Console.WriteLine(p.PersonId);
            p.UpdateSelf(forename,surname,dob,contactNo,emailAddress,dateJoined);

            UpdateStuff();
        }

        private static bool CheckBonus()
        {
            while (true)
            {
                Console.WriteLine("Would you like to grant a bonus? (Y/N)");
                var input = Console.ReadLine();
                var lower = input?.ToLower();
                switch (lower)
                {
                    case "y":
                    case "ye":
                    case "yes":
                        return true;
                    case "n":
                    case "no":
                        return false;
                }
                Console.WriteLine("Please enter Y/N to answer. ALl other inputs won't be accepted");
            }
        }
        
        private static void UpdateTeacher(ISchoolMember person)
        {
            var p = (Teacher)person;
            var possibleAnswers = new[] { "y", "ye", "yes" };
            var choice = "";
            string forename;
            string surname;
            DateTime dob;
            string contactNo;
            string emailAddress;
            DateTime dateJoined;
            string expertise;
            int salary;
            bool bonusAdded;

            while(true)
            {
                Console.WriteLine();
                Console.WriteLine("Leave input blank if you do not wish to change the detail");
                Console.Write("Enter teacher Forename:");
                forename = Console.ReadLine();
                if (forename is {Length: 0})
                {
                    forename = p.Forename;
                }
                Console.Write("Enter teacher surname:");
                surname = Console.ReadLine();
                if (surname is {Length: 0})
                {
                    surname = p.Surname;
                }
                dob = GetDate(person);
                contactNo = GetContactNo(forename,person);
                Console.Write("Enter email contact:");
                emailAddress = Console.ReadLine();
                if (emailAddress is {Length: 0})
                {
                    emailAddress = p.EmailAddress;
                }

                dateJoined = GetDate(person,"joined");

                Console.Write("Enter teacher Expertise:");
                expertise = Console.ReadLine();
                if (expertise is {Length: 0})
                {
                    expertise = p.Expertise;
                }

                salary = GetSalary();
                bonusAdded = CheckBonus();
                
                Console.WriteLine();
                var temp = new Teacher(forename,surname,dob,expertise,salary,dateJoined,bonusAdded,contactNo,emailAddress);
                Console.WriteLine(temp.ShowDetails());

                Console.WriteLine("Is this okay? (Y/N)");
                choice = Console.ReadLine();
                if (Array.Exists(possibleAnswers, answer => choice != null && answer == choice.ToLower()))
                {
                    break;
                }
            }
            p.UpdateSelf(forename,surname,dob,dateJoined,expertise,bonusAdded,salary,contactNo,emailAddress);

            UpdateStuff();
        }
        private static void UpdateCourse(ICourse course)
        {
            var course1 = (Course)course;
            var possibleAnswers = new[] { "y", "ye", "yes" };
            var choice = "";
            string subject;
            int scqf;
            string level;

            while(true)
            {
                Console.WriteLine();
                Console.WriteLine("Leave input blank if you do not wish to change the detail");
                Console.Write("Enter course subject:");
                subject = Console.ReadLine();
                if (subject is {Length: 0})
                {
                    subject = course1.Subject;
                }
                scqf = GetScqf("Update");
                if (scqf == 0)
                {
                    scqf = course1.Scqf;
                }

                level = GetLevel(scqf);
                Console.WriteLine();
                var temp = new Course(subject,level,scqf);
                Console.WriteLine(temp.ShowDetails());

                Console.WriteLine("Is this okay? (Y/N)");
                choice = Console.ReadLine();
                if (Array.Exists(possibleAnswers, answer => choice != null && answer == choice.ToLower()))
                {
                    break;
                }
            }
            
            course1.UpdateSelf(subject,level,scqf);

            UpdateStuff();
        }
        
        private static void UpdateClasses(int start=0)
        {
            ViewClasses(start,"Update");
        }
        
        private static void UpdateClass(CourseClass course)
        {
            throw new NotImplementedException();
        }
        
        private static void RemoveStuff()
        {
            const string options = "Which kind of object do you want to Remove?";
            const string option1 = "1. Pupil";
            const string option2 = "2. Teacher";
            const string option3 = "3. Course";
            const string option4 = "4. Class";

            Console.WriteLine(options);
            Console.WriteLine(option1);
            Console.WriteLine(option2);
            Console.WriteLine(option3);
            Console.WriteLine(option4);
            Console.WriteLine("Or enter nothing to go back to the HomePage");
            ShowOptions(RemovePupils, RemoveTeachers,RemoveCourses,RemoveClasses, HomePage);
        }
        

        private static void RemoveClasses(int start=0)
        {
            ViewClasses(start,"Remove");
        }

        private static void RemoveCourses(int start=0)
        {
            ViewCourses(start,"Remove");
        }

        private static void RemoveTeachers(int start=0)
        {
            ViewTeachers(start,"Remove");
        }

        private static void RemovePupils(int start=0)
        {
            ViewPupils(start,"Remove");
        }
        private static void RemoveClass(CourseClass courseClass)
        {
            courseClass.RemoveSelf();
        }

        private static void RemoveCourse(ICourse course)
        {
            course.RemoveSelf();
        }

        private static void RemoveTeacher(ISchoolMember person)
        {
            person.RemoveSelf();
        }

        private static void RemovePupil(ISchoolMember person)
        {
            person.RemoveSelf();
        }
    }
}
