using SweetnSaltyDbAccess;
using SweetnSaltyModels;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SweetnSaltyBusiness
{
    public class SweetnSaltyBusinessClass : ISweetnSaltyBusinessClass
    {
        private readonly ISweetnSaltyDbAccessClass _dbAccess;
        private readonly IMapper _mapper;
        public SweetnSaltyBusinessClass(ISweetnSaltyDbAccessClass Dbaccess, IMapper mapper)//you need a reference to the DbAccess Layer 
        {
            this._mapper = mapper;
            this._dbAccess = Dbaccess;
        }

        public async Task<Flavor> PostFlavor(string flavor)
        {
            SqlDataReader dr = await this._dbAccess.PostFlavor(flavor);
            if (dr.Read())
            {
                Flavor inFlavor = this._mapper.EntityToFlavor(dr);
                return inFlavor;
            }
            else return null;
        }

        public async Task<Person> PostPerson(string fName, string lName)
        {
            SqlDataReader dr = await this._dbAccess.PostPerson(fName, lName);
            if (dr.Read())
            {
                Person inPerson = this._mapper.EntityToPerson(dr);
                return inPerson;
            }
            else return null;
        }
    }
}
