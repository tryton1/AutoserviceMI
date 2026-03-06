using AutoserviceMI.Data;
using AutoserviceMI.Detalii;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace AutoserviceMI
{
    public partial class Modificare_Vehicul : Window
    {
        private readonly ProductDbContext _context;
        private readonly Vehicul _vehicul;

        public Modificare_Vehicul(ProductDbContext context, Vehicul vehicul)
        {
            InitializeComponent();
            _context = context;
            _vehicul = vehicul;
            IncarcaClienti();
            IncarcaDate();
        }

        private void IncarcaClienti()
        {
            ClientCombo.ItemsSource = _context.Clienti.ToList();
            ClientCombo.DisplayMemberPath = "Nume";
            ClientCombo.SelectedValuePath = "Id";
        }

        private void IncarcaDate()
        {
            NrTextBox.Text = _vehicul.NumarInmatriculare;
            MarcaTextBox.Text = _vehicul.Marca;
            ModelTextBox.Text = _vehicul.Model;
            VINTextBox.Text = _vehicul.VIN;
            ClientCombo.SelectedValue = _vehicul.ClientId;
        }

        private bool Validari()
        {
            if (NrTextBox.Text.Trim().Length < 5)
            {
                MessageBox.Show("Număr înmatriculare invalid.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(MarcaTextBox.Text) || MarcaTextBox.Text.Length > 20)
            {
                MessageBox.Show("Marca nu este validă.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(ModelTextBox.Text) || ModelTextBox.Text.Length > 20)
            {
                MessageBox.Show("Modelul nu este valid.");
                return false;
            }

            if (!Regex.IsMatch(VINTextBox.Text.Trim(), @"^[A-HJ-NPR-Z0-9]{17}$"))
            {
                MessageBox.Show("VIN invalid.");
                return false;
            }

            if (ClientCombo.SelectedItem == null)
            {
                MessageBox.Show("Selectați proprietarul vehiculului.");
                return false;
            }

            return true;
        }

        private void SalvareVehicul_Click(object sender, RoutedEventArgs e)
        {
            if (!Validari())
                return;

            _vehicul.NumarInmatriculare = NrTextBox.Text.Trim();
            _vehicul.Marca = MarcaTextBox.Text.Trim();
            _vehicul.Model = ModelTextBox.Text.Trim();
            _vehicul.VIN = VINTextBox.Text.Trim();
            _vehicul.ClientId = (int)ClientCombo.SelectedValue;

            _context.SaveChanges();

            MessageBox.Show("Modificările au fost salvate cu succes!");
            this.Close();
        }
    }
}
