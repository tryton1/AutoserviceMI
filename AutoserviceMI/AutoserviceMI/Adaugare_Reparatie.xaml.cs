using AutoserviceMI.Data;
using AutoserviceMI.Detalii;
using System;
using System.Linq;
using System.Windows;

namespace AutoserviceMI
{
    public partial class Adaugare_Reparatie : Window
    {
        private readonly ProductDbContext _context;

        public Adaugare_Reparatie(ProductDbContext context)
        {
            InitializeComponent();
            _context = context;

            ClientCombo.ItemsSource = _context.Clienti
                .Select(c => new { Id = c.Id, FullName = c.Nume + " " + c.Prenume })
                .OrderBy(c => c.FullName)
                .ToList();
            ClientCombo.DisplayMemberPath = "FullName";
            ClientCombo.SelectedValuePath = "Id";
            VehiculCombo.ItemsSource = _context.Vehicule
                .Select(v => new { Id = v.Id, Info = v.NumarInmatriculare + " - " + v.Marca + " " + v.Model })
                .OrderBy(v => v.Info)
                .ToList();
            VehiculCombo.DisplayMemberPath = "Info";
            VehiculCombo.SelectedValuePath = "Id";

            TipInterventieCombo.ItemsSource = new string[]
            {
        "Diagnoză",
        "Reparație motor",
        "Schimb ulei",
        "Schimb plăcuțe frână",
        "Electrică",
        "Tinichigerie",
        "Altele"
            };

            DataStartPicker.SelectedDate = DateTime.Now;
        }


        private void SalvareReparatie_Click(object sender, RoutedEventArgs e)
        {
            if (ClientCombo.SelectedValue == null)
            {
                MessageBox.Show("Selectați clientul!");
                return;
            }

            if (VehiculCombo.SelectedValue == null)
            {
                MessageBox.Show("Selectați vehiculul!");
                return;
            }

            int clientId = (int)ClientCombo.SelectedValue;
            int vehiculId = (int)VehiculCombo.SelectedValue;

            string tip = TipInterventieCombo.SelectedItem as string;
            string mecanic = MecanicText.Text;
            string costStr = CostText.Text;

            if (string.IsNullOrWhiteSpace(tip))
            {
                MessageBox.Show("Selectați tipul intervenției!");
                return;
            }

            if (string.IsNullOrWhiteSpace(mecanic))
            {
                MessageBox.Show("Introduceți numele mecanicului!");
                return;
            }

            if (!decimal.TryParse(costStr, out decimal cost) || cost < 0)
            {
                MessageBox.Show("Costul estimat trebuie să fie un număr pozitiv!");
                return;
            }

            DateTime dataStart = DataStartPicker.SelectedDate ?? DateTime.Now;

            var rep = new Reparatie
            {
                ClientId = clientId,
                VehiculId = vehiculId,
                TipInterventie = tip,
                Mecanic = mecanic,
                CostEstimat = cost,
                Descriere = "",
                Status = "Neînceput",
                DataStart = dataStart,
            };

            _context.Reparatii.Add(rep);
            _context.SaveChanges();

            MessageBox.Show("Reparația a fost adăugată cu succes!");
            Close();
        }

    }
}
