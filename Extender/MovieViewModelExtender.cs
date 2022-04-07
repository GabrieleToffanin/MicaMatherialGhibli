using MicaMatherialGhibli.Helpers;
using MicaMatherialGhibli.Model;
using MicaMatherialGhibli.Services;
using MicaMatherialGhibli.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicaMatherialGhibli.Extender
{
    public static class MovieViewModelExtender
    {
        public static void ClearMovieObservableCollection(this MovieViewModel vm)
        {
            vm.moviesCollection.Clear();
        }

         
        public static async IAsyncEnumerable<Movie> LoadAllMoviesAsync(this MovieViewModel vm, 
                                                                       IMoviesCollectionService moviesCollectionService, 
                                                                       ISingleMovieService singleMovieService)
        {
            var result = await moviesCollectionService.getAllMoviesID();
            

            foreach (var item in result)
                yield return await singleMovieService.LoadMoviesAsync(item.id);
        }

        public static async IAsyncEnumerable<People> LoadCurrentMoviePeopleAsync(this MovieViewModel vm,
                                                                                 IPeapleInMovieService peapleInMovieService)
        {
            var result = await peapleInMovieService.FindAllPeople();
            

            foreach(var element in result)
            {
                yield return element;
            }
        }

        public static IEnumerable<People> GetCurrentIdMovieFromSelectedMovie(this MovieViewModel vm)
        {
            var currentMovie = vm.SelectedMovie;

            foreach(var item in vm.currentMoviePeople)
            {
                var currentID = item.films[0].Split("/");

                if (currentMovie.id.Equals(currentID[currentID.Length - 1]))
                    yield return item;
            }
        }


        
    }
}
