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
    }
}
