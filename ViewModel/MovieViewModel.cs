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

        
        private readonly ISettingsService settingsService;
        private readonly IAPICallService apiCallService;
        public IAsyncRelayCommand LoadPeopleAsyncRelayCommand { get; }

        public MovieViewModel(ISettingsService settingsService, IAPICallService apiCallService)
        {
            //LoadPeopleAsyncRelayCommand = new AsyncRelayCommand(LoadAllPeople);
            this.settingsService = settingsService;
            LoadPeopleAsyncRelayCommand = new AsyncRelayCommand(LoadPeopleForCurrentMovie);
            this.apiCallService = apiCallService;
            apiCallService.LoadAllMovies(moviesCollection: moviesCollection);
            apiCallService.LoadAllPeople(peopleCollection: peopleCollection);
            selectedMovie = settingsService.GetValue<Movie>(nameof(SelectedMovie));

        }

        private Movie selectedMovie;

        public Movie SelectedMovie
        {
            get => selectedMovie;
            set => SetProperty(ref selectedMovie, value);
        }

        private Task LoadPeopleForCurrentMovie()
        {
            apiCallService.LoadPeopleForCurrentMovie(peopleCollection, SelectedMovie, currentMoviePeople);
            return null;
        }
        
        



    }
}

