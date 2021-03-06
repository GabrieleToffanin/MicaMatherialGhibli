using MicaMatherialGhibli.Model;
using MicaMatherialGhibli.ViewModel;
using Windows.UI.Xaml.Controls;
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

        }

        public MovieViewModel ViewModel => (DataContext as MovieViewModel);
        public Movie movieData { get; set; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.DataContext = (MovieViewModel)e.Parameter;
            movieData = ViewModel.SelectedMovie;
        }




    }
}
