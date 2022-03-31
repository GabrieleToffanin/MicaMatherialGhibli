using MicaMatherialGhibli.Model;
using MicaMatherialGhibli.Services;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicaMatherialGhibli.ViewModel
{
    public class MovieViewModel
    {
        public ObservableCollection<Movie> moviesCollection = new ObservableCollection<Movie>();
        private readonly IMoviesCollectionService singleIdService = Ioc.Default.GetRequiredService<IMoviesCollectionService>();
        private readonly ISingleMovieService allMoviesService = Ioc.Default.GetRequiredService<ISingleMovieService>();
        private readonly List<string> idsCollection = new List<string>();

        public MovieViewModel()
        {
            LoadAllMovies();
        }


        private async void LoadAllMovies()
        {
            moviesCollection.Clear();

            var response = await singleIdService.getAllMoviesID();

            foreach (var item in response)
            {

                var result = await allMoviesService.LoadMoviesAsync(item.id);

                moviesCollection.Add(result);
            }

        }

    }
}

