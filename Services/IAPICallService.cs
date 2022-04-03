using MicaMatherialGhibli.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicaMatherialGhibli.Services
{
    public interface IAPICallService
    {

        void LoadAllMovies(ObservableCollection<Movie> moviesCollection);
        Task LoadAllPeople(ObservableCollection<People> peopleCollection);
        void LoadPeopleForCurrentMovie(ObservableCollection<People> peopleCollection, Movie currentMovie, ObservableCollection<People> currentPeopleCollection);
        
    }
}
