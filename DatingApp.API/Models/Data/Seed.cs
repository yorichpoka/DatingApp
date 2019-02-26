using System.Collections.Generic;
using DatingApp.API.Models.Entity;
using DatingApp.API.Models.Helpers;
using Newtonsoft.Json;

namespace DatingApp.API.Models.Data
{
    public class Seed
    {
        private readonly DataContext _Context;

        public Seed(DataContext context)
        {
            this._Context = context;
        }

        public void SeedUsers()
        {
            var userData = System.IO.File.ReadAllText("Models/Data/UserSeedData.json");
            var users = JsonConvert.DeserializeObject<List<User>>(userData);

            using(var transaction = this._Context.Database.BeginTransaction())
            {
                try 
                {
                    foreach(var user in users)
                    {
                        byte[] passwordHash, passwordSalt;

                        Tools.CreatePasswordHash("password", out passwordHash, out passwordSalt);

                        user.PasswordHash = passwordHash;
                        user.PasswordSalt = passwordSalt;
                        user.Username = user.Username.ToLower();

                        this._Context.Add(user);
                    }

                    this._Context.SaveChanges();

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }
        }
    }
}