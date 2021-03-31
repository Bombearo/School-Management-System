using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management
{
    class Course_Class:Course
    {
        public Course_Class(
            int classId,
            string subject,
            string level,
            int scqf,
            int courseId,
            int teacherId,
            DateTime classTime) : base(courseId,subject,level,scqf)
        {
            this.ClassId = classId;
            this.TeacherId = teacherId;
            this.ClassTime = classTime;
        }
        public Course_Class(
        string subject,
        string level,
        int scqf,
        int courseId,
        int teacherId,
        DateTime classTime) : base(courseId, subject, level, scqf)
        {
            this.TeacherId = teacherId;
            this.ClassTime = classTime;
        }
        public Course_Class(
        string subject,
        string level,
        int scqf,
        int teacherId,
        DateTime classTime) : base(subject, level, scqf)
        {
            this.TeacherId = teacherId;
            this.ClassTime = classTime;
        }


        public DateTime ClassTime { get; set; }
        public int ClassId { get; set; }
        public int TeacherId { get; set; }
    }
}
