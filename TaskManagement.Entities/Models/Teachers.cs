namespace TaskManagement.Entities.Models
{
    public class Teachers
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string? MainSubjectTeaching { get; set; }
    }
}
