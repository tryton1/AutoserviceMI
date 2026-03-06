using AutoserviceMI.Data;
using AutoserviceMI.Detalii;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows;

namespace AutoserviceMI
{
    public partial class Vehicule : Window
    {
        private readonly ProductDbContext _context;

        public Vehicule(ProductDbContext context)
        {
            InitializeComponent();
            _context = context;
            IncarcaVehicule();
        }

        private void IncarcaVehicule()
        {
            DataGridVehicule.ItemsSource =
                _context.Vehicule
                .Include(v => v.Client)
                .ToList();
        }

        private void Filtrare_Click(object sender, RoutedEventArgs e)
        {
            var query = _context.Vehicule.Include(v => v.Client).AsQueryable();

            if (!string.IsNullOrWhiteSpace(FilterNr.Text))
                query = query.Where(v => v.NumarInmatriculare.Contains(FilterNr.Text));

            if (!string.IsNullOrWhiteSpace(FilterMarca.Text))
                query = query.Where(v => v.Marca.Contains(FilterMarca.Text));

            if (!string.IsNullOrWhiteSpace(FilterModel.Text))
                query = query.Where(v => v.Model.Contains(FilterModel.Text));

            if (!string.IsNullOrWhiteSpace(FilterVIN.Text))
                query = query.Where(v => v.VIN.Contains(FilterVIN.Text));

            DataGridVehicule.ItemsSource = query.ToList();
        }

        private void Adaugare_Click(object sender, RoutedEventArgs e)
        {
            var form = new Adaugare_Vehicul(_context);
            form.ShowDialog();
            IncarcaVehicule();
        }

        private void Modificare_Click(object sender, RoutedEventArgs e)
        {
            var vehicul = DataGridVehicule.SelectedItem as Vehicul;

            if (vehicul == null)
            {
                MessageBox.Show("Selectați un vehicul!");
                return;
            }

            var form = new Modificare_Vehicul(_context, vehicul);
            form.ShowDialog();
            IncarcaVehicule();
        }

        private void Stergere_Click(object sender, RoutedEventArgs e)
        {
            var vehicul = DataGridVehicule.SelectedItem as Vehicul;

            if (vehicul == null)
            {
                MessageBox.Show("Selectați un vehicul!");
                return;
            }

            var confirm = MessageBox.Show(
                $"Sigur doriți să ștergeți vehiculul {vehicul.NumarInmatriculare} ({vehicul.Marca} {vehicul.Model})?",
                "Confirmare ștergere",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (confirm != MessageBoxResult.Yes)
                return;

            _context.Vehicule.Remove(vehicul);
            _context.SaveChanges();
            IncarcaVehicule();

            MessageBox.Show("Vehicul șters cu succes!");
        }
    }
}
