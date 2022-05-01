using MicaMatherialGhibli.Controls;
using MicaMatherialGhibli.Model;
using MicaMatherialGhibli.ViewModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MicaMatherialGhibli.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CatalogPage : Page
    {
        public CatalogPage()
        {
            this.InitializeComponent();
            this.DataContext = Ioc.Default.GetRequiredService<MovieViewModel>();
        }

        public MovieViewModel ViewModel => (MovieViewModel)DataContext;


        private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            var selectedItem = (args.SelectedItem as Movie).title.ToString();
            sender.Text = selectedItem;
        }

        private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                List<Movie> dataSet = ViewModel.moviesCollection.Where(x => x.title.ToUpper().StartsWith(sender.Text.ToUpper())).ToList();

                ItemCollection.ItemsSource = dataSet;
                sender.ItemsSource = dataSet;
            }
        }

        private void ItemCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.Frame.Navigate(typeof(SingleMovieControl), ViewModel, new SuppressNavigationTransitionInfo());
        }
    }
}
