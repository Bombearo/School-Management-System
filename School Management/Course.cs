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
            this.Subject = subject;
            this.Level = level;
            this.Scqf = scqf;
        }

        public Course(int courseId, string subject, string level, int scqf)
        {
            this.courseId = courseId;
            this.Subject = subject;
            this.Level = level;
            this.Scqf = scqf;
        }

        public string CourseID { get; set; }
        public string Subject { get; set; }
        public string Level { get; set; }
        public int Scqf { get; set; }

        public void AddSelf() {
            DataAccess db = new DataAccess();
            db.AddCourse(this.Scqf,this.Level,this.Subject);
        }
    }
}
