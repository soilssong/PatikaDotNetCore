using BandAPIV2.Dto.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandAPIV2.Dto.BandDtos
{
    public class BandUpdateDto : IDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public string Genre { get; set; }
    }
}
