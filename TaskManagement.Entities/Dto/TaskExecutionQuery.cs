using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Entities.Dto
{
    public class TaskExecutionQuery
    {
        public int TableName { get; set; }
        public int ActionType { get; set; }
    }
}
