using Entities.Domains.ManyToMany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Domains
{
    public class Actor :BaseEntity
    {

    

        public string Name { get; set; }

        public string Surname { get; set; }

        public ICollection<ActorMovie> Movies { get; set; }

       


    }
}
