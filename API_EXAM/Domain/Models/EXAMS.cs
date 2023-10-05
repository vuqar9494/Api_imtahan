using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_EXAM.Domain.Models
{
    public class EXAMS
    {
        [Key, Column("ID")]
        public int Id { get; set; }
        [ Column("LESSON_ID")]
        public int LessonId { get; set; }
        [Column("STUDENT_ID")]
        public int StudentId { get; set; }
        [Column("POINT")]
        public int? Point { get; set; }

        [Column("EXAM_DATE")]
        public DateTime? ExamDate { get; set; }


        public STUDENTS Student { get; set; }
        public LESSONS Lesson { get; set; }
    }
}
