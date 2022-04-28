using MicaMatherialGhibli.Model;
using MicaMatherialGhibli.Services;
using MicaMatherialGhibli.ViewModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MicaMatherialGhibli.Extender
{
    public static class MovieViewModelExtender
    {
        public static void ClearMovieObservableCollection(this MovieViewModel vm)
        {
            vm.moviesCollection.Clear();
        }


        public static async Task LoadAllMoviesAsync(this MovieViewModel vm,
                                                    IMoviesCollectionService moviesCollectionService,
                                                    ISingleMovieService singleMovieService)
        {
            
            var result = await moviesCollectionService.getAllMoviesID();
            foreach (var item in result)
                vm.moviesCollection.Add(await singleMovieService.LoadMoviesAsync(item.id));

                    
        }

        public static async Task LoadCurrentMoviePeopleAsync(this MovieViewModel vm,
                                                             IPeapleInMovieService peapleInMovieService)
        {
            
            var result = await peapleInMovieService.FindAllPeople();
            var currentMovie = vm.SelectedMovie;

            foreach (var element in result)
            {
                var currentID = element.films[0].Split("/");

                if (currentMovie.id.Equals(currentID[currentID.Length - 1]))
                    vm.currentMoviePeople.Add(element);
            }
        }
    }
}
