using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management
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
    }
}
