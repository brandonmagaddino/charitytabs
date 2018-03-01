using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CharityTabsServer.Managers;
using CharityTabsServer.DTO;
using CityServerConsole;

namespace CharityTabsServer.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        // GET api/values/5
        [HttpGet("{id}")]
        public UserDTO Get(String id)
        {
            return DataManager.instance.getUserByID(id);
        }
       
        /*
        // POST api/values
        [HttpPost]
        public String Post([FromBody]UserDTO value)
        {
            return "Possitive Response";
        }
        */
        
        // PUT api/values/all
        [HttpPut("{act}")]
        public void Put(string act, [FromBody]UserDTO user)
        {
            MongoController.instance.updateUser(user);
        }
    }
}
