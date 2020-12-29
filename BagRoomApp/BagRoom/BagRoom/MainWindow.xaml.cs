using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Windows;

namespace BagRoom
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bagRoomEntities dataEntities = new bagRoomEntities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loadedobject sender, RoutedEventArgs e)
        {
            var query =
            from player in dataEntities.players
            select new { player.id, player.first_name, player.last_name, player.bag_id };

            bagRoomGrid.ItemsSource = query.ToList();
        }
    }
}
