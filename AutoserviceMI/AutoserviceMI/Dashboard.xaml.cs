using AutoserviceMI.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;

namespace AutoserviceMI
{
    public partial class Dashboard : Window
    {
        private readonly ProductDbContext _context;

        public Dashboard()
        {
            InitializeComponent();
            _context = App.Db;
            IncarcaDashboard();
        }

        private void IncarcaDashboard()
        {
            IncarcaProgramariUrgente();
            IncarcaProgramariAzi();
            IncarcaStocMic();
            ActualizeazaCarduri();
        }

        private void IncarcaProgramariUrgente()
        {
            var urgente = _context.Programari
                .Where(p => p.TipInterventie.ToLower() == "urgent")
                .Include(p => p.Client)
                .Include(p => p.Vehicul)
                .ToList();

            Programari_Urgente.ItemsSource = urgente;
        }

        private void IncarcaProgramariAzi()
        {
            DateTime azi = DateTime.Today;
            DateTime maine = azi.AddDays(1);

            var aziList = _context.Programari
                .Where(p => p.DataProgramare >= azi && p.DataProgramare < maine)
                .Include(p => p.Client)
                .Include(p => p.Vehicul)
                .ToList();

            Programari_Azi.ItemsSource = aziList;
        }


        private void IncarcaStocMic()
        {
            var stocMic = _context.Produse
                .Where(p => p.Stoc < 5)
                .ToList();

            Programari_Urgent.ItemsSource = stocMic;
        }

        private void ActualizeazaCarduri()
        {
            DateTime azi = DateTime.Today;

            int nrUrgente = _context.Programari
                .Count(p => p.TipInterventie.ToLower() == "urgent");

            int nrAzi = _context.Programari
                .Count(p => p.DataProgramare.Date == azi);

            int nrInProgres = _context.Reparatii.Count(r => r.Status == "În progres");

            int nrStocMic = _context.Produse
                .Count(p => p.Stoc < 5);

            CardUrgente.Text = nrUrgente.ToString();
            CardProgramariAzi.Text = nrAzi.ToString();
            CardStocMic.Text = nrStocMic.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Clienti f = new Clienti(App.Db);
            f.ShowDialog();
            IncarcaDashboard();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Programari f = new Programari(App.Db);
            f.ShowDialog();
            IncarcaDashboard();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Depozit f = new Depozit(App.Db);
            f.ShowDialog();
            IncarcaDashboard();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Vehicule f = new Vehicule(App.Db);
            f.ShowDialog();
            IncarcaDashboard();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Reparatii a = new Reparatii(App.Db);
            a.ShowDialog();
            IncarcaDashboard();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            var reparatii = _context.Reparatii.ToList();

            foreach (var r in reparatii)
            {
                string s = r.Status.Trim().ToLower();

                if (s == "in progres" || s == "în progres" || s == "in lucru" || s == "în lucru")
                    r.Status = "În progres";

                if (s == "finalizata" || s == "finalizată")
                    r.Status = "Finalizată";

                if (s == "in asteptare" || s == "în așteptare" || s == "neînceput" || s == "neinceput")
                    r.Status = "În așteptare";
            }

            _context.SaveChanges();
        }
    }
}
