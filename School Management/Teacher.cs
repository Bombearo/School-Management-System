using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management
{
    class Teacher:Person
    {
        public Teacher(string forename,string surname,DateTime dateOfBirth,string expertise,int salary) : base(forename,surname,dateOfBirth)
        {
            this.Salary = salary;
            this.BonusAdded = false;
            this.Expertise = expertise;
        }

        public int Salary { get; set; }
        public string Expertise { get; set; }
        private bool BonusAdded { get; set; }



        // Adds a bonus to the Teacher's salary. The salary cannot receive another bonus until the Bonus is reset
        void AddBonus(int amount)
        {
            if (this.BonusAdded == false)
            {
                this.Salary = this.Salary + amount;
                this.BonusAdded = true;
            }
            else
            {
                Console.WriteLine($"{this.Name} has already received a bonus. A bonus cannot be applied again");
            }

        }
    }
}
