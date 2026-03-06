using AutoserviceMI.Data;
using AutoserviceMI.Detalii;
using System.Linq;
using System.Windows;

namespace AutoserviceMI
{
    public partial class Adaugare_Piesa_Reparatie : Window
    {
        private readonly ProductDbContext _context;
        private readonly Reparatie _reparatie;

        public Adaugare_Piesa_Reparatie(ProductDbContext context, Reparatie reparatie)
        {
            InitializeComponent();
            _context = context;
            _reparatie = reparatie;

            ComboPiesa.ItemsSource = _context.Produse.ToList();
            ComboPiesa.DisplayMemberPath = "Denumire";
            ComboPiesa.SelectedValuePath = "Id";
        }

        private void AdaugarePiesa_Click(object sender, RoutedEventArgs e)
        {
            var produs = ComboPiesa.SelectedItem as Produs;
            if (produs == null)
            {
                MessageBox.Show("Selectați piesa!");
                return;
            }

            if (!int.TryParse(CantitateText.Text, out int cantitate) || cantitate <= 0)
            {
                MessageBox.Show("Cantitatea trebuie să fie un număr valid!");
                return;
            }

            if (!decimal.TryParse(PretText.Text, out decimal pret) || pret <= 0)
            {
                MessageBox.Show("Prețul trebuie să fie valid!");
                return;
            }

            var rp = new ReparatiePiesa
            {
                ReparatieId = _reparatie.Id,
                ProdusId = produs.Id,
                Cantitate = cantitate,
                PretUnitate = pret
            };

            _context.ReparatiePiese.Add(rp);
            _context.SaveChanges();

            MessageBox.Show("Piesa a fost adăugată cu succes!");
            Close();
        }
    }
}
