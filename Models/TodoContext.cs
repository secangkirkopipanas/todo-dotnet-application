using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     if (!optionsBuilder.IsConfigured)
        //     {
        //         IConfigurationRoot configuration = new ConfigurationBuilder()
        //         .SetBasePath(Directory.GetCurrentDirectory())
        //         .AddJsonFile("appsettings.json")
        //         .Build();
        //         var connectionString = configuration.GetConnectionString("DbCoreConnectionString");
        //         optionsBuilder.UseSqlServer(connectionString);
        //     }

        // }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}