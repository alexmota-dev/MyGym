using Microsoft.EntityFrameworkCore;
using MyGym.Models;

namespace MyGym.Data
{
    public class MyGymDBContext : DbContext
    {
        public MyGymDBContext(DbContextOptions<MyGymDBContext>options):base(options)
        {
        }    

        public DbSet<UserModel> Users { get; set; } 
    }
}
