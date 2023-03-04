using DataAccess.Interfaces;
using DataAccess.Repositories;
using Dtos;
using Dtos.MovieDtos;
using Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IMovieService 
    {
        Task<List<GetMovieDto>> GetAll();

        Task Create(MovieCreateDto dto);

        Task<GetMovieDto> GetById(int id);
        Task Remove(int id);

        Task Update(MovieUpdateDto dto);


    }
}
