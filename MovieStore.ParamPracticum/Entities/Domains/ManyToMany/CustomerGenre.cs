using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Domains.ManyToMany
{
    public class CustomerGenre 
    {

        public int CustomerId { get; set; }

        public int GenreId { get; set; }


        public AppCustomer Customer { get; set; }

        public Genre Genre { get; set; }
    }
}
