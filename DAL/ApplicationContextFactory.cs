using DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DAL
{
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionBuilder.UseNpgsql($"Host=localhost; Port=5432; Database=test; Username=tester; password=test");
            
            return new ApplicationContext(optionBuilder.Options);
        }
    }
}
