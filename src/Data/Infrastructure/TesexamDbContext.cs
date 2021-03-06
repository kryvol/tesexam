﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Identity3.MongoDB;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using Data.Interfaces;

namespace Data.Infrastructure
{
    public class TesexamDbContext :  MongoIdentityContext<ApplicationUser, IdentityRole>, IMongoDbContext
    {
        private IConfigurationRoot _configuration;
        public TesexamDbContext(IConfigurationRoot configuration) : base()
        {
            _configuration = configuration;

            string connectionString = configuration.GetConnectionString("TesexamConnectionString");
            string databaseName = configuration.GetConnectionString("TesexamDB");

            var client = new MongoClient(connectionString);
            Database = client.GetDatabase(databaseName);

            this.Users = Database.GetCollection<ApplicationUser>("users");
            this.Roles = Database.GetCollection<IdentityRole>("roles");
        }

        public IMongoDatabase Database { get; set; }
        
    }
}
