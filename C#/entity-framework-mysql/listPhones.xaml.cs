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
