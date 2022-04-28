using MicaMatherialGhibli.Extender;
using MicaMatherialGhibli.Model;
using MicaMatherialGhibli.Services;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MicaMatherialGhibli.ViewModel
{
    public class MovieViewModel : ObservableRecipient
    {
        public ObservableCollection<Movie> moviesCollection { get; set; } = new ObservableCollection<Movie>();
        public ObservableCollection<People> currentMoviePeople { get; set; } = new ObservableCollection<People>();

        
        private readonly ISettingsService _settingsService;
        private readonly IApiServices _apiServices;
        public readonly IAsyncRelayCommand LoadMoviesAsyncRelayCommand;
        public readonly IAsyncRelayCommand LoadPeopleForCurrentMovieAsyncRelayCommand;

        public MovieViewModel(ISettingsService settingsService,
                              IApiServices apiServices)
        {
            LoadMoviesAsyncRelayCommand = new AsyncRelayCommand(InitMoviesCollection);
            LoadPeopleForCurrentMovieAsyncRelayCommand = new AsyncRelayCommand(InitCurrentPeopleForMovieCollection);
            _settingsService = settingsService;
            _apiServices = apiServices;
            selectedMovie = settingsService.GetValue<Movie>(nameof(SelectedMovie));

        }

        private Movie selectedMovie;

        public Movie SelectedMovie
        {
            get => selectedMovie;
            set => SetProperty(ref selectedMovie, value);
        }


        public async Task InitMoviesCollection()
        { 
            foreach(var item in await _apiServices.LoadAllMoviesAsync())
                moviesCollection.Add(item);
        }


        public async Task InitCurrentPeopleForMovieCollection()
        {
            foreach(var item in await _apiServices.LoadCurrentMoviePeopleAsync(this.SelectedMovie)) 
                currentMoviePeople.Add(item);
        }
    }
}

