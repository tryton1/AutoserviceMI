using AutoserviceMI.Data;
using AutoserviceMI.Detalii;
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

namespace AutoserviceMI
{
    /// <summary>
    /// Interaction logic for Depozit.xaml
    /// </summary>
    /// 

    public partial class Depozit : Window
    {
        private readonly ProductDbContext _context;

        public Depozit(ProductDbContext context)
        {
            InitializeComponent();
            _context = context;
            Incarca_Piese();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Incarca_Piese()
        {
            DataGridProduse.ItemsSource = _context.Produse.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Adaugare_Depozit a = new Adaugare_Depozit(_context);
            a.ShowDialog();
            Incarca_Piese();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var produs = DataGridProduse.SelectedItem as Produs;
            if (produs == null)
            {
                MessageBox.Show("Selectați un produs!");
                return;
            }

            var form = new Modificare_Depozit(_context, produs);
            form.ShowDialog();
            Incarca_Piese();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var produs = DataGridProduse.SelectedItem as Produs;

            if (produs == null)
            {
                MessageBox.Show("Selectati produs!!!");
                return;
            }

            var confirm = MessageBox.Show(
                $"Sigur doriti sa stergeti produsul {produs.Denumire} ({produs.CodProdus})?",
                "Confirmare ștergere",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (confirm != MessageBoxResult.Yes)
            {
                return;
            }

            _context.Produse.Remove(produs);
            _context.SaveChanges();

            Incarca_Piese();

            MessageBox.Show("Produs sters cu succes!");
        }

        private void Filtrare_Click1(object sender, RoutedEventArgs e)
        {
            var query = _context.Produse.AsQueryable();

            string cod = FilterCod.Text.Trim();
            string denumire = FilterDenumire.Text.Trim();
            string producator = FilterProducator.Text.Trim();
            string pretText = FilterPret.Text.Trim();

            if (!string.IsNullOrWhiteSpace(cod))
                query = query.Where(p => p.CodProdus.Contains(cod));

            if (!string.IsNullOrWhiteSpace(denumire))
                query = query.Where(p => p.Denumire.Contains(denumire));

            if (!string.IsNullOrWhiteSpace(producator))
                query = query.Where(p => p.Producator.Contains(producator));

            if (!string.IsNullOrWhiteSpace(pretText))
            {
                if (decimal.TryParse(pretText, out decimal pretValue))
                    query = query.Where(p => p.Pret == pretValue);
                else
                {
                    MessageBox.Show("Prețul trebuie să fie un număr valid.");
                    return;
                }
            }

            DataGridProduse.ItemsSource = query.ToList();
        }
}

}
