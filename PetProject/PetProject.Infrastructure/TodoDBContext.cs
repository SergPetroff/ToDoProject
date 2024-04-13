using Microsoft.EntityFrameworkCore;
using PetProject.Domain;

namespace PetProject.Infrastructure
{
    public class TodoDBContext : DbContext
    {
        public TodoDBContext(DbContextOptions options) : base(options) { }
        public DbSet<Todo> Todos { get; set; }

    }
}
