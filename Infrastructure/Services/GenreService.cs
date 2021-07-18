using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        public async Task<List<GenreModel>> GetAllGenres()
        {
            var genres = await _genreRepository.ListAllAsync();
            var genresModel = new List<GenreModel>();

            foreach (var genre in genres)
            {
                genresModel.Add(new GenreModel { Id = genre.ID, Name = genre.Name });
            }

            return genresModel;

        }

        // var genreModel = await genresModel.Orderby(g => g.Name).ToList(); // don't have ToListAsync.

    }
}
