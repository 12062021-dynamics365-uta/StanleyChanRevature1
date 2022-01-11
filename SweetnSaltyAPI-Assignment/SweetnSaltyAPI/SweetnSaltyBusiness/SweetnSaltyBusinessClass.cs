using SweetnSaltyDbAccess;
using SweetnSaltyModels;
using System;
using System.Collections.Generic;
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

        //post person who likes a flavor
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

        //get person by name
        public async Task<Person> GetPersonByName(string fName, string lName)
        {
            SqlDataReader dr = await this._dbAccess.GetPersonByName(fName, lName);
            if (dr.Read())
            {
                Person outPerson = this._mapper.EntityToPerson(dr);
                return outPerson;
            }
            else return null;
        }

        //get person and liked flavors by id
        public async Task<Person> GetPersonAndFlavorsByID(int personID)
        {
            throw new NotImplementedException();
        }

        //get a list of flavors available
        public async Task<List<Flavor>> GetAllFlavors()
        {
            SqlDataReader dr = await this._dbAccess.GetAllFlavors();
            List<Flavor> allFlavors = new List<Flavor>();
            while(dr.Read())
            {
                allFlavors.Add(this._mapper.EntityToFlavor(dr));
            }
            return allFlavors;
        }
    }
}
