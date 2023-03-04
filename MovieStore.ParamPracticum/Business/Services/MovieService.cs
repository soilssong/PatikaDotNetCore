using AutoMapper;
using Business.Interfaces;
using DataAccess.Interfaces;
using Dtos;
using Dtos.MovieDtos;
using Entities.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Movie> _repository;
      
        public MovieService(IMapper mapper, IRepository<Movie> repository)
        {
            _mapper = mapper;
            _repository = repository;
         
        }

        public async Task Create(MovieCreateDto dto)
        {
            await _repository.Create(_mapper.Map<Movie>(dto));
            await _repository.SaveChanges();
        }

       
        public async Task<List<GetMovieDto>> GetAll()
        {
           // var query = _repository.Entity;

           //var firstOptions = await query.Include(x => x.Genre)
           //      .Include(x => x.Director)
           //      .Include(x => x.Actors).ThenInclude(x => x.Actor)
           //      .Select(x => new GetMovieDto()
           //      {
           //          Id = x.Id,
           //          Name = x.Name,
           //          DirectorName = x.Director.Name,
           //          GenreName = x.Genre.Name,
           //          Price = x.Price,
           //          Actors = x.Actors.Select(x=>x.Actor.Name).ToList(),
           //      }).ToListAsync();


            var query2 = _repository.Query.Include(x => x.Genre)
                 .Include(x => x.Director)
                 .Include(x => x.Actors).ThenInclude(x => x.Actor);


            //var fourthOPtions = _genreRepo.
            //    GetAllAsyncWithInclude(c => c.Include(x => x.AppCustomers).ThenInclude(x=>x.Customer));

            var secondOptions = await query2.ToListAsync();



            List<GetMovieDto> movies = _mapper.Map<List<GetMovieDto>>(secondOptions);


            //var thirdOptions = await _mapper.ProjectTo<GetMovieDto>(query2).ToListAsync();


            return movies;

        }

       

        public async Task<GetMovieDto> GetById(int id)
        {
            var query = _repository.Entity;
            var movie = await _repository.Query.Include(x => x.Genre).Include(x => x.Director)
                .Include(x => x.Actors)
                .ThenInclude(x => x.Actor)
                .SingleOrDefaultAsync(movie => movie.Id == id); 
            return _mapper.Map<GetMovieDto>(movie);
        }

      
        public async Task Remove(int id)
        {
            _repository.Remove(id);
            await _repository.SaveChanges();
        }

     

        public async Task Update(MovieUpdateDto dto)
        {
            _repository.Update(_mapper.Map<Movie>(dto));
            await _repository.SaveChanges();
        }
    }
}
