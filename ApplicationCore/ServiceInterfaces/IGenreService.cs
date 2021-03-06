using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IGenreService
    {
        public Task<List<GenreModel>> GetAllGenres();

        public Task<GenreModel> GetGenreByGenreId(int gid);
    }
}
