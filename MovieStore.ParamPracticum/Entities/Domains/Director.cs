using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Domains
{
    public class Director : BaseEntity
    {
      

        public string Name { get; set; }

        public string Surname { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
