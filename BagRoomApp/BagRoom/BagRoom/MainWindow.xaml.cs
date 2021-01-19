using System;
using System.Data;
using System.Data.SqlClient;
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

        DataTable dt = new DataTable();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-4TJATUJ\\SQLEXPRESS;Initial Catalog=bagRoom;Integrated Security=True"))
            {
                try
                {
                    conn.Open();

                    string stringInput = target.Text;
                    int numberInput = 0;

                    //Is input a number????
                    if (int.TryParse(stringInput, out numberInput))
                    {


                        SqlCommand cmd = new SqlCommand("SELECT * from players WHERE bag_id = @bagID", conn);
                        cmd.Parameters.AddWithValue("@bagID", stringInput);
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        sda.Fill(dt);

                        bagRoomGrid.ItemsSource = dt.DefaultView;
                        bagRoomGrid.AutoGenerateColumns = true;
                        bagRoomGrid.CanUserAddRows = false;
                        conn.Close();
                    }

                    else
                    {
                        SqlCommand cmd = new SqlCommand("SELECT * from players WHERE last_name = @lastname", conn);
                        cmd.Parameters.AddWithValue("@lastname", stringInput);
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        sda.Fill(dt);

                        bagRoomGrid.ItemsSource = dt.DefaultView;
                        bagRoomGrid.AutoGenerateColumns = true;
                        bagRoomGrid.CanUserAddRows = false;
                    }
                }
                catch (Exception b)
                {
                    Console.WriteLine(b.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }


        //prints table to main window
        private void showTable(object sender, RoutedEventArgs e)
        {

            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-4TJATUJ\\SQLEXPRESS;Initial Catalog=bagRoom;Integrated Security=True"))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * from players", conn);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);

                    bagRoomGrid.ItemsSource = dt.DefaultView;
                    bagRoomGrid.AutoGenerateColumns = true;
                    bagRoomGrid.CanUserAddRows = false;
                }
                catch (Exception b)
                {
                    Console.WriteLine(b.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void addPlayer(object sender, RoutedEventArgs e)
        {
            AddPlayer addPlayerWindow = new AddPlayer();
            addPlayerWindow.Show();
        }

        private void DeleteRow(object sender, RoutedEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-4TJATUJ\\SQLEXPRESS;Initial Catalog=bagRoom;Integrated Security=True"))
            {
                DataRowView row = (DataRowView)bagRoomGrid.SelectedItem;
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE players WHERE Id = " + row["Id"], conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception b)
                {
                    Console.WriteLine(b.Message);
                }
                finally
                {
                    conn.Close();
                }
                row.Delete();
            }
        }
    }
}
