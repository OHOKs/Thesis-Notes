using System.Text;
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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using (var db = new TelefonDbContext())
            {
                db.Database.EnsureCreated();
            }
        }

        private void add(object sender, RoutedEventArgs e)
        {
            var newpage = new newPhone();
            newpage.Show();
            this.Close();
        }
        private void list(object sender, RoutedEventArgs e)
        {
            var newpage = new listPhones();
            newpage.Show();
            this.Close();
        }
    }
}