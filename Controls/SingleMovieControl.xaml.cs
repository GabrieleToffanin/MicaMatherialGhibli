using MicaMatherialGhibli.Model;
using MicaMatherialGhibli.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MicaMatherialGhibli.Controls
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SingleMovieControl : Page
    {
        public SingleMovieControl()
        {
            this.InitializeComponent();
            this.DataContext = Ioc.Default.GetRequiredService<PeopleViewModel>();
            
        }

        public PeopleViewModel ViewModel => (DataContext as PeopleViewModel);
        public ObservableCollection<People> currentMoviePeople { get; set; } = new ObservableCollection<People>();
        public Movie movieData { get; set; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            movieData = (Movie)e.Parameter;
            LoadPeopleForCurrentMovie();
        }
            
        private void LoadPeopleForCurrentMovie()
        {
            foreach(var item in ViewModel.peopleCollection)
            {
                var person = item as People;
                var personMovie = person.films[0].Split('/');

                if(movieData.id == personMovie[ personMovie.Length - 1])
                {
                    currentMoviePeople.Add(person);
                }
            }
        }

        
    }
}
