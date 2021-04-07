using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management
{
    interface ISchoolMember:IPerson
    {
        void AddSelf();

        DateTime DateJoined { get; set; }

        int PersonId { get; set; }
    }
}
