using System;

namespace API_EXAM.DTO.ResponseModels.Inner.ViewModel
{
    public class ViewModelLesson
    {
        public int ExamId { get; set; }
        public int LesId { get; set; }
        public int StudId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string LessName { get; set; }
        public string InsName { get; set; }
        public int? Clas { get; set; }
        public int? Point { get; set; }
        public DateTime? ExamDate { get; set; }
    }
}
