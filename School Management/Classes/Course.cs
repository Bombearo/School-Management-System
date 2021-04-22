using System;
using System.Collections.Generic;
using School_Management.Interfaces;
using School_Management.Utilities;

namespace School_Management.Classes
{
    class Course:ICourse
    {

        public Course(string subject, string level, int scqf)
        {
            this.CourseId = -1;
            this.Subject = subject;
            this.Level = level;
            this.Scqf = scqf;
        }

        protected Course(int courseId, string subject, string level, int scqf)
        {
            this.CourseId = courseId;
            this.Subject = subject;
            this.Level = level;
            this.Scqf = scqf;
        }

        public int CourseId { get; set; }
        public string Subject { get; set; }
        public string Level { get; set; }
        public int Scqf { get; set; }

        public virtual void AddSelf() 
        {
            var db = new DataAccess();
            this.CourseId = db.AddCourse(this.Scqf,this.Level,this.Subject);
           
        }

        public virtual string ShowDetails()
        {
            var subject = $"{"Subject",-15}: {this.Subject,30}";
            var level = $"{"Level",-15}: {this.Level,30}";
            var scqf = $"{"SCQF",-15}: {this.Scqf,30}";
            var messages = new List<string> {subject,level,scqf};
            return string.Join("\n", messages);
        }

        public void UpdateSelf(string subject,string level, int scqf)
        {
            var db = new DataAccess();
            db.UpdateCourse(this.CourseId,subject,level,scqf);
        }

        public void RemoveSelf()
        {
            var db = new DataAccess();
            db.RemoveCourse(this.CourseId);
        }
    }
}
