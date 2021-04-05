using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management
{
    class Teacher:Person
    {
        public Teacher(string forename,
            string surname,
            DateTime dateOfBirth,
            string expertise,
            int salary,
            string contactInfo = null,
            string emailAddress = null) : base(forename,surname,dateOfBirth,contactInfo,emailAddress)
        {
            this.Salary = salary;
            this.BonusAdded = false;
            this.Expertise = expertise;
            this.DateJoined = DateTime.Today;
        }

        public int TeacherId { get; set; }
        public int Salary { get; set; }
        public string Expertise { get; set; }
        public bool BonusAdded { get; set; }

        public DateTime DateJoined { get; set; }



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

        public override string ShowDetails()
        {
            string name = $"{"Name",-15}: {this.Name,30}";
            string age = $"{"Age",-15}: {this.Age,30}";
            string salary = $"{"Salary",-15}: £{this.Salary,30}";
            string expertise = $"{"Expertise",-15}: {this.Expertise,30}";
            string contactNo = $"{"Contact Number",-15}: {this.ContactNo,30}";
            string emailAddress = $"{"Email Address",-15}: {this.EmailAddress,30}";

            List<string> messages = new List<string> { name, age, salary, expertise, contactNo, emailAddress };
            return string.Join("\n",messages);
        }

        public void AddSelf()
        {
            DataAccess db = new DataAccess();

            db.AddTeacher(this.Forename,this.Surname,this.DateOfBirth,this.DateJoined,this.Expertise,this.BonusAdded,this.Salary,this.ContactNo,this.EmailAddress);
        }
    }
}
