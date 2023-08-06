using Microsoft.EntityFrameworkCore;
using TodoApp.API.Models;

namespace TodoApp.API.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions Options) : base(Options) { }

        public DbSet<Todo> Todos { get; set; }

    }
}
