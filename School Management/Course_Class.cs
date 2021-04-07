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
            TimeSpan classTime,
            string dayOfWeek) : base(courseId,subject,level,scqf)
        {
            this.ClassId = classId;
            this.TeacherId = teacherId;
            this.ClassTime = classTime;
            this.DayOfWeek = dayOfWeek;
        }
        public Course_Class(
        string subject,
        string level,
        int scqf,
        int courseId,
        int teacherId,
        TimeSpan classTime,
        string dayOfWeek) : base(courseId, subject, level, scqf)
        {
            this.TeacherId = teacherId;
            this.ClassTime = classTime;
            this.DayOfWeek = dayOfWeek;
        }
        public Course_Class(
        string subject,
        string level,
        int scqf,
        int teacherId,
        TimeSpan classTime,
        string dayOfWeek) : base(subject, level, scqf)
        {
            this.TeacherId = teacherId;
            this.ClassTime = classTime;
            this.DayOfWeek = dayOfWeek;
        }


        public TimeSpan ClassTime { get; set; }
        public int ClassId { get; set; }
        public int TeacherId { get; set; }

        public string DayOfWeek { get; set; }
        public Teacher ClassTeacher
        {
            get
            {
                DataAccess db = new DataAccess();
                return db.FindTeacher(this.TeacherId);
            } 
        }


        public override void AddSelf()
        {
            base.AddSelf();
            DataAccess db = new DataAccess();
            this.ClassId = db.AddClass(this.DayOfWeek,this.TeacherId,this.ClassTime, this.CourseID);

        }

        public override string ShowDetails()
        {
            string dayOfWeek = $"{"Taught on",-15}:{DayOfWeek}s";
            string time = $"{"Taught at",-15}:{ClassTime.ToString()}";
            string teacher = $"{"Taught by",-15}:{ClassTeacher.Name}";

            var msgs = new string[] { "CLASS", dayOfWeek, time, teacher };

            string classDetail = string.Join("\n", msgs);

            var baseDetail = new string[] { "COURSE",base.ShowDetails() };

            string courseDetail = string.Join("\n", baseDetail);

            var Details = new string[] { classDetail,courseDetail};

            return string.Join("\n\n",Details);
        }

    }
}
