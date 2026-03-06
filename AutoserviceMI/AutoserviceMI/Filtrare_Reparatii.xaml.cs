using AutoserviceMI.Data;
using AutoserviceMI.Detalii;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AutoserviceMI
{
    public partial class Filtrare_Reparatii : Window
    {
        private readonly ProductDbContext _context;

        public IQueryable<Reparatie> Result { get; private set; }

        public Filtrare_Reparatii(ProductDbContext context)
        {
            InitializeComponent();
            _context = context;

            ComboClient.ItemsSource = _context.Clienti.ToList();
            ComboClient.DisplayMemberPath = "Nume";

            ComboVehicul.ItemsSource = _context.Vehicule.ToList();
            ComboVehicul.DisplayMemberPath = "Model";

            ComboTipInterventie.ItemsSource =
                _context.Reparatii.Select(r => r.TipInterventie).Distinct().ToList();
        }

        private void Filtreaza_Click(object sender, RoutedEventArgs e)
        {
            var query = _context.Reparatii
                .Include(r => r.Client)
                .Include(r => r.Vehicul)
                .AsQueryable();

            if (ComboClient.SelectedItem is Client c)
                query = query.Where(r => r.ClientId == c.Id);

            if (ComboVehicul.SelectedItem is Vehicul v)
                query = query.Where(r => r.VehiculId == v.Id);

            if (ComboStatus.SelectedItem is ComboBoxItem st)
                query = query.Where(r => r.Status == st.Content.ToString());

            if (ComboTipInterventie.SelectedItem is string tip)
                query = query.Where(r => r.TipInterventie == tip);

            if (DataStart.SelectedDate.HasValue)
                query = query.Where(r => r.DataStart >= DataStart.SelectedDate.Value);

            if (DataEnd.SelectedDate.HasValue)
                query = query.Where(r => r.DataStart <= DataEnd.SelectedDate.Value);

            Result = query;

            DialogResult = true;
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            ComboClient.SelectedItem = null;
            ComboVehicul.SelectedItem = null;
            ComboStatus.SelectedItem = null;
            ComboTipInterventie.SelectedItem = null;
            DataStart.SelectedDate = null;
            DataEnd.SelectedDate = null;
        }
    }
}
