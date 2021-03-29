using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using System.Data;

namespace School_Management
{
    class DataAccess
    {

        public void AddTeacher(Teacher teacher)
        {
            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString("SchoolDB")))
            {
                Console.WriteLine("Connection Opened!");
                // Do work here; connection closed on following line.



            }
        }
    }

}
