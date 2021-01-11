using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Diagnostics;

namespace BagRoom
{
    /// <summary>
    /// Interaction logic for AddPlayer.xaml
    /// </summary>
    public partial class AddPlayer : Window
    {
        public AddPlayer()
        {
            InitializeComponent();
        }

        private void insertPlayer(object sender, RoutedEventArgs e)
        {
            string firstName = fName.Text;
            string lastName = lName.Text;
            int bagNumber;
            int.TryParse(bagNum.Text, out bagNumber);

            player newPlayer = new player();

            newPlayer.first_name = firstName;
            newPlayer.last_name = lastName;
            newPlayer.bag_id = bagNumber;

            
                
        }
    }
}
