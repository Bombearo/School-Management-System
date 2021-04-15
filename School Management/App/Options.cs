using System;
using System.Collections.Generic;
using School_Management.Interfaces;

namespace School_Management.App
{
    public partial class Views
    {
                //Show Options overloads
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


    }
}