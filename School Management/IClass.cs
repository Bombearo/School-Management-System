using System;

namespace School_Management
{
    public interface IClass:ICourse
    {
        int ClassId { get; set; }
        TimeSpan ClassTime { get; set; }
    }
}