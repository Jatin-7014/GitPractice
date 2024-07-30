 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStoreApp.Exceptions;
using MovieStoreApp.Models;
using MovieStoreApp.Repositories;

namespace MovieStoreApp.Controllers
{
    internal class MovieStore
    {
        public static void DisplayMenu()
        {
            MovieManager.ManageMovies();

            while (true)
            {
                Console.WriteLine("==========Welcome to movie store developed by: Jatin=========\n");
                Console.WriteLine("1.Add New Movie\n" +
                    "2.Display All Movies\n" +
                    "3.Find Movie By Id\n" +
                    "4.Remove Movie By Id\n" +
                    "5.Clear All Movies\n" +
                    "6.Exit");
                int choice = Convert.ToInt32(Console.ReadLine());
                try
                {
                    DoTask(choice);
                }
                catch (MemorySpaceFullException msfe)
                {
                    Console.WriteLine(msfe.Message);
                }
                catch (MovieListEmptyException mle)
                {
                    Console.WriteLine(mle.Message);
                }
                catch (MovieNotFoundException mnf)
                {
                    Console.WriteLine(mnf.Message);
                }
                catch (MovieRemovedSuccessException mre)
                {
                    Console.WriteLine(mre.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        static void DoTask(int choice)
        {
            switch (choice)
            {
                case 1:
                    try
                    {
                        Add();
                    }
                    catch (FormatException fe)
                    {
                        Console.WriteLine("Please enter in the valid format..." + fe.Message);
                    }
                    break;

                case 2:
                    Display();
                    break;

                case 3:
                    Find();
                    break;

                case 4:
                    Remove();
                    break;

                case 5:
                    MovieManager.ClearAllMovies();
                    break;

                case 6:
                    MovieManager.ExitMovies();
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Please provide a valid input...");
                    break;
            }
        }

        static void Add()
        {
            Console.WriteLine("Enter Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Year Of Release: ");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Genre: ");
            string genre = Console.ReadLine();
            MovieManager.AddNewMovies(id, name, year, genre);
            Console.WriteLine("New Movie Added Successfully");
        }

        static void Display()
        {
            var movies = MovieManager.DisplayMovies();
            movies.ForEach(item => Console.WriteLine(item));
        }

        static void Find()
        {
            Console.WriteLine("Enter Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var movies = MovieManager.FindMovieById(id);
            Console.WriteLine(movies);
        }

        static void Remove()
        {
            Console.WriteLine("Enter Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            MovieManager.RemoveMovie(id);
        }
    }
}
