using System;
using School_Management.Classes;
using School_Management.Interfaces;

namespace School_Management.App
{
    public partial class Views
    {
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

        private static void UpdateTeacher(ISchoolMember person)
        {
            var p = (Teacher) person;
            var possibleAnswers = new[] {"y", "ye", "yes"};
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

            while (true)
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
                contactNo = GetContactNo(forename, person);
                Console.Write("Enter email contact:");
                emailAddress = Console.ReadLine();
                if (emailAddress is {Length: 0})
                {
                    emailAddress = p.EmailAddress;
                }

                dateJoined = GetDate(person, "joined");

                Console.Write("Enter teacher Expertise:");
                expertise = Console.ReadLine();
                if (expertise is {Length: 0})
                {
                    expertise = p.Expertise;
                }

                salary = GetSalary();
                bonusAdded = CheckBonus();

                Console.WriteLine();
                var temp = new Teacher(forename, surname, dob, expertise, salary, dateJoined, bonusAdded, contactNo,
                    emailAddress);
                Console.WriteLine(temp.ShowDetails());

                Console.WriteLine("Is this okay? (Y/N)");
                choice = Console.ReadLine();
                if (Array.Exists(possibleAnswers, answer => choice != null && answer == choice.ToLower()))
                {
                    break;
                }
            }

            p.UpdateSelf(forename, surname, dob, dateJoined, expertise, bonusAdded, salary, contactNo, emailAddress);

            UpdateStuff();
        }

        private static void UpdateCourse(ICourse course)
        {
            var course1 = (Course) course;
            var possibleAnswers = new[] {"y", "ye", "yes"};
            var choice = "";
            string subject;
            int scqf;
            string level;

            while (true)
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
                var temp = new Course(subject, level, scqf);
                Console.WriteLine(temp.ShowDetails());

                Console.WriteLine("Is this okay? (Y/N)");
                choice = Console.ReadLine();
                if (Array.Exists(possibleAnswers, answer => choice != null && answer == choice.ToLower()))
                {
                    break;
                }
            }

            course1.UpdateSelf(subject, level, scqf);

            UpdateStuff();
        }

        private static void UpdateClasses(int start = 0)
        {
            ViewClasses(start, "Update");
        }

        private static void UpdateClass(CourseClass course)
        {
            throw new NotImplementedException();
        }
    }
}