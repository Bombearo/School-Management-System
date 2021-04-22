using System;
using System.Collections.Generic;
using System.Linq;
using School_Management.Classes;

namespace School_Management.App
{
    public static partial class Views
    {
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
        private static Teacher ChooseTeacher()
        {
            throw new NotImplementedException();
        }

        private static Course ChooseCourse()
        {
            throw new NotImplementedException();
        }

        private static string ChooseLevel(IReadOnlyList<string> choices)
        {
            const string options = "Please choose an appropriate level";
            var limit = choices.Count;
            while (true)
            {
                Console.WriteLine(options);
                for (var i = 0; i < limit; i++)
                {
                    Console.WriteLine($"{i + 1}. {choices[i]}");
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

    }
}