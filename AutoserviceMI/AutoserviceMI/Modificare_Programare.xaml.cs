using AutoserviceMI.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AutoserviceMI
{
    public partial class Modificare_Programare : Window
    {
        private readonly ProductDbContext _context;
        private readonly Programare _programare;

        public Modificare_Programare(ProductDbContext context, Programare programare)
        {
            InitializeComponent();
            _context = context;
            _programare = programare;

            ClientCombo.ItemsSource = _context.Clienti.ToList();
            ClientCombo.DisplayMemberPath = "Nume";
            ClientCombo.SelectedValuePath = "Id";

            VehiculCombo.ItemsSource = _context.Vehicule
                .Include(v => v.Client)
                .ToList();
            VehiculCombo.DisplayMemberPath = "NumarInmatriculare";
            VehiculCombo.SelectedValuePath = "Id";

            ClientCombo.SelectedValue = _programare.ClientId;
            VehiculCombo.SelectedValue = _programare.VehiculId;

            DataPicker.SelectedDate = _programare.DataProgramare;
            TipInterventieTextBox.Text = _programare.TipInterventie;
            MecanicTextBox.Text = _programare.Mecanic;

            StareCombo.SelectedItem =
                StareCombo.Items
                .Cast<ComboBoxItem>()
                .First(i => i.Content.ToString() == _programare.Stare);
        }

        private void SalvareModificari_Click(object sender, RoutedEventArgs e)
        {
            if (ClientCombo.SelectedItem == null ||
                VehiculCombo.SelectedItem == null ||
                DataPicker.SelectedDate == null)
            {
                MessageBox.Show("Completați toate câmpurile obligatorii!");
                return;
            }

            _programare.ClientId = (int)ClientCombo.SelectedValue;
            _programare.VehiculId = (int)VehiculCombo.SelectedValue;
            _programare.DataProgramare = DataPicker.SelectedDate.Value;
            _programare.TipInterventie = TipInterventieTextBox.Text.Trim();
            _programare.Mecanic = MecanicTextBox.Text.Trim();
            _programare.Stare =
                (StareCombo.SelectedItem as ComboBoxItem)?.Content.ToString();

            _context.SaveChanges();

            MessageBox.Show("Modificări salvate cu succes!");
            this.Close();
        }
    }
}
