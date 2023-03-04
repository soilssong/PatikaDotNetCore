
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.GenreDtos
{
    public class GetGenreDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<string> Movies { get; set; }
    }
}
