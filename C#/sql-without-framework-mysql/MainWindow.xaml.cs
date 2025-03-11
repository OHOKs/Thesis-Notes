using MySql.Data.MySqlClient;
using System;
using System.Windows;
using System.Windows.Controls;

namespace GepjarmuvekGUI
{
    public partial class MainWindow : Window
    {
        public string ConnectionString = "server=localhost;uid=root;database=gepjarmuvek2";
        public MySqlConnection connection;
        public MySqlCommand command;

        public MainWindow()
        {
            InitializeComponent();
            connection = new MySqlConnection(ConnectionString);
            LoadList();
        }

        private void LoadList()
        {
            Hirdetok.Items.Clear();
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT id, nev FROM elado";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListBoxItem item = new ListBoxItem
                {
                    Content = reader.GetString("nev"),
                    Tag = reader.GetInt32("id")
                };
                Hirdetok.Items.Add(item);
            }
            connection.Close();
        }

        private void InsertElado(string nev, string telefon)
        {
            try
            {
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = "INSERT INTO elado (nev, telefon) VALUES (@nev, @telefon)";
                command.Parameters.AddWithValue("@nev", nev);
                command.Parameters.AddWithValue("@telefon", telefon);
                command.ExecuteNonQuery();
                connection.Close();
                LoadList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt: " + ex.Message);
            }
        }

        private void UpdateElado(int id, string nev, string telefon)
        {
            try
            {
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = "UPDATE elado SET nev = @nev, telefon = @telefon WHERE id = @id";
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@nev", nev);
                command.Parameters.AddWithValue("@telefon", telefon);
                command.ExecuteNonQuery();
                connection.Close();
                LoadList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt: " + ex.Message);
            }
        }

        private void DeleteElado(int id)
        {
            try
            {
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = "DELETE FROM elado WHERE id = @id";
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
                connection.Close();
                LoadList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt: " + ex.Message);
            }
        }
    }
}
