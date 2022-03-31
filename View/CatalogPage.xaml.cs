using MicaMatherialGhibli.Model;
using MicaMatherialGhibli.ViewModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System;
using System.Collections.Generic;
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
using Windows.UI.Xaml.Media.Animation;
using MicaMatherialGhibli.Controls;
using Windows.UI.Xaml.Navigation;

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

        public MovieViewModel ViewModel => Ioc.Default.GetRequiredService<MovieViewModel>();

        private void ItemCollection_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(SingleMovieControl), e.ClickedItem as Movie, new SuppressNavigationTransitionInfo());
        }
    }
}
