using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.MovieDtos
{
    public  class MovieUpdateDto : IDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int GenreId { get; set; }

        public int DirectorId { get; set; }

        public int Price { get; set; }
    }
}
