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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telok.models;

namespace Telok
{
    /// <summary>
    /// Interaction logic for listPhones.xaml
    /// </summary>
    public partial class listPhones : Window
    {
        public listPhones()
        {
            InitializeComponent();
            loadTelok();
        }

        private void loadTelok()
        {
            using (var db = new TelefonDbContext())
            {
                telok.ItemsSource = db.telefonok.ToList();
            }
        }

        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var newpage = new MainWindow();
            newpage.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (telok.SelectedItem is Telefon selected)
            {
                using (var db = new TelefonDbContext())
                {
                    db.telefonok.Remove(db.telefonok.Find(selected.Sorszam));
                    db.SaveChanges();
                    loadTelok();
                }
            }
        }
    }
}



using MySql.Data.MySqlClient;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Telok
{
    public partial class listPhones : Window
    {
        private string ConnectionString = "server=localhost;uid=root;database=telefonokdb";
        private MySqlConnection connection;
        private MySqlCommand command;

        public listPhones()
        {
            InitializeComponent();
            connection = new MySqlConnection(ConnectionString);
            LoadPhones();
        }

        private void LoadPhones()
        {
            telok.Items.Clear();
            try
            {
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = "SELECT Sorszam, Nev, Marke FROM telefonok";
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ListBoxItem item = new ListBoxItem
                    {
                        Content = reader.GetString("Nev") + " - " + reader.GetString("Marke"),
                        Tag = reader.GetInt32("Sorszam")
                    };
                    telok.Items.Add(item);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt az adatok betöltésekor: " + ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (telok.SelectedItem is ListBoxItem selectedItem)
            {
                int sorszam = (int)selectedItem.Tag;
                DeletePhone(sorszam);
            }
        }

        private void DeletePhone(int sorszam)
        {
            try
            {
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = "DELETE FROM telefonok WHERE Sorszam = @sorszam";
                command.Parameters.AddWithValue("@sorszam", sorszam);
                command.ExecuteNonQuery();
                connection.Close();
                LoadPhones();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt a törlés során: " + ex.Message);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var newpage = new MainWindow();
            newpage.Show();
        }
    }
}
