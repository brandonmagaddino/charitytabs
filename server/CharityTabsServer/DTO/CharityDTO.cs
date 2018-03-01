using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharityTabsServer.DTO
{
    [BsonIgnoreExtraElements]
    public class CharityDTO
    {
        public String CharityID { get; set; }
        public String CharityName {get; set; }
        public String PoolID { get; set; }
    }
}
