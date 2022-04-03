using MicaMatherialGhibli.Model;
using MicaMatherialGhibli.Services;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicaMatherialGhibli.ViewModel
{
    public class MovieViewModel : ObservableRecipient
    {
        public ObservableCollection<Movie> moviesCollection = new ObservableCollection<Movie>();
        private ObservableCollection<People> peopleCollection { get; set; } = new ObservableCollection<People>();
        public ObservableCollection<People> currentMoviePeople { get; set; } = new ObservableCollection<People>();

        private readonly IMoviesCollectionService singleIdService = Ioc.Default.GetRequiredService<IMoviesCollectionService>();
        private readonly ISingleMovieService allMoviesService = Ioc.Default.GetRequiredService<ISingleMovieService>();
        private readonly ISettingsService settingsService;
        private readonly IPeapleInMovieService allPeaple = Ioc.Default.GetRequiredService<IPeapleInMovieService>();

        public IAsyncRelayCommand LoadPeopleAsyncRelayCommand { get; }

        public MovieViewModel(ISettingsService settingsService)
        {
            LoadPeopleAsyncRelayCommand = new AsyncRelayCommand(LoadAllPeople);
            LoadAllMovies();
            this.settingsService = settingsService;
            selectedMovie = settingsService.GetValue<Movie>(nameof(SelectedMovie));
        }

        private Movie selectedMovie;

        public Movie SelectedMovie
        {
            get => selectedMovie;
            set => SetProperty(ref selectedMovie, value);
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


        public async Task LoadAllPeople()
        {
            var response = await allPeaple.FindAllPeople();
            foreach (var item in response)
                peopleCollection.Add(item);

            LoadPeopleForCurrentMovie();
        }

        private void LoadPeopleForCurrentMovie()
        {
            foreach (var item in peopleCollection)
            {
                var person = item as People;
                var personMovie = person.films[0].Split('/');

                if (SelectedMovie is null) return;

                else if (SelectedMovie.id == personMovie[personMovie.Length - 1])
                {
                    currentMoviePeople.Add(person);
                }

            }
        }



    }
}

