using Microsoft.EntityFrameworkCore;
using PetProject.Domain;

namespace PetProject.Infrastructure
{
    public class TodoDBContext : DbContext
    {
        public TodoDBContext(DbContextOptions options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // использование Fluent API
            base.OnModelCreating(modelBuilder);
            
        }
    }
}
