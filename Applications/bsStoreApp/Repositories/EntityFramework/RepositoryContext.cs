using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repositories.EntityFramework.Config;
using System.Reflection;

namespace Repositories.EntityFramework
{
    public class RepositoryContext:IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration(new BookConfig());
            //modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // Üstteki gibi tek tek yazmak yerine tek kodda yönetebiliriz.
        }
    }
}
