using restAPI.DTO;
using restAPI.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace restAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Charities")]
    public class CharitiesController : Controller
    {
        public IEnumerable<CharityDTO> Get()
        {
            return DataManager.instance.CharityList;
        }
    }
}