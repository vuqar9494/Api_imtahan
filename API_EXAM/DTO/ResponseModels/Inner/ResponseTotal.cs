using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_EXAM.DTO.ResponseModels
{
    public class ResponseTotal<T>
    {
        public System.Collections.Generic.List<T> Data { get; set; }
        public decimal Total { get; set; }
    }
}
