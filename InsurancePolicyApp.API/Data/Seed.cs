using System.Collections.Generic;
using InsurancePolicyApp.API.Models;
using Newtonsoft.Json;

namespace InsurancePolicyApp.API.Data
{
    /* Get data from diferents json files to add it to the database */
    public class Seed
    {
        private readonly DataContext _context;
        public Seed(DataContext context)
        {
            _context = context;
        }

        public void SeedUsers() 
        {
            var userData = System.IO.File.ReadAllText("Data/UserSeedData.json");
            var user = JsonConvert.DeserializeObject<User>(userData);

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash("password", out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Username = user.Username.ToLower();

            _context.Users.Add(user);

            _context.SaveChanges();
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            } 
        }

        public void SeedRiskTypes() 
        {
            var riskTypeData = System.IO.File.ReadAllText("Data/RiskTypeSeedData.json");
            var riskTypes = JsonConvert.DeserializeObject<List<RiskType>>(riskTypeData);
            foreach (var risk in riskTypes)
            {
                _context.RiskTypes.Add(risk);
            }

            _context.SaveChanges();
        }

        public void SeedEventTypes() 
        {
            var eventTypeData = System.IO.File.ReadAllText("Data/EventTypeSeedData.json");
            var eventTypes = JsonConvert.DeserializeObject<List<EventType>>(eventTypeData);
            foreach (var eventType in eventTypes)
            {
                _context.EventTypes.Add(eventType);
            }

            _context.SaveChanges();
        }

        public void SeedPolicies() 
        {
            var policyData = System.IO.File.ReadAllText("Data/PolicySeedData.json");
            var policies = JsonConvert.DeserializeObject<List<Policy>>(policyData);
            foreach (var policy in policies)
            {
                _context.Policies.Add(policy);
            }

            _context.SaveChanges();
        }

        public void SeedClients() 
        {
            var clientData = System.IO.File.ReadAllText("Data/ClientSeedData.json");
            var clients = JsonConvert.DeserializeObject<List<Client>>(clientData);
            foreach (var client in clients)
            {
                _context.Clients.Add(client);
            }

            _context.SaveChanges();
        }
    }
}