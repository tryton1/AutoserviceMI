using AutoserviceMI.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;

namespace AutoserviceMI
{
    public partial class Adaugare_Programare : Window
    {
        private readonly ProductDbContext _context;

        public Adaugare_Programare(ProductDbContext context)
        {
            InitializeComponent();
            _context = context;

            ClientCombo.ItemsSource = _context.Clienti.ToList();
            ClientCombo.DisplayMemberPath = "Nume";
            ClientCombo.SelectedValuePath = "Id";

            VehiculCombo.ItemsSource = _context.Vehicule
                .Include(v => v.Client)
                .ToList();

            VehiculCombo.DisplayMemberPath = "NumarInmatriculare";
            VehiculCombo.SelectedValuePath = "Id";
        }

        private void SalvareProgramare_Click(object sender, RoutedEventArgs e)
        {
            if (ClientCombo.SelectedItem == null ||
                VehiculCombo.SelectedItem == null ||
                DataPicker.SelectedDate == null ||
                string.IsNullOrWhiteSpace(TipInterventieTextBox.Text))
            {
                MessageBox.Show("Completați toate câmpurile obligatorii!");
                return;
            }

            var programare = new Programare
            {
                ClientId = (int)ClientCombo.SelectedValue,
                VehiculId = (int)VehiculCombo.SelectedValue,
                DataProgramare = DataPicker.SelectedDate.Value,
                TipInterventie = TipInterventieTextBox.Text.Trim(),
                Mecanic = MecanicTextBox.Text.Trim(),
                Stare = "Planificată"
            };

            _context.Programari.Add(programare);
            _context.SaveChanges();

            MessageBox.Show("Programare adăugată cu succes!");
            this.Close();
        }
    }
}
