namespace School_Management
{
    public interface ICourse
    {
        int CourseId { get; set; }
        string Subject { get; set; }
        string Level { get; set; }
        int Scqf { get; set; }

        string ShowDetails();

        void AddSelf();
    }
}