using System.Threading.Tasks;
using DatingApp.API.Models.Entity;

namespace DatingApp.API.Models.Data
{
    public interface IAuthRepository
    {
         Task<User> Register(User user, string password);
         Task<User> Login(string username, string password);
         Task<bool> UserExist(string username);
    }
}