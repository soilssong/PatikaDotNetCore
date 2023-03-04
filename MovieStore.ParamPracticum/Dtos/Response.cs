using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public class Response
    {
        public Response(string status, string message, object result)
        {
            Status = status;
            Message = message;
            Result = result;
        }
        public Response(string status, string message)
        {
            Status = status;
            Message = message;
            Result = string.Empty;
        }

        public string Status { get; set; }
        public string Message { get; set; }

        public object Result { get; set; }
    }
}
