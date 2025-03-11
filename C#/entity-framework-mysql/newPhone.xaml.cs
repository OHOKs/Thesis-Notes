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
    /// Interaction logic for newPhone.xaml
    /// </summary>
    public partial class newPhone : Window
    {
        public newPhone()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var newpage = new MainWindow();
            newpage.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new TelefonDbContext())
                {
                    var telefon = new Telefon
                    {
                        Marka = txtMarka.Text,
                        Modell = txtModell.Text,
                        GyartasiEv = int.Parse(txtGyEv.Text),
                        Szin = txtSzin.Text,
                        EladottDarab = int.Parse(txtEladott.Text),
                        AtlagAr = decimal.Parse(txtAtlagAr.Text),
                    };

                    db.telefonok.Add(telefon);
                    db.SaveChanges();
                    MessageBox.Show("Telo hozzaadva");
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
