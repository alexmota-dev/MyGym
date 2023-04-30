using MyGym.Data;
using MyGym.Repository.Interface;
using MyGym.Repository;
using Microsoft.EntityFrameworkCore;

namespace MyGym
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //Conexão com o DB
            builder.Services.AddDbContext<MyGymDBContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
            //Injeção de dependência, UserRepository usa IUseRepository
            builder.Services.AddScoped<IUserRepository, UserRepository>();
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
