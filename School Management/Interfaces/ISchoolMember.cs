using System;

namespace School_Management.Interfaces
{
    interface ISchoolMember:IPerson
    {
        void AddSelf();

        DateTime DateJoined { get; set; }

        int PersonId { get; set; }
        void RemoveSelf();
    }
}
