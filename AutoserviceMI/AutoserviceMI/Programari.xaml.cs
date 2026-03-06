using AutoserviceMI.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AutoserviceMI
{
    public partial class Programari : Window
    {
        private readonly ProductDbContext _context;

        public Programari(ProductDbContext context)
        {
            InitializeComponent();
            _context = context;
            IncarcaProgramari();
        }

        private void IncarcaProgramari()
        {
            ProgramariDataGrid.ItemsSource = _context.Programari
                .Include(p => p.Client)
                .Include(p => p.Vehicul)
                .ToList();
        }

        private void Filtrare_Click(object sender, RoutedEventArgs e)
        {
            var query = _context.Programari
                .Include(p => p.Client)
                .Include(p => p.Vehicul)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(FilterClient.Text))
                query = query.Where(p => p.Client.Nume.Contains(FilterClient.Text));

            if (!string.IsNullOrWhiteSpace(FilterVehicul.Text))
                query = query.Where(p => p.Vehicul.NumarInmatriculare.Contains(FilterVehicul.Text));

            if (!string.IsNullOrWhiteSpace(FilterData.Text))
            {
                if (DateTime.TryParse(FilterData.Text, out DateTime data))
                    query = query.Where(p => p.DataProgramare.Date == data.Date);
            }

            var selected = (FilterStare.SelectedItem as ComboBoxItem)?.Content?.ToString();

            if (selected != null && selected != "Toate")
                query = query.Where(p => p.Stare == selected);

            ProgramariDataGrid.ItemsSource = query.ToList();
        }

        private void Adaugare_Click(object sender, RoutedEventArgs e)
        {
            var form = new Adaugare_Programare(_context);
            form.ShowDialog();
            IncarcaProgramari();
        }

        private void Modificare_Click(object sender, RoutedEventArgs e)
        {
            var programare = ProgramariDataGrid.SelectedItem as Programare;

            if (programare == null)
            {
                MessageBox.Show("Selectați o programare!");
                return;
            }

            var form = new Modificare_Programare(_context, programare);
            form.ShowDialog();
            IncarcaProgramari();
        }

        private void Stergere_Click(object sender, RoutedEventArgs e)
        {
            var programare = ProgramariDataGrid.SelectedItem as Programare;

            if (programare == null)
            {
                MessageBox.Show("Selectați o programare!");
                return;
            }

            var confirm = MessageBox.Show(
                "Sigur doriți să ștergeți această programare?",
                "Confirmare ștergere",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (confirm != MessageBoxResult.Yes)
                return;

            _context.Programari.Remove(programare);
            _context.SaveChanges();

            IncarcaProgramari();
            MessageBox.Show("Programare ștearsă cu succes!");
        }

        private void InProgres_Click(object sender, RoutedEventArgs e)
        {
            var programare = ProgramariDataGrid.SelectedItem as Programare;

            if (programare == null)
            {
                MessageBox.Show("Selectați o programare!");
                return;
            }

            programare.Stare = "În progres";
            _context.SaveChanges();

            IncarcaProgramari();
        }

        private void Finalizare_Click(object sender, RoutedEventArgs e)
        {
            var programare = ProgramariDataGrid.SelectedItem as Programare;

            if (programare == null)
            {
                MessageBox.Show("Selectați o programare!");
                return;
            }

            programare.Stare = "Finalizată";
            _context.SaveChanges();

            IncarcaProgramari();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
