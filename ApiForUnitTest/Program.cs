using ApiForUnitTest.Interfaces;
using ApiForUnitTest.Models;
using ApiForUnitTest.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ApiForUnitTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // Register DbContext
            builder.Services.AddDbContext<ReactjsDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Register Repositories
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
