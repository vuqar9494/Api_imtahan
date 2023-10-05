using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_EXAM
{
    public class ResponseObject<T>
    {
      public StatusModel Status { get; set; }
      public T Response  { get; set; }
      public string TraceID { get; set; }
    }
}
