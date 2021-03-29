using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace School_Management
{
    class Person:IPerson
    {

        public Person(string forename,string surname,DateTime dateOfBirth,string contactNo = "",string emailAddress = "")
        {
            this.Forename = forename;
            this.Surname = surname;
            this.DateOfBirth = dateOfBirth;
            this.ContactNo = contactNo;
            this.EmailAddress = emailAddress;
        }
        
        protected string Forename{get;private set;}
        protected string Surname { get; private set; }

        public string Name
        {
            get { return $"{Forename} {Surname}"; }
        }

        protected DateTime DateOfBirth {get; private set;}

        protected string ContactNo { get; set; }

        protected string EmailAddress { get; set; }

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
