using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management
{
    class Teacher:Person,ISchoolMember
    {

        public Teacher(string forename,
            string surname,
            DateTime dateOfBirth,
            string expertise,
            int salary,
            string contactInfo = null,
            string emailAddress = null,
            bool bonusAdded = false) : base(forename,surname,dateOfBirth,contactInfo,emailAddress)
        {
            this.Salary = salary;
            this.BonusAdded = bonusAdded;
            this.Expertise = expertise;
            this.DateJoined = DateTime.Today;
        }
        public Teacher(string forename,
            string surname,
            DateTime dateOfBirth,
            string expertise,
            int salary,
            DateTime dateJoined,
            bool bonusAdded = false,
            string contactInfo = null,
            string emailAddress = null) : base(forename,surname,dateOfBirth,contactInfo,emailAddress)
        {
            this.Salary = salary;
            this.BonusAdded = bonusAdded;
            this.Expertise = expertise;
            this.DateJoined = dateJoined;
        }


        //Database Constructor
        public Teacher(
        int teacherId,
        int salary,
        bool bonusAdded,
        string expertise,
        DateTime dateJoined,
        int personId,
        string forename,
        string surname,
        DateTime dateOfBirth,
        string emailAddress,
        string contactNo

        ) : base(forename, surname, dateOfBirth, contactNo, emailAddress)
        {
            this.Salary = salary;
            this.Expertise = expertise;
            this.BonusAdded = bonusAdded;
            this.DateJoined = dateJoined;
            this.TeacherId = teacherId;
            this.PersonId = personId;
        }
        public int PersonId { get; set; }


        public int TeacherId { get; set; }
        public int Salary { get; set; }
        public string Expertise { get; set; }
        public bool BonusAdded { get; set; }

        public DateTime DateJoined { get; set; }



        // Adds a bonus to the Teacher's salary. The salary cannot receive another bonus until the Bonus is reset
        public void AddBonus(int amount)
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
            var name = $"{"Name",-15}: {this.Name,30}";
            var age = $"{"Age",-15}: {this.Age,30}";
            var salary = $"{"Salary",-15}: £{this.Salary,30}";
            var expertise = $"{"Expertise",-15}: {this.Expertise,30}";
            var contactNo = $"{"Contact Number",-15}: {this.ContactNo,30}";
            var emailAddress = $"{"Email Address",-15}: {this.EmailAddress,30}";

            var messages = new List<string> { name, age, salary, expertise, contactNo, emailAddress };
            return string.Join("\n",messages);
        }

        public void AddSelf()
        {
            var db = new DataAccess();

            db.AddTeacher(this.Forename,this.Surname,this.DateOfBirth,this.DateJoined,this.Expertise,this.BonusAdded,this.Salary,this.ContactNo,this.EmailAddress);
        }

        public void UpdateSelf(string forename, string surname, DateTime dateOfBirth, DateTime dateJoined, string expertise, bool bonusAdded, int salary, string contactNo, string emailAddress)
        {
            var db = new DataAccess();

            db.UpdateTeacher(this.PersonId,forename,surname,dateOfBirth,dateJoined,expertise,bonusAdded,salary,contactNo,emailAddress);
        }
        
        public void RemoveSelf()
        {
            var db = new DataAccess();

            DataAccess.RemoveTeacher(this.PersonId);
        }
    }
}
