using Microsoft.AspNetCore.Mvc;
using SweetnSaltyBusiness;
using SweetnSaltyModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SweetnSaltyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SweetnSaltyController : Controller
    {
        private readonly ISweetnSaltyBusinessClass _businessClass;
        //constructor
        public SweetnSaltyController(ISweetnSaltyBusinessClass ISweetnSaltyBusinessClass)
        {
            this._businessClass = ISweetnSaltyBusinessClass;
        }


        [HttpPost]
        [Route("postaflavor/{flavor}")]
        public async Task<ActionResult<Flavor>> PostFlavor(string flavor)
        {
            //call the business layer and send the string
            Flavor f = await this._businessClass.PostFlavor(flavor);
            if (f != null)
            {
                return Created($"http://5001/sweetnsalty/postaflavor/if.FlavorID", f);
            }
            else return BadRequest();

        }

        [HttpPost]
        [Route("postaperson/{fname}/{lname}")]
        public async Task<Person> PostPerson(string fname, string lname)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("getaperson/{fname}/{lname}")]
        public async Task<Person> PostFlavor(string fname, string lname)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("getapersonandflavors/{id}")]
        public async Task<Person> GetPersonAndFlavors(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("getlistofflavors")]
        public async Task<List<Flavor>> GetAllFlavors()
        {
            throw new NotImplementedException();
        }


    }
}
