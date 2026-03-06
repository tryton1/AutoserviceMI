using AutoserviceMI.Data;
using AutoserviceMI.Detalii;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;

namespace AutoserviceMI.Resources
{
    public partial class Piese_Reparatie : Window
    {
        private readonly ProductDbContext _context;
        private readonly Reparatie _reparatie;

        public Piese_Reparatie(ProductDbContext context, Reparatie reparatie)
        {
            InitializeComponent();
            _context = context;
            _reparatie = reparatie;
            IncarcaPiese();
            BtnAddPiesa.Click += BtnAddPiesa_Click;
            BtnDeletePiesa.Click += BtnDeletePiesa_Click;
            BtnClose.Click += (s, e) => Close();
        }

        private void IncarcaPiese()
        {
            DataGridPiese.ItemsSource = _context.ReparatiePiese
                .Include(rp => rp.Produs)
                .Where(rp => rp.ReparatieId == _reparatie.Id)
                .ToList();
        }

        private void BtnAddPiesa_Click(object sender, RoutedEventArgs e)
        {
            var f = new Adaugare_Piesa_Reparatie(_context, _reparatie);
            f.ShowDialog();
            IncarcaPiese();
            ActualizeazaCostTotal();
        }

        private void BtnDeletePiesa_Click(object sender, RoutedEventArgs e)
        {
            var piesa = DataGridPiese.SelectedItem as ReparatiePiesa;
            if (piesa == null)
            {
                MessageBox.Show("Selectati o piesa!");
                return;
            }

            var confirm = MessageBox.Show(
                $"Scoateti piesa {piesa.Produs.Denumire}?",
                "Confirmare",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (confirm != MessageBoxResult.Yes)
                return;

            var produs = _context.Produse.First(x => x.Id == piesa.ProdusId);
            produs.Stoc += piesa.Cantitate;

            _context.ReparatiePiese.Remove(piesa);
            _context.SaveChanges();

            IncarcaPiese();
            ActualizeazaCostTotal();
        }

        private void ActualizeazaCostTotal()
        {
            var totalPiese = _context.ReparatiePiese
    .Where(rp => rp.ReparatieId == _reparatie.Id)
    .AsEnumerable()
    .Sum(rp => rp.Cantitate * rp.PretUnitate);


            _reparatie.CostTotalPiese = totalPiese;
            _reparatie.CostTotal = _reparatie.CostEstimat + totalPiese;

            _context.SaveChanges();
        }
    }
}
