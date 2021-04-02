using System;

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

        private static void ShowOptions()
        {
            int choice = 0;
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
                        break;
                    default:
                        Console.WriteLine("Your input was not valid, please enter a correct number or nothing to exit.");
                        break;
                }

            } while (running);
        }

        private static void HomePage()
        {
            Console.WriteLine("Enter nothing to quit");
            ShowOptions();
        }

    }
}
