using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandAPI_V2_DTOS.BandDtos
{
    public class BandUpdateDto
    {

        public int id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public string Genre { get; set; }
    }
}
