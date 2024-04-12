using Microsoft.EntityFrameworkCore;
using PetProject.Model;

namespace PetProject.Data
{
    public class TodoDBContext : DbContext
    {
        public TodoDBContext(DbContextOptions options) : base(options) { }
        public DbSet<Todo> Todos { get; set; }

    }
}
