using restAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restAPI.Managers
{
    public class DataManager
    {
        private static DataManager _instance;
        public static DataManager instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DataManager();

                return _instance;
            }
        }

        private List<CharityDTO> _CharityList;
        public List<CharityDTO> CharityList
        {
            get
            {
                return new List<CharityDTO>(_CharityList);
            }
        }

        private List<UserDTO> _UserList;

        public UserDTO getUserByID(String ID)
        {
            var user = _UserList.Where(arg => arg.userID == ID).FirstOrDefault();
            if (user == null)
                user = new UserDTO();

            return user;
        }

        private DataManager()
        {
            _CharityList = new List<CharityDTO>();
            var defaultCharity = new CharityDTO
            {
                CharityName = "Developer",
                CharityID = "0000000000000000000000",
                PoolID = "DCjL37j8YfFOcXxcAIcSrWulNm30Dw97"
            };
            _CharityList.Add(defaultCharity);

            _UserList = new List<UserDTO>();
            var defaultUser = new UserDTO
            {
                userID = "1942986769050945",
                firstName = "Brandon",
                numberOfHashes = 12312312312,
                picture = "https://scontent.xx.fbcdn.net/v/t1.0-1/p80x80/15966047_1554751541207805_8392630923285300093_n.jpg?oh=54a35b0c42fedb4aee83b1325a0feed6&oe=5B176A96"
            };
            _UserList.Add(defaultUser);
        }
    }
}
