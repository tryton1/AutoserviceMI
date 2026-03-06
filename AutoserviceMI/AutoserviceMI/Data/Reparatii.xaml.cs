using AutoserviceMI.Data;
using AutoserviceMI.Detalii;
using AutoserviceMI.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;

namespace AutoserviceMI
{
    public partial class Reparatii : Window
    {
        private readonly ProductDbContext _context;

        public Reparatii(ProductDbContext context)
        {
            InitializeComponent();
            _context = context;
            IncarcaReparatii();
        }

        private void IncarcaReparatii()
        {
            DataGridReparatii.ItemsSource = _context.Reparatii
                .Include(r => r.Client)
                .Include(r => r.Vehicul)
                .ToList();
        }

        private void DataGridReparatii_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var rep = DataGridReparatii.SelectedItem as Reparatie;
            if (rep == null)
            {
                CardStatus.Text = "-";
                CardMecanic.Text = "-";
                CardCost.Text = "-";
                CardTip.Text = "-";
                return;
            }

            CardStatus.Text = rep.Status ?? "-";
            CardMecanic.Text = rep.Mecanic ?? "-";
            CardCost.Text = rep.CostTotal.ToString("0.00");
            CardTip.Text = rep.TipInterventie ?? "-";
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var f = new Adaugare_Reparatie(_context);
            f.ShowDialog();
            IncarcaReparatii();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var rep = DataGridReparatii.SelectedItem as Reparatie;
            if (rep == null)
            {
                MessageBox.Show("Selectati o reparatie!");
                return;
            }

            var f = new Modificare_Reparatie(_context, rep);
            f.ShowDialog();
            IncarcaReparatii();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var rep = DataGridReparatii.SelectedItem as Reparatie;
            if (rep == null)
            {
                MessageBox.Show("Selectati o reparatie!");
                return;
            }

            var confirm = MessageBox.Show(
                $"Stergeti reparatia pentru {rep.Client.Nume} ({rep.Vehicul.Model})?",
                "Confirmare",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (confirm != MessageBoxResult.Yes)
                return;

            _context.Reparatii.Remove(rep);
            _context.SaveChanges();
            IncarcaReparatii();
        }

        private void BtnPiese_Click(object sender, RoutedEventArgs e)
        {
            var rep = DataGridReparatii.SelectedItem as Reparatie;
            if (rep == null)
            {
                MessageBox.Show("Selectati o reparatie!");
                return;
            }

            var f = new Piese_Reparatie(_context, rep);
            f.ShowDialog();
        }

        private void BtnFinalizeaza_Click(object sender, RoutedEventArgs e)
        {
            var rep = DataGridReparatii.SelectedItem as Reparatie;
            if (rep == null)
            {
                MessageBox.Show("Selectati o reparatie!");
                return;
            }

            rep.Status = "Finalizata";
            rep.DataFinalizare = DateTime.Now;
            _context.SaveChanges();

            IncarcaReparatii();
            MessageBox.Show("Reparatia a fost finalizata!");
        }

        private void BtnFiltrare_Click(object sender, RoutedEventArgs e)
        {
            var f = new Filtrare_Reparatii(_context);

            if (f.ShowDialog() == true)
            {
                DataGridReparatii.ItemsSource = f.Result
                    .Include(r => r.Client)
                    .Include(r => r.Vehicul)
                    .ToList();
            }
        }
    }
}
