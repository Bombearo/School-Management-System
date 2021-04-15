using System;
using System.Linq;
using School_Management.Interfaces;
using School_Management.Utilities;

namespace School_Management.Classes
{
    class CourseClass:Course,IClass
    {


        //Database Constructor
        public CourseClass(
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
        public CourseClass(
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
        public CourseClass(
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
            var db = new DataAccess();
            this.ClassId = db.AddClass(this.DayOfWeek,this.TeacherId,this.ClassTime, this.CourseId);

        }

        public override string ShowDetails()
        {
            var dayOfWeek = $"{"Taught on",-15}:{DayOfWeek+'s',30}";
            var time = $"{"Taught at",-15}:{ClassTime,30}";
            var teacher = $"{"Taught by",-15}:{ClassTeacher.Name,30}";



            var baseDetail = new string[] { $"{"COURSE",-45}", base.ShowDetails() };
            var msgs = new string[] { $"{"CLASS",-45}", dayOfWeek, time, teacher };

            var courseDetail = string.Join("\n", baseDetail);
            var msgs2 = courseDetail.Split(new string[] {"\n"},StringSplitOptions.None);

            //Iterates over the list, and i keeps track of the position to select msgs2
            var details = msgs.Select((t, i) => $"{t}|{msgs2[i]}").ToList();

            return string.Join("\n",details);
        }

        public void UpdateSelf(TimeSpan time,string dayOfWeek,int teacherId,int courseId)
        {
            var db = new DataAccess();
            db.UpdateClass(this.ClassId,courseId,time,dayOfWeek,teacherId);
        }

        public void RemoveSelf()
        {
            throw new NotImplementedException();
        }
    }
}
