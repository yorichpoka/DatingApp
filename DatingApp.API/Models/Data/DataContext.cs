using DatingApp.API.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Models.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Value> Values { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
        
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}