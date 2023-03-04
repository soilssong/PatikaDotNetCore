using Entities.Domains;
using Entities.Domains.ManyToMany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.MovieDtos
{
    public class MovieCreateDto : IDto
    {

 

        public string Name { get; set; }

        public int GenreId { get; set; }

        public int DirectorId { get; set; }

        public int Price { get; set; }

      
    }
}
