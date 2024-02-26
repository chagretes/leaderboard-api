namespace ScoreAPI.DatabaseConnection;

using Microsoft.EntityFrameworkCore;
using ScoreAPI.Entities;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // connect to postgres with connection string from app settings
        optionsBuilder.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
    }

    public DbSet<Score> Scores { get; set; }
}