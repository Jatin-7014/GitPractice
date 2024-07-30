using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStoreApp.Exceptions;
using MovieStoreApp.Models;
using MovieStoreApp.Serializer;

namespace MovieStoreApp.Repositories
{
    internal class MovieManager
    {
        public static List<Movie> movies = new List<Movie>();

        public static void ManageMovies()
        {
            movies = DataSerializer.DeserializeMovies();
        }

        public static void AddNewMovies(int id,string name,int year,string genre)
        {
            if (movies.Count < 5)
            {
                Movie movie = Movie.AddNewMovie(id, name, year, genre);
                movies.Add(movie);
            }
            else
                throw new MemorySpaceFullException("Memory space is full can't add another movie...");
        }

        public static List<Movie> DisplayMovies()
        {
            if (movies.Count == 0)
                throw new MovieListEmptyException("Movies List is empty...");
            else
                return movies;
        }

        public static Movie FindMovieById(int id)
        {
            Movie findMovie = null;
            findMovie = movies.Where(item => item.Id == id).FirstOrDefault();
            if(findMovie != null)
            return findMovie;
            else
                throw new MovieNotFoundException("Movie not found.....");
        }

        public static void RemoveMovie(int id)
        {
            Movie findMovie = FindMovieById(id);
            if (findMovie != null)
            {
                movies.Remove(findMovie);
                throw new MovieRemovedSuccessException("Movie Removed Successfully....");
            }
            else
                throw new MovieNotFoundException("Movie not found.....");
        }

        public static void ClearAllMovies()
        {
            if (movies.Count == 0)
                throw new MovieListEmptyException("Movies List is Empty....\nNothing to Clear");
            else
                movies.Clear();
        }

        public static void ExitMovies()
        {
            DataSerializer.SerializeMovies(movies);
        }
    }
}
