using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.DataBase;
using System.Data.SqlClient;

namespace Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        MovieDBContext db;
        public MovieRepository()
        {
            db = new MovieDBContext();
        }

        public List<Movie> GetALLMovies()
        {
            using (SqlConnection connection = new SqlConnection(db.GetConnectionString()))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select top 10 Id, Title from Movie";

                cmd.Connection = connection;

                SqlDataReader reader = cmd.ExecuteReader();
                List<Movie> lstCollection = new List<Movie>();
                while (reader.Read())
                {
                    Movie m = new Movie();
                    m.Id = Convert.ToInt32(reader["Id"]);
                    m.Title = Convert.ToString(reader["Title"]);
                   
                    lstCollection.Add(m);
                }
                connection.Close();
                return lstCollection;
            }
        }

        public Movie GetGenreById()
        {
            throw new NotImplementedException();
        }

        public List<Movie> GetHighest30GrossingMovies()
        {
            throw new NotImplementedException();
        }

        public Movie GetMovieById()
        {
            throw new NotImplementedException();
        }

        public Movie GetReviewById()
        {
            throw new NotImplementedException();
        }

        public Movie GetTopRatedMovie()
        {
            throw new NotImplementedException();
        }

        public Movie GetTopRevenueMovie()
        {
            throw new NotImplementedException();
        }
    }
}
