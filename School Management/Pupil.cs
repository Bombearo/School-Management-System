﻿using System;
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

        public void AddSelf()
        {
            DataAccess db = new DataAccess();

            db.AddStudent(this.Forename, this.Surname, this.DateOfBirth, this.DateJoined, this.ContactNo, this.EmailAddress);
        }
    }
}
