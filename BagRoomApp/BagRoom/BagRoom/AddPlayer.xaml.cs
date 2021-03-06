﻿using System.Windows;
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

            using (SqlConnection conn = new SqlConnection("ConnectionString"))
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
    

