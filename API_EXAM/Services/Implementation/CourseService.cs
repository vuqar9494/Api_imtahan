
using API_EXAM.Domain.Models;
using API_EXAM.DTO.ResponseModels.Inner.ViewModel;
using API_EXAM.Logging;
using API_EXAM.Services.Interface;
using Infrastructure;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace API_EXAM.Services.Implementation
{
    public class CourseService: ICourseService
    {
        private readonly ILoggerManager _logger;
        private readonly IRepository<STUDENTS> _student;
        private readonly IRepository<EXAMS> _exam;
        private readonly IRepository<LESSONS> _lesson;
        public CourseService(
            ILoggerManager logger,
            IRepository<STUDENTS> student,
            IRepository<EXAMS> exam,
            IRepository<LESSONS> lesson
            )
        {
            _logger = logger;
            _student = student;
            _exam = exam;
            _lesson = lesson;   
        }

        public  (int count, List<ViewModelLesson> list) GetAllList(string name, string insname, string lessname, int? clas, int page, int limit)
        {
            int skip = (page - 1) * limit;

            var count = _exam.AllQuery.Include(x => x.Student).Include(x => x.Lesson).OrderByDescending(x => x.ExamDate).Where(
              x =>
              ((string.IsNullOrEmpty(name)) ? true : (x.Student.Name+" "+x.Student.Surname).Contains(name)) &&
               ((string.IsNullOrEmpty(insname)) ? true : x.Lesson.InstructorName.Contains(insname)) &&
                   ((string.IsNullOrEmpty(lessname)) ? true : x.Lesson.Name.Contains(lessname)) &&
           ((clas == null) ? true : x.Lesson.Class == clas) 
              ).Count();

            var list = _exam.AllQuery.Include(x => x.Student).Include(x => x.Lesson).OrderBy(x => x.ExamDate).Where(
              x =>
               
              ((string.IsNullOrEmpty(name)) ? true : (x.Student.Name + " " + x.Student.Surname).Contains(name)) &&
               ((string.IsNullOrEmpty(insname)) ? true : x.Lesson.InstructorName.Contains(insname)) &&
                   ((string.IsNullOrEmpty(lessname)) ? true : x.Lesson.Name.Contains(lessname)) &&
           ((clas == null) ? true : x.Lesson.Class == clas)
              ).Skip(skip).Take(limit).Select(x=>
              new ViewModelLesson {
                  Name=x.Student.Name,
                  SurName=x.Student.Surname,
                  LessName=x.Lesson.Name,
                  InsName=x.Lesson.InstructorName+" "+ x.Lesson.InstructorSurname, 
                  Clas=x.Lesson.Class,
                  ExamDate =x.ExamDate,
                  Point=x.Point,
                  ExamId=x.Id,
                  LesId=x.Lesson.Id, 
                  StudId=x.Student.Id,

              } )
             .ToList();
            return (count, list);
        }


        public  ViewModelLesson GetAllDetail(int id)
        {
           

        
            var l = _exam.AllQuery.Include(x => x.Student).Include(x => x.Lesson).OrderBy(x => x.ExamDate)
                .Select(x =>
              new ViewModelLesson
              {
                  Name = x.Student.Name,
                  SurName = x.Student.Surname,
                  LessName = x.Lesson.Name,
                  InsName = x.Lesson.InstructorName + " " + x.Lesson.InstructorSurname,
                  Clas = x.Student.Class,
                  ExamDate = x.ExamDate,
                  Point = x.Point,
                  ExamId = x.Id,
                  LesId = x.Lesson.Id,
                  StudId = x.Student.Id,

              }).FirstOrDefault(x => x.ExamId == id);
            return l;
        }

        public (int count, List<LESSONS> list) GetLessonList(string name, string insname, int? clas, int page, int limit)
        {
            int skip = (page - 1) * limit;

            var count = _lesson.AllQuery.OrderBy(x => x.Name).Where(
              x =>
              ((string.IsNullOrEmpty(name)) ? true : x.Name.Contains(name)) &&
               ((string.IsNullOrEmpty(insname)) ? true : x.InstructorName.Contains(insname)) &&
           ((clas == null) ? true : x.Class == clas)
              ).Count();

            var list = _lesson.AllQuery.OrderBy(x => x.Name).Where(
              x =>

              ((string.IsNullOrEmpty(name)) ? true : x.Name.Contains(name)) &&
               ((string.IsNullOrEmpty(insname)) ? true : x.InstructorName.Contains(insname)) &&
           ((clas == null) ? true : x.Class == clas)
              ).Skip(skip).Take(limit)
             .ToList();
            return (count, list);
        }

        public LESSONS GetLessonDetail(int id)
        {



            var l = _lesson.AllQuery.OrderBy(x => x.Name).FirstOrDefault(x => x.Id == id);
            return ( l);
            
        }

        public (int count, List<STUDENTS> list) GetStudentList(string name, string surname, int? clas, int page, int limit)
        {
            int skip = (page - 1) * limit;

            var count = _student.AllQuery.OrderBy(x => x.Name).Where(
              x =>
              ((string.IsNullOrEmpty(name)) ? true : (x.Name + " " + x.Surname).Contains(name)) &&
               ((string.IsNullOrEmpty(surname)) ? true : x.Surname.Contains(surname)) &&
           ((clas == null) ? true : x.Class == clas)
              ).Count();

            var list = _student.AllQuery.OrderBy(x => x.Name).Where(
              x =>

              ((string.IsNullOrEmpty(name)) ? true : (x.Name + " " + x.Surname).Contains(name)) &&
               ((string.IsNullOrEmpty(surname)) ? true : x.Surname.Contains(surname)) &&
           ((clas == null) ? true : x.Class == clas)
              ).Skip(skip).Take(limit)
             .ToList();
            return (count, list);
        }

        public STUDENTS GetStudentDetail(int id)
        {



            var l = _student.AllQuery.OrderBy(x => x.Name).FirstOrDefault(x => x.Id == id);
            return (l);

        }
    }

}
