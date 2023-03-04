using Entities.Domains.ManyToMany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Domains
{
    public class Genre : BaseEntity
    {
      

        public string Name { get; set; }

        public ICollection<CustomerGenre> AppCustomers { get; set; }

        public List<Movie> Movies { get; set; }
    }
}
