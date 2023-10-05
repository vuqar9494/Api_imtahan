using API_EXAM;
using API_EXAM.DTO.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_EXAM
{
    public class ResponseListTotal<T>
    {
      public  StatusModel Status { get; set; }
      public  ResponseTotal<T> Response  { get; set; }
      public  string TraceID { get; set; }
    }
}
