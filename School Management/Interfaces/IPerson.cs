using System;

namespace School_Management.Interfaces
{
    interface IPerson
    {
        string Name { get; }
        int Age { get; }

        DateTime DateOfBirth { get; }

        string ContactNo { get; }

        string EmailAddress { get; }

        string ShowDetails();
    }
}
