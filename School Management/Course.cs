using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management
{
    class Course
    {
        private int courseId;

        public Course(string subject, string level, int scqf)
        {
            this.CourseID = -1;
            this.Subject = subject;
            this.Level = level;
            this.Scqf = scqf;
        }

        public Course(int courseId, string subject, string level, int scqf)
        {
            this.CourseID = courseId;
            this.Subject = subject;
            this.Level = level;
            this.Scqf = scqf;
        }

        public int CourseID { get; set; }
        public string Subject { get; set; }
        public string Level { get; set; }
        public int Scqf { get; set; }

        public virtual void AddSelf() 
        {
            DataAccess db = new DataAccess();
            this.CourseID = db.AddCourse(this.Scqf,this.Level,this.Subject);
           
        }

        public string ShowDetails()
        {
            string subject = $"{"Subject",-15}: {this.Subject,30}";
            string level = $"{"Level",-15}: {this.Level,30}";
            string scqf = $"{"SCQF",-15}: {this.Scqf,30}";
            List<string> messages = new List<string> {subject,level,scqf};
            return string.Join("\n", messages);
        }
    }
}
