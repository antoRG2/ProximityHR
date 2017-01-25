using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proximity.HR.Models.ErrorHandler
{
    public enum ResponseCode
    {
        Error = 0,
        Success = 1,
        Exception = 2,
        NoData = 3,
        LogOut = 4
    }

    public abstract class GenericResponse<T>
    {
        public T Response { get; set; }
        public ResponseCode Status { set; get; }
        public string Message { get; set; }
        public Exception Exception { set; get; }
    }
}
