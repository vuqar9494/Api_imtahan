using API_EXAM.Domain.Models;
using API_EXAM.DTO.ResponseModels.Inner.ViewModel;
using API_EXAM.Logging;
using API_EXAM.Services.Interface;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace API_EXAM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        private readonly IRepository<STUDENTS> _student;
        private readonly IRepository<EXAMS> _exam;
        private readonly IRepository<LESSONS> _lesson;
        private readonly ILoggerManager _logger;
        private readonly ICourseService _courseService;
        public LessonsController(
            ICourseService courseService,
            ILoggerManager logger,
            IRepository<STUDENTS> student,
            IRepository<EXAMS> exam,
            IRepository<LESSONS> lesson
            )
        {
            _logger = logger;
            _courseService = courseService;
            _student = student;
            _exam = exam;
            _lesson = lesson;
        }
        [HttpGet("get-exam-list")]
        public IActionResult GetExamList(string name, string insname, string lessname, int? clas, int page, int limit)
        {
            ResponseListTotal<ViewModelLesson> response = new ResponseListTotal<ViewModelLesson>();
            response.Response = new DTO.ResponseModels.ResponseTotal<ViewModelLesson>();
            response.Status = new();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {

                var result = _courseService.GetAllList(name, insname, lessname, clas, page, limit);
                response.Response.Data = result.list;
                response.Response.Total = result.count;
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message.ToString());
                response.Status.ErrorCode = 1;
                response.Status.Message = "A system error has occurred." + e;
                return BadRequest(response);
            }
        }


        [HttpGet("get-all-detail")]
        public IActionResult GetAllDetail(int id)
        {
            ResponseObject<ViewModelLesson> response = new ResponseObject<ViewModelLesson>();
            response.Status = new();

            try
            {

                var result = _courseService.GetAllDetail(id);
                response.Response = result;
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message.ToString());
                response.Status.ErrorCode = 1;
                response.Status.Message = "A system error has occurred." + e;
                return BadRequest(response);
            }

        }


        [HttpGet("get-lesson-list")]
        public IActionResult GetLessonList(string name, string insname, int? clas, int page, int limit)
        {
            ResponseListTotal<LESSONS> response = new ResponseListTotal<LESSONS>();
            response.Response = new DTO.ResponseModels.ResponseTotal<LESSONS>();
            response.Status = new();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {

                var result = _courseService.GetLessonList(name, insname, clas, page, limit);
                response.Response.Data = result.list;
                response.Response.Total = result.count;
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message.ToString());
                response.Status.ErrorCode = 1;
                response.Status.Message = "A system error has occurred." + e;
                return BadRequest(response);
            }
        }

        [HttpGet("get-lesson-detail")]
        public IActionResult GetLessonDetail(int id)
        {
            ResponseObject<LESSONS> response = new ResponseObject<LESSONS>();
            response.Status = new();

            try
            {

                var result = _courseService.GetLessonDetail(id);
                response.Response = result;
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message.ToString());
                response.Status.ErrorCode = 1;
                response.Status.Message = "A system error has occurred." + e;
                return BadRequest(response);
            }

        }

        [HttpGet("get-student-list")]
        public IActionResult GetStudentList(string name, string surname, int? clas, int page, int limit)
        {
            ResponseListTotal<STUDENTS> response = new ResponseListTotal<STUDENTS>();
            response.Response = new DTO.ResponseModels.ResponseTotal<STUDENTS>();
            response.Status = new();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {

                var result = _courseService.GetStudentList(name, surname, clas, page, limit);
                response.Response.Data = result.list;
                response.Response.Total = result.count;
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message.ToString());
                response.Status.ErrorCode = 1;
                response.Status.Message = "A system error has occurred." + e;
                return BadRequest(response);
            }
        }


        [HttpGet("get-student-detail")]
        public IActionResult GetStudentDetail(int id)
        {
            ResponseObject<STUDENTS> response = new ResponseObject<STUDENTS>();
            response.Status = new();

            try
            {

                var result = _courseService.GetStudentDetail(id);
                response.Response = result;
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message.ToString());
                response.Status.ErrorCode = 1;
                response.Status.Message = "A system error has occurred." + e;
                return BadRequest(response);
            }

        }


        ///////////////////////////

        [Route("cre-or-upd-lesson")]
        [HttpPost]
        public async Task<IActionResult> CreateOrUpdateLesson(LESSONS model)
        {
            ResponseSimple response = new ResponseSimple();
            response.Status = new StatusModel();

            try
            {
                using (var transaction = _lesson.BeginTransaction())
                {
                    try
                    {
                        if (model.Id == 0)
                        {
                            LESSONS l = new LESSONS();
                            l.Name = model.Name;
                            l.InstructorName = model.InstructorName;
                            l.Class = model.Class;
                            l.InstructorSurname = model.InstructorSurname;
                            _lesson.Insert(l);

                            response.Status.Message = "Dərs uğurla əlavə olundu.";
                        }
                        else
                        {
                            var l =_courseService.GetLessonDetail(model.Id) ;
                            l.Name = model.Name;
                            l.InstructorName = model.InstructorName;
                            l.Class = model.Class;
                            l.InstructorSurname = model.InstructorSurname;
                            _lesson.Update(l);
                            response.Status.Message = "Dərs uğurla yeniləndi.";
                        }

                        await _lesson.SaveAsync();



                        transaction.Commit();
                        response.Status.ErrorCode = 0;
                        
                        return Ok(response);
                    }    
            catch (Exception e)
            {

                _logger.LogError("TraceId: " + $", DB error: {nameof(CreateOrUpdateLesson)}: " + $"{e}");
                ;
                transaction.Rollback();
                return BadRequest("There was a problem updating the database!");
            }
        }
    }
             catch (Exception e)
            {
                _logger.LogError("TraceId: " + $", DB error: {nameof(CreateOrUpdateLesson)}: " + $"{e}");
                ;

                response.Status.ErrorCode = ErrorCodes.DB;
                response.Status.Message = "There was a problem updating the database!";
                return Ok(response);
}
        }

        [Route("cre-or-upd-student")]
        [HttpPost]
        public async Task<IActionResult> CreateOrUpdateStudent(STUDENTS model)
        {
            ResponseSimple response = new ResponseSimple();
            response.Status = new StatusModel();

            try
            {
                using (var transaction = _student.BeginTransaction())
                {
                    try
                    {
                        if (model.Id == 0)
                        {
                            STUDENTS l = new STUDENTS();
                            l.Name = model.Name;
                            l.Surname = model.Surname;
                            l.Class = model.Class;
                            _student.Insert(l);

                            response.Status.Message = "Şagird uğurla əlavə olundu.";
                        }
                        else
                        {
                            var l = _courseService.GetStudentDetail(model.Id);
                            l.Name = model.Name;
                            l.Surname = model.Surname;
                            l.Class = model.Class;
                            _student.Update(l);
                            response.Status.Message = "Şagird uğurla yeniləndi.";
                        }

                        await _student.SaveAsync();



                        transaction.Commit();
                        response.Status.ErrorCode = 0;

                        return Ok(response);
                    }
                    catch (Exception e)
                    {

                        _logger.LogError("TraceId: " + $", DB error: {nameof(CreateOrUpdateStudent)}: " + $"{e}");
                        ;
                        transaction.Rollback();
                        return BadRequest("There was a problem updating the database!");
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + $", DB error: {nameof(CreateOrUpdateStudent)}: " + $"{e}");
                ;

                response.Status.ErrorCode = ErrorCodes.DB;
                response.Status.Message = "There was a problem updating the database!";
                return Ok(response);
            }
        }


        [Route("cre-or-upd-exam")]
        [HttpPost]
        public async Task<IActionResult> CreateOrUpdateExam(EXAMS model)
        {
            ResponseSimple response = new ResponseSimple();
            response.Status = new StatusModel();

            try
            {
                using (var transaction = _exam.BeginTransaction())
                {
                    try
                    {
                        if (model.Id == 0)
                        {
                            EXAMS l = new EXAMS();
                            l.StudentId = model.StudentId;
                            l.LessonId = model.LessonId;
                            l.ExamDate = model.ExamDate;
                            l.Point=model.Point;    
                            _exam.Insert(l);

                            response.Status.Message = "İmtahan uğurla əlavə olundu.";
                        }
                        else
                        {
                            var l = _exam.AllQuery.FirstOrDefault(x=>x.Id==model.Id);
                            
                            l.StudentId = model.StudentId;
                            l.LessonId = model.LessonId;
                            l.ExamDate = model.ExamDate;
                            l.Point = model.Point;
                            _exam.Update(l);
                            response.Status.Message = "İmtahan uğurla yeniləndi.";
                        }

                        await _student.SaveAsync();



                        transaction.Commit();
                        response.Status.ErrorCode = 0;

                        return Ok(response);
                    }
                    catch (Exception e)
                    {

                        _logger.LogError("TraceId: " + $", DB error: {nameof(CreateOrUpdateExam)}: " + $"{e}");
                        ;
                        transaction.Rollback();
                        return BadRequest("There was a problem updating the database!");
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + $", DB error: {nameof(CreateOrUpdateExam)}: " + $"{e}");
                ;

                response.Status.ErrorCode = ErrorCodes.DB;
                response.Status.Message = "There was a problem updating the database!";
                return Ok(response);
            }
        }


        [Route("delete-lesson")]
        [HttpGet]
        public IActionResult DeleteLesson(int id)
        {
            ResponseSimple response = new ResponseSimple();
            response.Status = new StatusModel();
          

            try
            {
                var l = _lesson.AllQuery.FirstOrDefault(x => x.Id == id);
                var exam= _exam.AllQuery.FirstOrDefault(x => x.LessonId == l.Id);
                if (exam !=null)
                {
                    _exam.Remove(exam);
                    _exam.Save();
                }
              

                _lesson.Remove(l);
                _lesson.Save();

                response.Status.Message = "Dərs uğurla silindi.";

                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + $", DB error: {nameof(DeleteLesson)}: " + $"{e}");
                ;

                return BadRequest("There was a problem updating the database!");
            }
        }


        [Route("delete-student")]
        [HttpGet]
        public IActionResult DeleteStudent(int id)
        {
            ResponseSimple response = new ResponseSimple();
            response.Status = new StatusModel();


            try
            {
                var l = _student.AllQuery.FirstOrDefault(x => x.Id == id);
                var exam = _exam.AllQuery.FirstOrDefault(x => x.LessonId == l.Id);
                if (exam != null)
                {
                    _exam.Remove(exam);
                    _exam.Save();
                }


                _student.Remove(l);
                _student.Save();

                response.Status.Message = "Şagird uğurla silindi.";

                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + $", DB error: {nameof(DeleteLesson)}: " + $"{e}");
                ;

                return BadRequest("There was a problem updating the database!");
            }
        }


        [Route("delete-exam")]
        [HttpGet]
        public IActionResult DeleteExam(int id)
        {
            ResponseSimple response = new ResponseSimple();
            response.Status = new StatusModel();


            try
            {
             
                var exam = _exam.AllQuery.FirstOrDefault(x => x.Id == id);
              
                    _exam.Remove(exam);
                    _exam.Save();
               


             

                response.Status.Message = "İmtahan uğurla silindi.";

                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + $", DB error: {nameof(DeleteLesson)}: " + $"{e}");
                ;

                return BadRequest("There was a problem updating the database!");
            }
        }
    }
}
