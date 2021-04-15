using System;
using School_Management.Interfaces;

namespace School_Management.Classes
{
    abstract class Person:IPerson
    {
        protected Person(string forename,string surname,DateTime dateOfBirth,string contactNo = null,string emailAddress = null)
        {
            this.Forename = forename;
            this.Surname = surname;
            this.DateOfBirth = dateOfBirth;
            this.ContactNo = contactNo;
            this.EmailAddress = emailAddress;
        }
        
        public string Forename{get; protected set; }
        public string Surname { get; protected set; }

        public string Name => $"{Forename} {Surname}";

        public DateTime DateOfBirth {get; protected set;}

        public string ContactNo { get; protected set; }

        public string EmailAddress { get; protected set; }

        public int Age
        {get 
            {
                var now = int.Parse(DateTime.Today.ToString("yyyyMMdd"));
                var dob = int.Parse(this.DateOfBirth.ToString("yyyyMMdd"));
                return (now - dob) / 10000;
            }
        }
        public abstract string ShowDetails();
    }
}
