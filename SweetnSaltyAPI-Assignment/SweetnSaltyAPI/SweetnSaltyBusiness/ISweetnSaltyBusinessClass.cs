using SweetnSaltyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetnSaltyBusiness
{
    public interface ISweetnSaltyBusinessClass
    {
        Task<Flavor> PostFlavor(string flavor);

        Task<Person> PostPerson(string fName, string lName);

        //get person by name
        Task<Person> GetPersonByName(string fName, string lName);

        //get person and liked flavors by id
        Task<Person> GetPersonAndFlavorsByID(int personID);

        //get a list of flavors available
        Task<List<Flavor>> GetAllFlavors();
    }
}
