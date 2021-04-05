using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management
{
    interface IPerson
    {
        string Name { get; set; }
        int Age { get; set; }

        string ContactNo { get; set; }

        string EmailAddress { get; set; }

    }
}
