using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TaskManagement.Entities.Dto
{
    public class TaskForUpdateDto
    {
        [Required(ErrorMessage = "Task Name Is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Task Table Name Is Required")]
        public string TableName { get; set; }
        [Required(ErrorMessage = "Task Start Date Is Required")]
        public DateTime TaskStartDate { get; set; }
        [Required(ErrorMessage = "Task End Date Is Required")]
        public DateTime TaskEndDate { get; set; }
        [Required(ErrorMessage = "Task Action Type Is Required")]
        public string ActionType { get; set; }
    }
}
