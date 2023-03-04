
using Entities.Domains;
using Entities.Domains.ManyToMany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.MovieDtos
{
    public class GetMovieDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GenreName { get; set; }
        public string DirectorName { get; set; }
        public int Price { get; set; }
        public List<string> Actors { get; set; }

    }
}
