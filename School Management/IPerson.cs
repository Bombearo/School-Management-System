using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management
{
    interface IPerson
    {
        string Name { get; }
        int Age { get; }

        string ContactNo { get; }

        string EmailAddress { get; }

        string ShowDetails();
    }
}
