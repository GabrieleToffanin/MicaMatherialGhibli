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
    public class PeopleViewModel : ObservableRecipient
    {
        private readonly IPeapleInMovieService allPeaple = Ioc.Default.GetRequiredService<IPeapleInMovieService>();
        public ObservableCollection<People> peopleCollection { get; set; } = new ObservableCollection<People>();
        public IAsyncRelayCommand LoadPeopleAsyncRelayCommand { get; }
        public PeopleViewModel()
        {

            LoadPeopleAsyncRelayCommand = new AsyncRelayCommand(LoadAllPeople);
        }

        public async Task LoadAllPeople()
        {
            var response = await allPeaple.FindAllPeople();
            foreach (var item in response)
                peopleCollection.Add(item);
        }

        
    }
}
