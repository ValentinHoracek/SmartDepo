using Microsoft.EntityFrameworkCore;

namespace SmartDepoAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; } = null!;
    }
}
