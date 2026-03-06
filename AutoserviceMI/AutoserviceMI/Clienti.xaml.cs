using AutoserviceMI.Data;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace AutoserviceMI
{
    /// <summary>
    /// Interaction logic for Clienti.xaml
    /// </summary>
    public partial class Clienti : Window
    {
        private readonly ProductDbContext _context;
        public Clienti(ProductDbContext context)
        {
            InitializeComponent();
            _context = context;
            IncarcaClienti();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void Sortare_click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Stergere_Button_Click(object sender, RoutedEventArgs e)
        {

            var client = ClientiDataGrid.SelectedItem as Client;

            if (client == null)
            {
                MessageBox.Show("Selectati client!!!");
                return;
            }

            var confirm = MessageBox.Show($"Sigur doriti sa stergeti clientul {client.Nume} {client.Prenume}", "Confirmare ștergere", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (confirm != MessageBoxResult.Yes) { return; }

            _context.Clienti.Remove(client);
            _context.SaveChanges();

            IncarcaClienti();

            MessageBox.Show("Client sters cu succes!");

        }
        private void IncarcaClienti()
        {
            ClientiDataGrid.ItemsSource = _context.Clienti.ToList();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var addForm = new Adaugare_client(_context);
            addForm.ShowDialog();
            IncarcaClienti();
        }

        private void Modificare_Click(object sender, RoutedEventArgs e)
        {
            var client = ClientiDataGrid.SelectedItem as Client;
            if(client == null) { MessageBox.Show("Nu ati selectat client de modificat! Eroare!"); return; }
            var changeForm = new Modificare_client(_context, client);
            changeForm.ShowDialog();
            IncarcaClienti();
        }

        private void Filtrare_Click(object sender, RoutedEventArgs e)
        {
            string nume = NumeFilterTextBox.Text.Trim();
            string prenume = PrenumeFilterTextBox.Text.Trim();
            string telefon = TelefonFilterTextBox.Text.Trim();
            string oras = OrasFilterTextBox.Text.Trim();

            var query = _context.Clienti.AsQueryable();

            if (!string.IsNullOrWhiteSpace(nume))
                query = query.Where(c => c.Nume.Contains(nume));

            if (!string.IsNullOrWhiteSpace(prenume))
                query = query.Where(c => c.Prenume.Contains(prenume));

            if (!string.IsNullOrWhiteSpace(telefon))
                query = query.Where(c => c.Telefon.Contains(telefon));

            if (!string.IsNullOrWhiteSpace(oras))
                query = query.Where(c => c.Oras.Contains(oras));

            ClientiDataGrid.ItemsSource = query.ToList();
        }


        private void ClientiDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
