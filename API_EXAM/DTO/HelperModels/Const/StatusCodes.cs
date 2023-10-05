using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_EXAM
{
    public class StatusCodes
    {
        public const int OK = 200;
        public const int AUTH = 401;
        public const int FORBIDDEN = 403;
        public const int BAD_REQUEST = 400;
        public const int INTERNEL_SERVER = 500;
    }
}
