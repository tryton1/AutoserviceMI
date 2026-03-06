using AutoserviceMI.Data;
using System.Linq;
using System.Windows;

namespace AutoserviceMI
{
    public partial class MainWindow : Window
    {
        private readonly ProductDbContext _context;

        public MainWindow()
        {
            InitializeComponent();
            _context = App.Db;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string user = TxtUser.Text.Trim();
            string pass = TxtPassword.Password.Trim();

            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Completați toate câmpurile!");
                return;
            }

            var utilizator = _context.Users
                .FirstOrDefault(u => u.Username == user && u.Parola == pass);

            if (utilizator == null)
            {
                MessageBox.Show("Utilizator sau parolă incorectă!");
                return;
            }

            MessageBox.Show($"Autentificare reușită, rol: {utilizator.Rol}");

            Dashboard db = new Dashboard();
            db.Show();
            this.Close();
        }
    }
}
