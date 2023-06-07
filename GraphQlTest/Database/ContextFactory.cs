using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Database
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyDbContext>
    {
        public MyDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<MyDbContext>();
            builder.LogTo(Console.WriteLine);
            var connectionString = configuration.GetConnectionString("GraphQlTestDb");
            builder.UseNpgsql(connectionString);
            return new MyDbContext(builder.Options);
        }
    }
}
