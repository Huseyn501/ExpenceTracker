using ExpenceTracker.Data;
using Microsoft.EntityFrameworkCore;

namespace ExpenceTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();
            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
