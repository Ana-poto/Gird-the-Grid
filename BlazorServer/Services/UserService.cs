﻿using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(IMongoDbSettings settings)
        {
            var client = new MongoClient("mongodb+srv://standard_user:standard_password$$$$$$$@cluster0.vdvzo.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            var database = client.GetDatabase("dotnet");

            _users = database.GetCollection<User>("users"); //settings.CollectionName is not users
        }

        public List<User> Get() =>
            _users.Find(user => true).ToList();
        
        public User Get(string id) =>
            _users.Find<User>(user => user.Id == id).FirstOrDefault();

        //TODO: check if this is really ok and secure
        public User Find(string email)
            => _users.Find<User>(user => user.Email == email).FirstOrDefault();

        public User Create(User user)
        {
            user.Admin = false;
            user.Id = null;
            _users.InsertOne(user);
            return user;
        }

        public void Update(string id, User userIn) =>
            _users.ReplaceOne(user => user.Id == id, userIn);

        public void Remove(User userIn) =>
            _users.DeleteOne(user => user.Id == userIn.Id);

        public void Remove(string id) =>
            _users.DeleteOne(user => user.Id == id);
    }
}