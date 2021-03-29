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

        public Person(string name,DateTime dateOfBirth)
        {
            this.Name = name;
            this.DateOfBirth = dateOfBirth;
        }
        

        public string Name{get;private set;}
        protected DateTime DateOfBirth {get; private set;}

        public string Email { get; set; }

        public int Age
        {get 
            {
                int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
                int dob = int.Parse(this.DateOfBirth.ToString("yyyyMMdd"));
                return (now - dob) / 10000;
            }
        }
    }
}
