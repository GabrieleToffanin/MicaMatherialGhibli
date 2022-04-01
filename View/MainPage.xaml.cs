using MicaMatherialGhibli.View;
using MicaMatherialGhibli.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
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
        }
        

        private void NavigationViewControl_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            FrameNavigationOptions navigationOptions = new FrameNavigationOptions();
            navigationOptions.TransitionInfoOverride = args.RecommendedNavigationTransitionInfo;

            var selectedItem = sender.SelectedItem as NavigationViewItem;

            if (selectedItem.Tag.ToString() == "CatalogPage")
                navigationFrame.Navigate(typeof(CatalogPage), null, new DrillInNavigationTransitionInfo());

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
