using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Services.EF.Models
{
    public class Tasks
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int TableName { get; set; }
        public int ActionType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
