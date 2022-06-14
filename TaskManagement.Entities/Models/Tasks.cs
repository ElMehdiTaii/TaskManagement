using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Entities.Models
{
    public class Tasks
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? TableName { get; set; }
        public string? ActionType { get; set; }
        public DateTime TaskStartDate { get; set; }
        public DateTime TaskEndDate { get; set; }
    }
}
