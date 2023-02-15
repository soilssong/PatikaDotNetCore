using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandAPI_V2_Common.ResponseObjects
{
    public class CustomValidationError
    {

        public string ErrorMessage { get; set;}

        public string PropertyName { get; set; }
    }
}
