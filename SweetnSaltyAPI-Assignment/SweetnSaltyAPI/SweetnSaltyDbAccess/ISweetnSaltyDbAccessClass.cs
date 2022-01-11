using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetnSaltyDbAccess
{
    public interface ISweetnSaltyDbAccessClass
    {
        Task<SqlDataReader> PostFlavor(string flavor);

        Task<SqlDataReader> PostPerson(string firstname, string lastname);

        Task<SqlDataReader> GetPersonByName(string fName, string lName);

        Task<SqlDataReader> GetAllFlavors();
    }
}
