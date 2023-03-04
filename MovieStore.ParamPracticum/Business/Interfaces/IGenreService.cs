using Dtos.GenreDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IGenreService
    {
        Task<List<GetGenreDto>> GetAll();

        Task Create(GenreCreateDto dto);

        Task<GetGenreDto> GetById(int id);
        Task Remove(int id);

        Task Update(GenreUpdateDto dto);
    }
}
