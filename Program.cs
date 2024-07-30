using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Text.Json;
using MovieStoreApp.Controllers;
using MovieStoreApp.Exceptions;
using MovieStoreApp.Models;
using MovieStoreApp.Repositories;
using MovieStoreApp.Serializer;
namespace MovieStoreApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MovieStore.DisplayMenu();
        }
    }
}
