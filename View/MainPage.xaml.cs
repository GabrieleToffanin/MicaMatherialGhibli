using MicaMatherialGhibli.View;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MicaMatherialGhibli
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.navigationFrame.Navigate(typeof(CatalogPage), null, new SlideNavigationTransitionInfo());
            NavigationViewControl.Header = "GhibliStudio";
        }


        private void NavigationViewControl_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            FrameNavigationOptions navigationOptions = new FrameNavigationOptions();
            navigationOptions.TransitionInfoOverride = args.RecommendedNavigationTransitionInfo;
            var selectedItem = sender.SelectedItem as NavigationViewItem;

            if (args.IsSettingsInvoked)
            {
                navigationFrame.Navigate(typeof(SettingsPage), null, new DrillInNavigationTransitionInfo());
                sender.Header = "Settings";
            }
            else if (selectedItem.Tag.ToString().Equals("Catalog"))
            {
                navigationFrame.Navigate(typeof(CatalogPage), null, new DrillInNavigationTransitionInfo());
                sender.Header = (sender.SelectedItem as NavigationViewItem).Content.ToString();
            }

        }

        private void NavigationViewControl_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            TryGoBack();
        }

        private bool TryGoBack()
        {
            if (!navigationFrame.CanGoBack)
                return false;

            if (NavigationViewControl.IsPaneOpen &&
                (NavigationViewControl.DisplayMode == NavigationViewDisplayMode.Compact) ||
                 NavigationViewControl.DisplayMode == NavigationViewDisplayMode.Minimal)
                return false;

            navigationFrame.GoBack();
            return true;
        }


    }
}
