using AutoserviceMI.Data;
using AutoserviceMI.Detalii;
using System.Linq;
using System.Windows;

namespace AutoserviceMI
{
    public partial class Modificare_Depozit : Window
    {
        private readonly ProductDbContext _context;
        private readonly Produs _produs;

        public Modificare_Depozit(ProductDbContext context, Produs produs)
        {
            InitializeComponent();
            _context = context;
            _produs = produs;

            TxtCodProdus.Text = produs.CodProdus;
            TxtDenumire.Text = produs.Denumire;
            TxtProducator.Text = produs.Producator;
            TxtPret.Text = produs.Pret.ToString();
            TxtStoc.Text = produs.Stoc.ToString();
            TxtStocMin.Text = produs.StocMinim.ToString();
        }

        private void Salveaza_Click(object sender, RoutedEventArgs e)
        {
            string cod = TxtCodProdus.Text.Trim();
            string denumire = TxtDenumire.Text.Trim();
            string producator = TxtProducator.Text.Trim();
            string pretText = TxtPret.Text.Trim();
            string stocText = TxtStoc.Text.Trim();
            string stocMinText = TxtStocMin.Text.Trim();

            if (string.IsNullOrWhiteSpace(cod) ||
                string.IsNullOrWhiteSpace(denumire) ||
                string.IsNullOrWhiteSpace(producator) ||
                string.IsNullOrWhiteSpace(pretText) ||
                string.IsNullOrWhiteSpace(stocText) ||
                string.IsNullOrWhiteSpace(stocMinText))
            {
                MessageBox.Show("Completați toate câmpurile!");
                return;
            }

            if (denumire.Any(char.IsDigit) || !char.IsUpper(denumire.First()) || denumire.Length > 40)
            {
                MessageBox.Show("Denumirea trebuie să înceapă cu literă mare, să nu conțină cifre și să fie maxim 40 caractere.");
                return;
            }

            if (producator.Any(char.IsDigit) || !char.IsUpper(producator.First()) || producator.Length > 30)
            {
                MessageBox.Show("Producătorul trebuie să înceapă cu literă mare, să nu conțină cifre și să fie maxim 30 caractere.");
                return;
            }

            if (!decimal.TryParse(pretText, out decimal pret) || pret <= 0)
            {
                MessageBox.Show("Prețul trebuie să fie un număr valid și pozitiv.");
                return;
            }

            if (!int.TryParse(stocText, out int stoc) || stoc < 0)
            {
                MessageBox.Show("Stocul trebuie să fie un număr întreg pozitiv.");
                return;
            }

            if (!int.TryParse(stocMinText, out int stocMin) || stocMin < 0)
            {
                MessageBox.Show("Stocul minim trebuie să fie un număr întreg pozitiv.");
                return;
            }

            _produs.CodProdus = cod;
            _produs.Denumire = denumire;
            _produs.Producator = producator;
            _produs.Pret = pret;
            _produs.Stoc = stoc;
            _produs.StocMinim = stocMin;

            _context.Produse.Update(_produs);
            _context.SaveChanges();

            MessageBox.Show("Produs modificat cu succes!");
            Close();
        }
    }
}
