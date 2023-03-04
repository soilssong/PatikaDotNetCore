using Entities.Domains.ManyToMany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Domains
{
    public class Movie : BaseEntity
    {

     

        public string Name { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public int DirectorId { get; set; }
        public Director Director { get; set; }

        public List<OrderDetails> OrderDetails { get; set; }

        public ICollection<ActorMovie> Actors { get; set; }

      



        public int Price { get; set; }

    


    }
}
