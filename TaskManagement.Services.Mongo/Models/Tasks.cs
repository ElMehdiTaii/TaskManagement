using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Services.Mongo.Models
{
    public class Tasks
    {
        [BsonId]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int TableName { get; set; }
        public int ActionType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
