using System;

namespace School_Management.Interfaces
{
    public interface IClass:ICourse
    {
        int ClassId { get; set; }
        TimeSpan ClassTime { get; set; }
    }
}