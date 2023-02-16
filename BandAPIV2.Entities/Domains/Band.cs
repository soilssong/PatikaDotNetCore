using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandAPIV2.Entities.Domains
{
    public class Band : BaseEntity
    {

        

        public string Name { get; set; }

        public string Country { get; set; }

        public string Genre { get; set; }
    }
}
