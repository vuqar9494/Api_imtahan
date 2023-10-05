using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_EXAM.Domain.Models
{
    public class LESSONS
    {
        [Key, Column("ID")]
        public int Id { get; set; }
        [Column("NAME")]
        public string Name { get; set; }

        [Column("INSTRUCTOR_NAME")]
        public string InstructorName { get; set; }
        [Column("INSTRUCTOR_SURNAME")]
        public string InstructorSurname { get; set; }
        [Column("CLASS")]
        public int Class { get; set; }
    }
}
