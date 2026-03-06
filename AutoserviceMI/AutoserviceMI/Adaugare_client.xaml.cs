using SQLitePCL;
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
using AutoserviceMI.Detalii;

namespace AutoserviceMI.Data
{
    /// <summary>
    /// Interaction logic for Adaugare_client.xaml
    /// </summary>
    public partial class Adaugare_client : Window
    {
        ProductDbContext _context;
        public Adaugare_client(ProductDbContext context)
        {
            InitializeComponent();
            _context = context;
        }
        private void AdaugaClient_Click(object sender, RoutedEventArgs e)
        {
            string nume = NumeTextBox.Text.Trim();
            string prenume = PrenumeTextBox.Text.Trim();
            string telefon = TelefonTextBox.Text.Trim();
            string oras = OrasTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(nume) ||
                string.IsNullOrWhiteSpace(prenume))
            {
                MessageBox.Show("Completați numele și prenumele!");
                return;
            }

            if (!char.IsUpper(nume.First()) || nume.Length > 30 || nume.Any(char.IsDigit))
            {
                MessageBox.Show("Numele trebuie să înceapă cu literă mare, să nu conțină cifre și să fie max 30 caractere.");
                return;
            }

            if (!char.IsUpper(prenume.First()) || prenume.Length > 30 || prenume.Any(char.IsDigit))
            {
                MessageBox.Show("Prenumele trebuie să înceapă cu literă mare, să nu conțină cifre și să fie max 30 caractere.");
                return;
            }

            if (!telefon.StartsWith("+373") || telefon.Length > 12)
            {
                MessageBox.Show("Numărul de telefon trebuie să înceapă cu +373 și să fie max 12 caractere.");
                return;
            }

            if (!char.IsUpper(oras.First()) || oras.Length > 12 || oras.Any(char.IsDigit))
            {
                MessageBox.Show("Orașul trebuie să înceapă cu literă mare, să nu conțină cifre și să fie max 12 caractere.");
                return;
            }

            var client = new Client
            {
                Nume = nume,
                Prenume = prenume,
                Telefon = telefon,
                Oras = oras
            };

            _context.Clienti.Add(client);
            _context.SaveChanges();

            MessageBox.Show("Client adăugat cu succes!");
            this.Close();
        }

    }
}
