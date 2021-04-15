using System;

namespace School_Management.App
{
    public partial class Views
    {
        public static void HomePage()
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
        }
    }
}