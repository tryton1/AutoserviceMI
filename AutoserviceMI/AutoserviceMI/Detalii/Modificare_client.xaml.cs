using AutoserviceMI.Data;
using Microsoft.Extensions.DependencyModel;
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

namespace AutoserviceMI.Detalii
{
    /// <summary>
    /// Interaction logic for Modificare_client.xaml
    /// </summary>
    public partial class Modificare_client : Window
    {
        private ProductDbContext _context;
        private Client _client;
        public Modificare_client(ProductDbContext context, Client clientSelectat)
        {
            InitializeComponent();
            _context = context;
            _client = clientSelectat;

            NumeTextBox.Text = _client.Nume;
            PrenumeTextBox.Text = _client.Prenume;
            TelefonTextBox.Text = _client.Telefon;
            OrasTextBox.Text = _client.Oras;
        }
        private void SalvareModificari_Click(object sender, RoutedEventArgs e)
        {
            _client.Nume = NumeTextBox.Text;
            _client.Prenume = PrenumeTextBox.Text;
            _client.Telefon = TelefonTextBox.Text;
            _client.Oras = OrasTextBox.Text;

            _context.SaveChanges();

            MessageBox.Show("Modificarile au fost salvate cu succes!");
            this.Close();
        }

    }
}
