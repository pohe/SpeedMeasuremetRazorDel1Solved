using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeedMeasuremetRazor.Exceptions
{
    public class UniqIdException: Exception
    {
        public UniqIdException(string message): base(message)
        {
            
        }
    }
}
