using System.Collections;
using System.Threading.Tasks;
using DatingApp.API.Models.Entity;

namespace DatingApp.API.Models.Interface
{
    public interface IDatingRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<IEnumerable> GetUsers();
         Task<User> GetUser(int id);
    }
}