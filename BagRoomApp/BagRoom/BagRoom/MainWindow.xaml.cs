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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string stringInput = target.Text;
            int numberInput = 0;

            //Is input a number????
            if (int.TryParse(stringInput, out numberInput))
            {
                var query =
                    from player in dataEntities.players
                    where player.bag_id == numberInput
                    orderby player.id
                    select new { player.id, player.first_name, player.last_name, player.bag_id };

                bagRoomGrid.ItemsSource = query.ToList();
            }
            else 
            {
                    var query =
                        from player in dataEntities.players
                        where player.last_name == stringInput
                        select new { player.id, player.first_name, player.last_name, player.bag_id };

                    bagRoomGrid.ItemsSource = query.ToList();
            }
        }
        

        //prints table to main window
        private void showTable(object sender, RoutedEventArgs e)
        {
            var query =
               from player in dataEntities.players
               select new { player.id, player.first_name, player.last_name, player.bag_id };
               bagRoomGrid.ItemsSource = query.ToList();
        }

        private void addPlayer(object sender, RoutedEventArgs e)
        {
            AddPlayer addPlayerWindow = new AddPlayer();
            addPlayerWindow.Show();
        }
    }
}
