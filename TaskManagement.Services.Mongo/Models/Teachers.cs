using MongoDB.Bson.Serialization.Attributes;

namespace TaskManagement.Services.Mongo.Models
{
    public class Teachers
    {
        [BsonId]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string? MainSubjectTeaching { get; set; }
    }
}
