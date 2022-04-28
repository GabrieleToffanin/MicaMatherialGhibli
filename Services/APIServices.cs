using MicaMatherialGhibli.Helpers;
using MicaMatherialGhibli.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicaMatherialGhibli.Services
{
    public sealed class APIServices : IApiServices
    {
        private readonly IMoviesCollectionService _moviesCollectionService;
        private readonly ISingleMovieService _singleMovieService;
        private readonly IPeapleInMovieService _peopleInMovieService;
        private List<Task<Movie>> movies = new List<Task<Movie>>();
        private List<People> people = new List<People>();
        
        public APIServices(IMoviesCollectionService moviesCollectionService,
                           ISingleMovieService singleMovieService,
                           IPeapleInMovieService peopleInMovieService)
        {
            _moviesCollectionService = moviesCollectionService;
            _singleMovieService = singleMovieService;
            _peopleInMovieService = peopleInMovieService;
        }
        public async Task<IEnumerable<Movie>> LoadAllMoviesAsync()
        {
            var current = await _moviesCollectionService.getAllMoviesID().ConfigureAwait(false);

            var ids = current.Select(x => x.id);

            foreach(var id in ids)
                movies.Add(Task.Run( () => _singleMovieService.LoadMoviesAsync(id)));

            return await Task.WhenAll(movies);
        }

        public async Task<IEnumerable<People>> LoadCurrentMoviePeopleAsync(Movie movie)
        {
            
            var result = await _peopleInMovieService.FindAllPeople();

            foreach(var item in result)
            {
                var currentID = item.films[0].Split("/");
                if (movie.id.Equals(currentID[currentID.Length - 1]))
                {
                    people.Add(item);
                }
                    
            }

            return people;
        }
    }
}
