using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management
{
    class Pupil:Person,ISchoolMember

    {
        public Pupil(string forename,
            string surname,
            DateTime dateOfBirth,
            string contactNo,
            string emailAddress):base(forename,surname,dateOfBirth,contactNo,emailAddress)
        {
            this.DateJoined = DateTime.Today;
        }

        public Pupil(string forename,
        string surname,
        DateTime dateOfBirth,
        string contactNo,
        string emailAddress,
        DateTime dateJoined) : base(forename, surname, dateOfBirth, contactNo, emailAddress)
        {
            this.DateJoined = dateJoined;
        }

        //Database Constructor
        public Pupil(
        int pupilId,
        DateTime dateJoined,
        int personId,
        string forename,
        string surname,
        DateTime dateOfBirth,
        string emailAddress,
        string contactNo

        ) : base(forename, surname, dateOfBirth, contactNo, emailAddress)
        {
            this.DateJoined = dateJoined;
            this.PupilId = pupilId;
            this.PersonId = personId;
        }
        public int PupilId { get; set; }
        public int PersonId { get; set; }
        public DateTime DateJoined { get; set; }

        public override string ShowDetails()
        {
            string name = $"{"Name",-15}: {this.Name,30}";
            string dob = $"{"Date Of Birth",-15}: {this.DateOfBirth,30}";
            string age = $"{"Age",-15}: {this.Age,30}";
            string contactNo = $"{"Contact Number",-15}: {this.ContactNo,30}";
            string emailAddress = $"{"Email Address",-15}: {this.EmailAddress,30}";
            string dateJoin = $"{"Date Of Joined",-15}: {this.DateJoined,30}";
            List<string> messages = new List<string> { name,dob, age, contactNo, emailAddress,dateJoin };
            return string.Join("\n", messages);
        }

        public void AddSelf()
        {
            var db = new DataAccess();

            db.AddStudent(this.Forename, this.Surname, this.DateOfBirth, this.DateJoined, this.ContactNo, this.EmailAddress);
        }

        public void UpdateSelf(string forename, string surname, DateTime dob, string contactNo, string emailAddress,DateTime dateJoined)
        {
            DataAccess db = new DataAccess();

            db.UpdatePupil(this.PersonId,forename,surname,dob,contactNo,emailAddress,dateJoined);
        }
    }
}
