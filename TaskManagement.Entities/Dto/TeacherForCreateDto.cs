using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TaskManagement.Entities.Dto
{
    public class TeacherForCreateDto
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Teacher Name Is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Teacher Birth Date Name Is Required")]
        public int BirthDate { get; set; }
        [Required(ErrorMessage = "Teacher Main Subject Teaching Is Required")]
        public string MainSubjectTeaching { get; set; }

        public TeacherForCreateDto()
        {
            Id = new Guid();
        }
    }
}
