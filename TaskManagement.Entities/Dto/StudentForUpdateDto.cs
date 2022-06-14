using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Entities.Dto
{
    public class StudentForUpdateDto
    {
        [Required(ErrorMessage = "Student Name Is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Student Birth Date Is Required")]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Student Year of Birth Is Required")]
        public int YearOfBirth { get; set; }
    }
}
