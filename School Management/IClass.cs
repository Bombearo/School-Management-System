using System;

namespace School_Management
{
    public interface IClass:ICourse
    {
        int ClassId { get; set; }
        TimeSpan Classtime { get; set; }
    }
}