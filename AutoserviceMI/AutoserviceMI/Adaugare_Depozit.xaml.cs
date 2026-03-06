using AutoserviceMI.Data;
using AutoserviceMI.Detalii;
using System;
using System.Linq;
using System.Windows;

namespace AutoserviceMI
{
    public partial class Adaugare_Depozit : Window
    {
        private readonly ProductDbContext _context;

        public Adaugare_Depozit(ProductDbContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void AdaugaProdus_Click(object sender, RoutedEventArgs e)
        {
            string cod = TxtCodProdus.Text.Trim();
            string denumire = TxtDenumire.Text.Trim();
            string producator = TxtProducator.Text.Trim();
            string pretText = TxtPret.Text.Trim();
            string stocText = TxtStoc.Text.Trim();
            string stocMinimText = TxtStocMin.Text.Trim();

            if (string.IsNullOrWhiteSpace(cod) ||
                string.IsNullOrWhiteSpace(denumire) ||
                string.IsNullOrWhiteSpace(producator) ||
                string.IsNullOrWhiteSpace(pretText) ||
                string.IsNullOrWhiteSpace(stocText) ||
                string.IsNullOrWhiteSpace(stocMinimText))
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

            if (!int.TryParse(stocMinimText, out int stocMinim) || stocMinim < 0)
            {
                MessageBox.Show("Stocul minim trebuie să fie un număr întreg pozitiv.");
                return;
            }

            var produs = new Produs
            {
                CodProdus = cod,
                Denumire = denumire,
                Producator = producator,
                Pret = pret,
                Stoc = stoc,
                StocMinim = stocMinim
            };

            _context.Produse.Add(produs);
            _context.SaveChanges();

            MessageBox.Show("Piesa a fost adăugată cu succes!");
            this.Close();
        }

        private void Inchide_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
