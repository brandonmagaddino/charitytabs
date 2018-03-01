using CharityTabsServer.DTO;
using CharityTabsServer.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CityServerConsole;

namespace CharityTabsServer.Controllers
{
    [Produces("application/json")]
    [Route("api/Charity")]
    public class CharityController : Controller
    {
        [HttpGet("{id}")]
        public IEnumerable<CharityDTO> Get(String id)
        {
            if (id.Trim().ToLower().Equals("all"))
                return MongoController.instance.getCharities();

            return new List<CharityDTO>() { MongoController.instance.getCharity(id) };
        }
    }
}