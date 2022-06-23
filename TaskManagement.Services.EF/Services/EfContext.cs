using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Entities.Models;

namespace TaskManagement.Services.EF.Services
{
    public class EfContext : DbContext
    {
        public EfContext(DbContextOptions<EfContext> options) : base(options)
        { }
        public DbSet<Students> Students { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        //public DbSet<TasksExecution> TasksExecution { get; set; }
        public DbSet<Tasks> Tasks { get; set; }

    }
}
