using MicaMatherialGhibli.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicaMatherialGhibli.Model
{
    
    public class ApiCallService : IAPICallService
    {
        private readonly IMoviesCollectionService moviesCollectionService;
        private readonly IPeapleInMovieService peapleInMovieService;
        private readonly ISingleMovieService singleMovieService;

        public ApiCallService(  IMoviesCollectionService moviesCollectionService, 
                                IPeapleInMovieService peapleInMovieService, 
                                ISingleMovieService singleMovieService)
        {
            this.moviesCollectionService = moviesCollectionService;
            this.peapleInMovieService = peapleInMovieService;
            this.singleMovieService = singleMovieService;

        }
        public async void LoadAllMovies(ObservableCollection<Movie> moviesCollection)
        {
            moviesCollection.Clear();

            var response = await moviesCollectionService.getAllMoviesID();

            foreach(var movie in response)
            {
                var result = await singleMovieService.LoadMoviesAsync(movie.id);

                moviesCollection.Add(result);
            }
        }

        public async Task LoadAllPeople(ObservableCollection<People> peopleCollection)
        {
            var response = await peapleInMovieService.FindAllPeople();
            foreach (var item in response)
                peopleCollection.Add(item);
        }

        public void LoadPeopleForCurrentMovie(ObservableCollection<People> peopleCollection, Movie currentMovie, ObservableCollection<People> currentPeopleCollection)
        {
            foreach(var item in peopleCollection)
            {
                var person = item;
                var personMovie = person.films[0].Split("/");

                if (currentMovie is null) return;

                else if(currentMovie.id == personMovie[personMovie.Length - 1])
                {
                    currentPeopleCollection.Add(person);
                }
            }
        }
    }
}
