using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConstosoUniversityCodeFirst1.Models
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EnrollDate { get; set; }
    }
}