
using API_EXAM.Domain.Models;
using API_EXAM.DTO.ResponseModels.Inner.ViewModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_EXAM.Services.Interface
{
    public interface ICourseService
    {
        /* Task<bool> AddCourse(string editorName, NewCourseModel model, IFormFile File);*/
        (int count, List<ViewModelLesson> list) GetAllList(string? name, string? insname, string lessname, int? clas, int page, int limit);
        (int count, List<LESSONS> list) GetLessonList(string name, string insname,  int? clas, int page, int limit);
        (int count, List<STUDENTS> list) GetStudentList(string name, string surname, int? clas, int page, int limit);
        ViewModelLesson GetAllDetail(int id);
        LESSONS GetLessonDetail(int id);
        STUDENTS GetStudentDetail(int id);


    }
}
