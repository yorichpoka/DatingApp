using System.Collections;
using System.Threading.Tasks;
using DatingApp.API.Models.Entity;
using DatingApp.API.Models.Interface;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Models.Data
{
    public class DatingRepository : IDatingRepository
    {
        private readonly DataContext _Context;
        
        public DatingRepository(DataContext context)
        {
            this._Context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            this._Context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {            
            this._Context.Remove(entity);
        }

        public async Task<User> GetUser(int id)
        {
            return
                await this._Context.Users.Include(l => l.Photos).FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<IEnumerable> GetUsers()
        {
            return
                await this._Context.Users.Include(l => l.Photos).ToListAsync();
        }

        public async Task<bool> SaveAll()
        {
            return
                await this._Context.SaveChangesAsync() != 0;
        }
    }
}