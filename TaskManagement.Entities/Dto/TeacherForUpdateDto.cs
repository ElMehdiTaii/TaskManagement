using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace TaskManagement.Entities.Dto
{
    public class TeacherForUpdateDto
    {
        [Required(ErrorMessage = "Teacher Name Is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Teacher Birth Date Name Is Required")]
        public int BirthDate { get; set; }
        [Required(ErrorMessage = "Teacher Main Subject Teaching Is Required")]
        public DateTime MainSubjectTeaching { get; set; }
    }
}
