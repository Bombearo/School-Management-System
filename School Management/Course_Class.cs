using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management
{
    class Course_Class:Course
    {
        /*
         System.InvalidOperationException: 'A parameterless default constructor or one matching signature (System.Int32 ClassId, System.String Subject, System.String Level,
        System.Int32 Scqf, System.Int32 CourseId, System.Int32 TeacherId, System.TimeSpan ClassTime) is required for School_Management.Course_Class materialization'
         
         */


        //Database Constructor
        public Course_Class(
            int classId,
            string subject,
            string level,
            int scqf,
            int courseId,
            int teacherId,
            TimeSpan classTime) : base(courseId,subject,level,scqf)
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
        TimeSpan classTime) : base(courseId, subject, level, scqf)
        {
            this.TeacherId = teacherId;
            this.ClassTime = classTime;
        }
        public Course_Class(
        string subject,
        string level,
        int scqf,
        int teacherId,
        TimeSpan classTime) : base(subject, level, scqf)
        {
            this.TeacherId = teacherId;
            this.ClassTime = classTime;
        }

        public TimeSpan ClassTime { get; set; }
        public int ClassId { get; set; }
        public int TeacherId { get; set; }

        public override void AddSelf()
        {
            base.AddSelf();

        }

    }
}
