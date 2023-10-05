using API_EXAM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_EXAM
{
    public class ResponseList<T>
    {
        public StatusModel Status { get; set; }
        public List<T> Data { get; set; }
        public string TraceID { get; set; }
    }
}
