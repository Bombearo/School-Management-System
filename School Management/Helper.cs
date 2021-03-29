using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management
{
    public static class Helper
    {
        public static string GetConnectionString(string dbName)
        { 
             return $"Server=.;Database={dbName};Trusted_Connection=True;"; 
           
        }

    }
}
