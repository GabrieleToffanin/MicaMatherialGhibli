using MicaMatherialGhibli.Model;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MicaMatherialGhibli.Controls
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PeopleContentVIew : Page
    {
        public PeopleContentVIew()
        {
            this.InitializeComponent();
        }

        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(
            "ItemsToPass",
            typeof(IEnumerable<People>),
            typeof(FlipView),
            new PropertyMetadata(null)
            );



        public IEnumerable<People> ItemsToPass
        {
            get { return (IEnumerable<People>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }
    }
}
