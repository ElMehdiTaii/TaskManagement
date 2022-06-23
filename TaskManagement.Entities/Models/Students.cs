using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Entities.Models
{
    public class TasksExecution
    {
        public Guid Id { get; set; }
        public DateTime TaskStartDate { get; set; }
        public DateTime TaskEndDate { get; set; }
        public int? TaskId { get; set; }
        public Tasks? Task { get; set; }
    }
}
