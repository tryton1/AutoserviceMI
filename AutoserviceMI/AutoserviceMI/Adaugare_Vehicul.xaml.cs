using AutoserviceMI.Data;
using AutoserviceMI.Detalii;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace AutoserviceMI
{
    public partial class Adaugare_Vehicul : Window
    {
        private readonly ProductDbContext _context;

        public Adaugare_Vehicul(ProductDbContext context)
        {
            InitializeComponent();
            _context = context;
            IncarcaClienti();
        }

        private void IncarcaClienti()
        {
            ClientCombo.ItemsSource = _context.Clienti.ToList();
            ClientCombo.DisplayMemberPath = "Nume";
            ClientCombo.SelectedValuePath = "Id";
        }

        private bool Validari()
        {
            string nr = NrTextBox.Text.Trim();
            string marca = MarcaTextBox.Text.Trim();
            string model = ModelTextBox.Text.Trim();
            string vin = VINTextBox.Text.Trim();

            if (nr.Length < 5)
            {
                MessageBox.Show("Număr înmatriculare invalid.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(marca) || marca.Length > 20)
            {
                MessageBox.Show("Marca nu este validă.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(model) || model.Length > 20)
            {
                MessageBox.Show("Modelul nu este valid.");
                return false;
            }

            if (!Regex.IsMatch(vin, @"^[A-HJ-NPR-Z0-9]{17}$"))
            {
                MessageBox.Show("VIN invalid. Trebuie să conțină 17 caractere.");
                return false;
            }

            if (ClientCombo.SelectedItem == null)
            {
                MessageBox.Show("Selectați proprietarul vehiculului.");
                return false;
            }

            return true;
        }

        private void AdaugareVehicul_Click(object sender, RoutedEventArgs e)
        {
            if (!Validari())
                return;

            var vehicul = new Vehicul
            {
                NumarInmatriculare = NrTextBox.Text.Trim(),
                Marca = MarcaTextBox.Text.Trim(),
                Model = ModelTextBox.Text.Trim(),
                VIN = VINTextBox.Text.Trim(),
                ClientId = (int)ClientCombo.SelectedValue
            };

            _context.Vehicule.Add(vehicul);
            _context.SaveChanges();

            MessageBox.Show("Vehicul adăugat cu succes!");
            this.Close();
        }
    }
}
