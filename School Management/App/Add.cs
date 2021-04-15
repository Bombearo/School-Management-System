using System;
using School_Management.Classes;

namespace School_Management.App
{
    public partial class Views
    { 
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
    }
}