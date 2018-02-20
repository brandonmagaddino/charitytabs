using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using restAPI.Managers;
using restAPI.DTO;

namespace restAPI.Controllers
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

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
