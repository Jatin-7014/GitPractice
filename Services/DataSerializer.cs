using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MovieStoreApp.Models;

namespace MovieStoreApp.Serializer
{
    internal class DataSerializer
    {
        static string Path = ConfigurationManager.AppSettings["filePath"].ToString();
        public static void SerializeMovies(List<Movie>movies)
        {
            using (StreamWriter sw = new StreamWriter(Path, false))
            {
                sw.WriteLine(JsonSerializer.Serialize(movies));
            }
        }

        public static List<Movie> DeserializeMovies()
        {
            if (!File.Exists(Path))
                return new List<Movie>();
            using (StreamReader sr = new StreamReader(Path))
            {
                List<Movie> movies = JsonSerializer.Deserialize<List<Movie>>(sr.ReadToEnd());
                return movies;
            }
        }
    }
}
