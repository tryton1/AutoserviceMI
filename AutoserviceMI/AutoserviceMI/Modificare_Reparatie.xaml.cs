using AutoserviceMI.Data;
using AutoserviceMI.Detalii;
using System;
using System.Linq;
using System.Windows;

namespace AutoserviceMI
{
    public partial class Modificare_Reparatie : Window
    {
        private readonly ProductDbContext _context;
        private Reparatie _reparatie;

        public Modificare_Reparatie(ProductDbContext context, Reparatie reparatie)
        {
            InitializeComponent();
            _context = context;
            _reparatie = reparatie;

            TipInterventieCombo.ItemsSource = new string[]
            {
                "Diagnoză", "Reparație motor", "Schimb ulei",
                "Schimb plăcuțe frână", "Electrică",
                "Tinichigerie", "Altele"
            };

            StatusCombo.ItemsSource = new string[]
            {
                "Neînceput", "În progres", "Finalizată"
            };

            TipInterventieCombo.SelectedItem = _reparatie.TipInterventie;
            MecanicText.Text = _reparatie.Mecanic;
            DescriereText.Text = _reparatie.Descriere;
            StatusCombo.SelectedItem = _reparatie.Status;

            if (_reparatie.DataFinalizare.HasValue)
                DataFinalizarePicker.SelectedDate = _reparatie.DataFinalizare.Value;
        }

        private void SalvareModificare_Click(object sender, RoutedEventArgs e)
        {
            _reparatie.TipInterventie = TipInterventieCombo.SelectedItem?.ToString();
            _reparatie.Mecanic = MecanicText.Text;
            _reparatie.Descriere = DescriereText.Text;
            _reparatie.Status = StatusCombo.SelectedItem?.ToString();

            if (_reparatie.Status == "Finalizată")
                _reparatie.DataFinalizare = DateTime.Now;
            else
                _reparatie.DataFinalizare = DataFinalizarePicker.SelectedDate;

            _context.Reparatii.Update(_reparatie);
            _context.SaveChanges();

            MessageBox.Show("Reparația a fost modificată cu succes!");
            Close();
        }
    }
}
