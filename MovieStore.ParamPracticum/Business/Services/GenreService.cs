using AutoMapper;
using Business.Interfaces;
using DataAccess.Interfaces;
using Dtos.GenreDtos;
using Entities.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class GenreService : IGenreService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Genre> _repository;

        public GenreService(IMapper mapper, IRepository<Genre> repository)
        {
            _mapper = mapper;
            _repository = repository;

        }
        public async Task Create(GenreCreateDto dto)
        {
            await _repository.Create(_mapper.Map<Genre>(dto));
            await _repository.SaveChanges();
        }

        public async Task<List<GetGenreDto>> GetAll()
        {
            var query2 = _repository.Query.Include(x => x.Movies);
            var secondOptions = await query2.ToListAsync();
            List<GetGenreDto> genres = _mapper.Map<List<GetGenreDto>>(secondOptions);
            return genres;
        }

        public async Task<GetGenreDto> GetById(int id)
        {
            var query = _repository.Entity;
            var movie = await _repository.Query.Include(x => x.Movies).SingleOrDefaultAsync(movie => movie.Id == id);
            return _mapper.Map<GetGenreDto>(movie);
        }

        public async Task Remove(int id)
        {
            _repository.Remove(id);
            await _repository.SaveChanges();
        }

        public async Task Update(GenreUpdateDto dto)
        {
            _repository.Update(_mapper.Map<Genre>(dto));
            await _repository.SaveChanges();
        }
    }
}
