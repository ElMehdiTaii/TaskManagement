using Microsoft.EntityFrameworkCore;
using TaskManagement.Entities.Models;

namespace TaskManagement.Services.EF
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        { }
        public DbSet<Students> Students { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        //public DbSet<TasksExecution> TasksExecution { get; set; }
        public DbSet<Tasks> Tasks { get; set; }

    }
}