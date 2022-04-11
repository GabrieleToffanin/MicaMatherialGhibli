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

        private readonly IMoviesCollectionService _moviesCollectionService;
        private readonly IPeapleInMovieService _peapleInMovieService;
        private readonly ISingleMovieService _singleMovieService;
        private readonly ISettingsService _settingsService;
        public readonly IAsyncRelayCommand LoadMoviesAsyncRelayCommand;
        public readonly IAsyncRelayCommand LoadPeopleForCurrentMovieAsyncRelayCommand;

        public MovieViewModel(ISettingsService settingsService,
                              ISingleMovieService singleMovieService,
                              IPeapleInMovieService peapleInMovieService,
                              IMoviesCollectionService moviesCollectionService)
        {
            LoadMoviesAsyncRelayCommand = new AsyncRelayCommand(InitMoviesCollection);
            LoadPeopleForCurrentMovieAsyncRelayCommand = new AsyncRelayCommand(InitCurrentPeopleForMovieCollection);
            _settingsService = settingsService;
            _singleMovieService = singleMovieService;
            _peapleInMovieService = peapleInMovieService;
            _moviesCollectionService = moviesCollectionService;
            selectedMovie = settingsService.GetValue<Movie>(nameof(SelectedMovie));


           
        }

        private Movie selectedMovie;

        public Movie SelectedMovie
        {
            get => selectedMovie;
            set => SetProperty(ref selectedMovie, value);
        }


        public async Task InitMoviesCollection() => 
            await this.LoadAllMoviesAsync(_moviesCollectionService, _singleMovieService);
        

        public async Task InitCurrentPeopleForMovieCollection() => 
            await this.LoadCurrentMoviePeopleAsync(_peapleInMovieService);
        



    }
}

