using System;
using Newtonsoft.Json;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Text;
using CharityTabsServer.DTO;
using CharityTabsServer.Managers;
using System.Collections.Generic;

namespace CityServerConsole
{
    public class MongoController
    {
        private static MongoController _instance;
        public static MongoController instance
        {
            get {
                if (_instance == null)
                    _instance = new MongoController();

                return _instance;
            }
        }

        private IMongoClient _client;
        private IMongoDatabase _database;

        private IMongoCollection<CharityDTO> CharitiesDB;
        private IMongoCollection<UserDTO> UsersDB;

        private MongoController()
        {
            var connectionString = ConfigManager.getString("mongo_connection", true);
            var tableName = ConfigManager.getString("mongo_table", true);

            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase(tableName);
            
            CharitiesDB = _database.GetCollection<CharityDTO>("Charities");
            UsersDB = _database.GetCollection<UserDTO>("Users");


        }

        public CharityDTO getCharity(string CharityID)
        {
            return CharitiesDB.Find((x => x.CharityID == CharityID)).FirstOrDefault();
        }

        public List<CharityDTO> getCharities()
        {
            return CharitiesDB.Find(new BsonDocument()).ToList();
        }

        public void addCharity(CharityDTO charity)
        {
            CharitiesDB.InsertOne(charity);
        }

        public UserDTO getUser(string userID)
        {
            return UsersDB.Find((x => x.userID == userID)).FirstOrDefault();
        }

        public void updateUser(UserDTO user)
        {
            var dataUser = UsersDB?.Find((x => x.userID == user.userID))?.FirstOrDefault();
            
            if(dataUser == null || user.userID != dataUser.userID)
            {
                // Create New User
                UsersDB.InsertOneAsync(user);
            } else {
                // Edit Existing Use 
                UsersDB.ReplaceOneAsync(arg => arg.userID == user.userID, user);
            }
        }

        public void addUser(UserDTO user)
        {
            UsersDB.InsertOne(user);
        }
    }
}
