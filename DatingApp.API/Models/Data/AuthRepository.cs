using System;
using System.Threading.Tasks;
using DatingApp.API.Models.Entity;
using DatingApp.API.Models.Helpers;
using DatingApp.API.Models.Interface;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Models.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _Context;
        
        public AuthRepository(DataContext context)
        {
            this._Context = context;
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await this._Context.Users.FirstOrDefaultAsync(l => l.Username == username);

            if(user == null)
                return null;

            if(!Tools.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;

            Tools.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await this._Context.Users.AddAsync(user);
            await this._Context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> UserExist(string username)
        {
            if(await this._Context.Users.AnyAsync(l => l.Username == username))
                return true;

            return false;
        }
    }
}