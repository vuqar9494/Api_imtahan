using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_EXAM.Domain.Models
{
    public class STUDENTS
    {
        [Key, Column("ID")]
        public int Id { get; set; }
        [Column("NAME")]
        public string Name { get; set; }

        [Column("SURNAME")]
        public string Surname { get; set; }
        [Column("CLASS")]
        public int Class { get; set; }
    }
}
