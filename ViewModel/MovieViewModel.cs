using MicaMatherialGhibli.Extender;
using MicaMatherialGhibli.Helpers;
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
        public ObservableCollection<Movie> moviesCollection { get; set; } = new ObservableCollection<Movie>();
        public ObservableCollection<People> currentMoviePeople { get; set; } = new ObservableCollection<People>();

        private readonly IMoviesCollectionService _moviesCollectionService;
        private readonly IPeapleInMovieService _peapleInMovieService;
        private readonly ISingleMovieService _singleMovieService;
        private readonly ISettingsService _settingsService;
        public readonly IAsyncRelayCommand initVM;

        public MovieViewModel(ISettingsService settingsService, 
                              ISingleMovieService singleMovieService,
                              IPeapleInMovieService peapleInMovieService,
                              IMoviesCollectionService moviesCollectionService)
        {
            //LoadPeopleAsyncRelayCommand = new AsyncRelayCommand(LoadAllPeople);
            _settingsService = settingsService;
            _singleMovieService = singleMovieService;
            _peapleInMovieService = peapleInMovieService;
            _moviesCollectionService = moviesCollectionService;
            selectedMovie = settingsService.GetValue<Movie>(nameof(SelectedMovie));

            initVM = new AsyncRelayCommand(InitViewModel);
        }

        private Movie selectedMovie;

        public Movie SelectedMovie
        {
            get => selectedMovie;
            set => SetProperty(ref selectedMovie, value);
        }
        
       
        private Task InitViewModel()
        {
            moviesCollection = (ObservableCollection<Movie>)this.LoadAllMoviesAsync(_moviesCollectionService, _singleMovieService);
            currentMoviePeople = (ObservableCollection<People>)this.LoadCurrentMoviePeopleAsync(_peapleInMovieService);
            return null;
        }
        
        

    }
}

