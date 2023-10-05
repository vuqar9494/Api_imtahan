using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_EXAM.Validations
{
    public interface IValidation
    {
        int CheckErrorCode(int error);
    }
}
