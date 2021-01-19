using System.Windows;
using System.Data.SqlClient;
using System;

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

            /*SqlCommand cmd = new SqlCommand("INSERT INTO players(first_name, last_name, bag_id) " +
                                            "VALUES('"+ firstName +"', '"+ lastName +"', '"+ bagNumber +"')", conn);*/
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-4TJATUJ\\SQLEXPRESS;Initial Catalog=bagRoom;Integrated Security=True"))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO players(first_name, last_name, bag_id)" +
                                                       "VALUES (@firstName, @lastName, @bagID)", conn))
                    {

                        cmd.Parameters.AddWithValue("@firstName", firstName);
                        cmd.Parameters.AddWithValue("@lastName", lastName);
                        cmd.Parameters.AddWithValue("@bagID", bagNumber);



                        cmd.ExecuteNonQuery();
                        this.Close();
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
    }

}
    

