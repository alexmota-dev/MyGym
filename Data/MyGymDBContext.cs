using Microsoft.EntityFrameworkCore;
using MyGym.Data.Map;
using MyGym.Models;

namespace MyGym.Data
{
    public class MyGymDBContext : DbContext
    {
        public MyGymDBContext(DbContextOptions<MyGymDBContext>options):base(options)
        {
        }    

        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
