using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management
{
    class Person:IPerson
    {

        public Person(string forename,string surname,DateTime dateOfBirth,string contactNo = null,string emailAddress = null)
        {
            this.Forename = forename;
            this.Surname = surname;
            this.DateOfBirth = dateOfBirth;
            this.ContactNo = contactNo;
            this.EmailAddress = emailAddress;
        }
        
        public string Forename{get; protected set; }
        public string Surname { get; protected set; }

        public string Name
        {
            get { return $"{Forename} {Surname}"; }
        }

        public DateTime DateOfBirth {get; protected set;}

        public string ContactNo { get; protected set; }

        public string EmailAddress { get; protected set; }

        public int Age
        {get 
            {
                int now = int.Parse(DateTime.Today.ToString("yyyyMMdd"));
                int dob = int.Parse(this.DateOfBirth.ToString("yyyyMMdd"));
                return (now - dob) / 10000;
            }
        }
    }
}
