using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restAPI.DTO
{
    public class UserDTO
    {
        public String userID { get; set; }
        public String firstName { get; set; }
        public String picture { get; set; }
        public long numberOfHashes { get; set; }
    }
}
