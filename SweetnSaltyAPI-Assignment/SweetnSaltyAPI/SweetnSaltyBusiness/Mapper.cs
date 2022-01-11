using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using SweetnSaltyModels;

namespace SweetnSaltyBusiness
{
    public class Mapper : IMapper
    {
        public Flavor EntityToFlavor(SqlDataReader dr)
        {
            return new Flavor()
            {
                FlavorID = dr.GetInt32(0),
                FlavorName = dr[1].ToString(),
            };
        }

        Person IMapper.EntityToPerson(SqlDataReader dr)
        {
            return new Person()
            {
                PersonID = dr.GetInt32(0),
                fName = dr[1].ToString(),
                lName = dr[2].ToString(),
            };
        }
    }
}
