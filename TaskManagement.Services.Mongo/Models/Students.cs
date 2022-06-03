using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Services.Mongo.Models
{
    public class Students
    {
        [BsonId]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int YearOfStudy { get; set; }
    }
}
