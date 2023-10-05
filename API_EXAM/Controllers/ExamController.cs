
using API_EXAM.Interface;
using API_EXAM.Logging;
using API_EXAM.Services.Interface;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace API_EXAM.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
       
        private readonly ILoggerManager _logger;
        private readonly AppConfiguration configuration = new AppConfiguration();
        public ExamController(
        ILoggerManager logger
            )
        {
         
            _logger = logger;
        }

      /*  [HttpPost, Route("GetQuestion")]
        public IActionResult GetQuestion(FilterQuestionVM model, string Role)
        {


            model.skip = (model.skip - 1) * model.limit;
            decimal totalCount = 0;

            ResponseListTotal<QuestionVM> responseList = new ResponseListTotal<QuestionVM>();
            ResponseTotal<QuestionVM> response = new ResponseTotal<QuestionVM>();
            responseList.Response = response;
            responseList.Status = new StatusModel();
            responseList.Status.ErrorCode = 0;


            var currentUser = HttpContext.User;
            var traceId = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            responseList.TraceID = traceId;
            int UserId = Convert.ToInt32(currentUser.FindFirst("UserId").Value);

            var roleC = _authService.GetUserRole(UserId);
            if (!roleC.Contains(Role))
            {
                responseList.Status.ErrorCode = ErrorCodes.AUTH;
                responseList.Status.Message = "You are not authorized to access this applicationror has occurred";
                return Ok(response);

            }

            try
            {
                List<QuestionVM> reports = _questionService.GetQuestions(model, ref totalCount);


                responseList.Response.Data = reports;
                responseList.Response.Total = totalCount;

                if (!reports.Any())
                {
                    responseList.Status.ErrorCode = ErrorCodes.OPERATION;
                    responseList.Status.Message = "Məlumat tapılmadı";
                    return Ok(responseList);
                }

                return Ok(responseList);
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + responseList.TraceID + ", GetUsers: " + $"{e}");
                responseList.Status.ErrorCode = ErrorCodes.SYSTEM;
                responseList.Status.Message = "A system error has occurred." + e.ToString();
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, responseList);
            }


        }
*/

   

/*        [Route("getTimeForExam")]
        [HttpGet]
        public IActionResult getTimeForExam(int Examid)
        {


            var currentUser = HttpContext.User;
            int UserId = Convert.ToInt32(currentUser.FindFirst("UserId").Value);
            Users user = _user.AllQuery.FirstOrDefault(x => x.Id == UserId);
            var roleC = _authService.GetUserRole(UserId);


            try
            {
                var exam = _userExamCon.AllQuery.FirstOrDefault(x => x.Id == Examid);
                var course = _course.AllQuery.FirstOrDefault(x => x.Id == exam.CourseId);
                DateTime date = Convert.ToDateTime(exam.StartDate);
                return Ok(new
                {
                    Date = date,
                    Duration = course.Duration
                });
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + $", DB error: {nameof(CreateQuestion)}: " + $"{e}");
                ;

                return BadRequest("There was a problem updating the database!");
            }
        }*/

    }

}
