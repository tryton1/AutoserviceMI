using AutoserviceMI.Data;
using AutoserviceMI.Detalii;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AutoserviceMI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ProductDbContext Db { get; set; }

        public App()
        {
            SQLitePCL.Batteries_V2.Init();

            var options = new DbContextOptionsBuilder<ProductDbContext>()
                .UseSqlite("Data Source=autoservice.db")
                .Options;

            Db = new ProductDbContext(options);

            Db.Database.Migrate();





        }



        private void SeedDataIfEmpty()
        {
            if (!Db.Users.Any())
            {
                Db.Users.AddRange(
                    new User { Id = 1, Username = "admin", Parola = "admin", Rol = "Administrator" },
                    new User { Id = 2, Username = "mecanic", Parola = "mecanic123", Rol = "Mecanic" },
                    new User { Id = 3, Username = "manager", Parola = "manager123", Rol = "Manager" }
                );

                // ====================== PROGRAMARI (15 inregistrari) ======================
                if (!Db.Programari.Any())
                {
                    var azi = DateTime.Today;

                    Db.Programari.AddRange(
    new Programare { Id = 1, ClientId = 1, VehiculId = 1, DataProgramare = azi.AddDays(1).AddHours(10), TipInterventie = "Schimb ulei", Stare = "În progres" },
    new Programare { Id = 2, ClientId = 3, VehiculId = 3, DataProgramare = azi.AddDays(2).AddHours(14), TipInterventie = "Diagnoză motor", Stare = "În progres" },
    new Programare { Id = 3, ClientId = 5, VehiculId = 5, DataProgramare = azi.AddDays(3).AddHours(9), TipInterventie = "Plăcuțe frână", Stare = "În progres" },
    new Programare { Id = 4, ClientId = 7, VehiculId = 7, DataProgramare = azi.AddDays(1).AddHours(16), TipInterventie = "Schimb baterie", Stare = "În progres" },
    new Programare { Id = 5, ClientId = 9, VehiculId = 9, DataProgramare = azi.AddDays(4).AddHours(11), TipInterventie = "Revizie generală", Stare = "În progres" },

    new Programare { Id = 6, ClientId = 12, VehiculId = 12, DataProgramare = azi.AddHours(2), TipInterventie = "Urgent", Stare = "În progres" },
    new Programare { Id = 7, ClientId = 14, VehiculId = 14, DataProgramare = azi.AddHours(3), TipInterventie = "Urgent", Stare = "În progres" },

    new Programare { Id = 8, ClientId = 15, VehiculId = 15, DataProgramare = azi.AddDays(5).AddHours(15), TipInterventie = "Suspensie", Stare = "În progres" },
    new Programare { Id = 9, ClientId = 16, VehiculId = 16, DataProgramare = azi.AddDays(6).AddHours(12), TipInterventie = "Schimb filtrare", Stare = "În progres" },
    new Programare { Id = 10, ClientId = 17, VehiculId = 17, DataProgramare = azi.AddDays(3).AddHours(10), TipInterventie = "Electromotor", Stare = "În progres" },

    new Programare { Id = 11, ClientId = 18, VehiculId = 18, DataProgramare = azi.AddDays(7).AddHours(9), TipInterventie = "Anvelope vară", Stare = "În progres" },
    new Programare { Id = 12, ClientId = 19, VehiculId = 19, DataProgramare = azi.AddDays(8).AddHours(13), TipInterventie = "Far xenon", Stare = "În progres" },
    new Programare { Id = 13, ClientId = 20, VehiculId = 20, DataProgramare = azi.AddDays(4).AddHours(17), TipInterventie = "Tobă evacuare", Stare = "În progres" },

    new Programare { Id = 14, ClientId = 21, VehiculId = 21, DataProgramare = azi.AddDays(1).AddHours(9), TipInterventie = "Schimb amortizoare", Stare = "În progres" },
    new Programare { Id = 15, ClientId = 23, VehiculId = 23, DataProgramare = azi.AddDays(1).AddHours(11), TipInterventie = "Radiator", Stare = "În progres" }
);
                }


                if (!Db.Clienti.Any())
                {
                    Db.Clienti.AddRange(
                        // Chisinau
                        new Client { Id = 1, Nume = "Popescu", Prenume = "Ion", Telefon = "+37369123456", Oras = "Chisinau" },
                        new Client { Id = 2, Nume = "Ionescu", Prenume = "Maria", Telefon = "+37360111222", Oras = "Chisinau" },
                        new Client { Id = 3, Nume = "Dumitru", Prenume = "Andrei", Telefon = "+37361122333", Oras = "Chisinau" },
                        new Client { Id = 4, Nume = "Stratan", Prenume = "Elena", Telefon = "+37362133444", Oras = "Chisinau" },
                        new Client { Id = 5, Nume = "Ceban", Prenume = "Victor", Telefon = "+37363144555", Oras = "Chisinau" },

                        // Balti
                        new Client { Id = 6, Nume = "Grosu", Prenume = "Nicolae", Telefon = "+37364155666", Oras = "Balti" },
                        new Client { Id = 7, Nume = "Munteanu", Prenume = "Ana", Telefon = "+37365166777", Oras = "Balti" },
                        new Client { Id = 8, Nume = "Balan", Prenume = "Sergiu", Telefon = "+37366177888", Oras = "Balti" },
                        new Client { Id = 9, Nume = "Rusu", Prenume = "Lilia", Telefon = "+37367188999", Oras = "Balti" },

                        // Cahul
                        new Client { Id = 10, Nume = "Ciobanu", Prenume = "Vasile", Telefon = "+37368199000", Oras = "Cahul" },
                        new Client { Id = 11, Nume = "Moraru", Prenume = "Diana", Telefon = "+37369100111", Oras = "Cahul" },

                        // Orhei
                        new Client { Id = 12, Nume = "Rotaru", Prenume = "Mihai", Telefon = "+37360111222", Oras = "Orhei" },
                        new Client { Id = 13, Nume = "Lupu", Prenume = "Olga", Telefon = "+37361122333", Oras = "Orhei" },

                        // Soroca
                        new Client { Id = 14, Nume = "Covali", Prenume = "Petru", Telefon = "+37362133444", Oras = "Soroca" },

                        // Edinet
                        new Client { Id = 15, Nume = "Bodiu", Prenume = "Irina", Telefon = "+37363144555", Oras = "Edinet" },

                        // Ungheni
                        new Client { Id = 16, Nume = "Sava", Prenume = "Alexandru", Telefon = "+37364155666", Oras = "Ungheni" },
                        new Client { Id = 17, Nume = "Pascari", Prenume = "Natalia", Telefon = "+37365166777", Oras = "Ungheni" },

                        // Hincesti
                        new Client { Id = 18, Nume = "Bejan", Prenume = "Gheorghe", Telefon = "+37366177888", Oras = "Hincesti" },

                        // Floresti
                        new Client { Id = 19, Nume = "Ungureanu", Prenume = "Corina", Telefon = "+37367188999", Oras = "Floresti" },

                        // Tiraspol
                        new Client { Id = 20, Nume = "Miron", Prenume = "Dumitru", Telefon = "+37368199000", Oras = "Tiraspol" },

                        // Comrat
                        new Client { Id = 21, Nume = "Cazacu", Prenume = "Ion", Telefon = "+37369100111", Oras = "Comrat" },

                        // Straseni
                        new Client { Id = 22, Nume = "Gutu", Prenume = "Mariana", Telefon = "+37360111222", Oras = "Straseni" },

                        // Drochia
                        new Client { Id = 23, Nume = "Pintii", Prenume = "Valeriu", Telefon = "+37361122333", Oras = "Drochia" }
                    );
                }

                // ====================== VEHICULE (23 inregistrari) ======================
                if (!Db.Vehicule.Any())
                {
                    Db.Vehicule.AddRange(
                        // Vehicule cu numere de Republica Moldova
                        new Vehicul { Id = 1, NumarInmatriculare = "CHI001", Marca = "Dacia", Model = "Logan", VIN = "UU1AB1A23BC456789", ClientId = 1 },
                        new Vehicul { Id = 2, NumarInmatriculare = "CHI123", Marca = "Renault", Model = "Megane", VIN = "VF1AB2C34DE567890", ClientId = 2 },
                        new Vehicul { Id = 3, NumarInmatriculare = "CHI456", Marca = "Volkswagen", Model = "Passat", VIN = "WVWZZZ3CZ6P123456", ClientId = 3 },
                        new Vehicul { Id = 4, NumarInmatriculare = "CHI789", Marca = "Skoda", Model = "Octavia", VIN = "TMBJG61Z782345678", ClientId = 4 },
                        new Vehicul { Id = 5, NumarInmatriculare = "CHI234", Marca = "Toyota", Model = "Corolla", VIN = "JTDBR32E520987654", ClientId = 5 },

                        new Vehicul { Id = 6, NumarInmatriculare = "BLT555", Marca = "BMW", Model = "X5", VIN = "WBACN21050C123456", ClientId = 6 },
                        new Vehicul { Id = 7, NumarInmatriculare = "BLT321", Marca = "Mercedes", Model = "C200", VIN = "WDD2040481A654321", ClientId = 7 },
                        new Vehicul { Id = 8, NumarInmatriculare = "BLT888", Marca = "Audi", Model = "A4", VIN = "WAUZZZ8E1A123456", ClientId = 8 },
                        new Vehicul { Id = 9, NumarInmatriculare = "BLT444", Marca = "Ford", Model = "Focus", VIN = "WF0AXXWPDAW789012", ClientId = 9 },

                        new Vehicul { Id = 10, NumarInmatriculare = "CHL111", Marca = "Opel", Model = "Astra", VIN = "W0L00005123456789", ClientId = 10 },
                        new Vehicul { Id = 11, NumarInmatriculare = "CHL222", Marca = "Peugeot", Model = "308", VIN = "VF3XXC12345678901", ClientId = 11 },

                        new Vehicul { Id = 12, NumarInmatriculare = "ORH333", Marca = "Hyundai", Model = "i30", VIN = "KMHTC12A3U1234567", ClientId = 12 },
                        new Vehicul { Id = 13, NumarInmatriculare = "ORH666", Marca = "Kia", Model = "Ceed", VIN = "KNDJBC12345678901", ClientId = 13 },

                        new Vehicul { Id = 14, NumarInmatriculare = "SRC777", Marca = "Mazda", Model = "3", VIN = "JM1BL123456789012", ClientId = 14 },

                        new Vehicul { Id = 15, NumarInmatriculare = "EDN999", Marca = "Honda", Model = "Civic", VIN = "2HGES26755H123456", ClientId = 15 },

                        new Vehicul { Id = 16, NumarInmatriculare = "UGH222", Marca = "Nissan", Model = "Qashqai", VIN = "SJNFAAAK12H123456", ClientId = 16 },
                        new Vehicul { Id = 17, NumarInmatriculare = "UGH555", Marca = "Suzuki", Model = "Vitara", VIN = "TSMBB21A123456789", ClientId = 17 },

                        new Vehicul { Id = 18, NumarInmatriculare = "HNC777", Marca = "Chevrolet", Model = "Aveo", VIN = "KL1TD666791234567", ClientId = 18 },

                        new Vehicul { Id = 19, NumarInmatriculare = "FLR888", Marca = "Mitsubishi", Model = "Lancer", VIN = "JMBSR123456789012", ClientId = 19 },

                        new Vehicul { Id = 20, NumarInmatriculare = "TIR333", Marca = "Daewoo", Model = "Matiz", VIN = "KLATF123456789012", ClientId = 20 },

                        new Vehicul { Id = 21, NumarInmatriculare = "CMR111", Marca = "Lada", Model = "Vesta", VIN = "XTAFL123456789012", ClientId = 21 },

                        new Vehicul { Id = 22, NumarInmatriculare = "STR444", Marca = "Fiat", Model = "500", VIN = "ZFA31200001234567", ClientId = 22 },

                        new Vehicul { Id = 23, NumarInmatriculare = "DRC222", Marca = "Volvo", Model = "XC60", VIN = "YV1DZ825123456789", ClientId = 23 }
                    );
                }

                // ====================== PRODUSE (25 inregistrari) ======================
                if (!Db.Produse.Any())
                {
                    Db.Produse.AddRange(
                        // Uleiuri
                        new Produs { Id = 1, CodProdus = "ULEI-5W30", Denumire = "Ulei motor 5W30", Producator = "Castrol", Pret = 420, Stoc = 25, StocMinim = 3 },
                        new Produs { Id = 2, CodProdus = "ULEI-10W40", Denumire = "Ulei motor 10W40", Producator = "Mobil", Pret = 380, Stoc = 30, StocMinim = 4 },
                        new Produs { Id = 3, CodProdus = "ULEI-5W40", Denumire = "Ulei motor 5W40", Producator = "Shell", Pret = 450, Stoc = 20, StocMinim = 3 },

                        // Filtre
                        new Produs { Id = 4, CodProdus = "FLT-ULEI", Denumire = "Filtru de ulei", Producator = "MANN", Pret = 130, Stoc = 45, StocMinim = 5 },
                        new Produs { Id = 5, CodProdus = "FLT-AER", Denumire = "Filtru de aer", Producator = "Bosch", Pret = 160, Stoc = 35, StocMinim = 4 },
                        new Produs { Id = 6, CodProdus = "FLT-CAB", Denumire = "Filtru de cabina", Producator = "Mahle", Pret = 190, Stoc = 25, StocMinim = 3 },
                        new Produs { Id = 7, CodProdus = "FLT-CMB", Denumire = "Filtru combustibil", Producator = "Purflux", Pret = 210, Stoc = 15, StocMinim = 2 },

                        // Frane
                        new Produs { Id = 8, CodProdus = "PLA-FRAN", Denumire = "Plăcuțe frână față", Producator = "Brembo", Pret = 480, Stoc = 18, StocMinim = 3 },
                        new Produs { Id = 9, CodProdus = "PLA-FRAN-S", Denumire = "Plăcuțe frână spate", Producator = "Brembo", Pret = 380, Stoc = 16, StocMinim = 3 },
                        new Produs { Id = 10, CodProdus = "DISC-FRAN", Denumire = "Disc frână față", Producator = "Textar", Pret = 750, Stoc = 12, StocMinim = 2 },
                        new Produs { Id = 11, CodProdus = "LCH-FRAN", Denumire = "Lichid de frână", Producator = "Bosch", Pret = 100, Stoc = 28, StocMinim = 4 },

                        // Bujii si aprindere
                        new Produs { Id = 12, CodProdus = "BUJII", Denumire = "Bujii aprindere", Producator = "NGK", Pret = 95, Stoc = 50, StocMinim = 6 },
                        new Produs { Id = 13, CodProdus = "BOB-APR", Denumire = "Bobină aprindere", Producator = "Beru", Pret = 290, Stoc = 14, StocMinim = 2 },

                        // Electrice
                        new Produs { Id = 14, CodProdus = "BATERIE", Denumire = "Baterie auto 60Ah", Producator = "Varta", Pret = 1250, Stoc = 8, StocMinim = 1 },
                        new Produs { Id = 15, CodProdus = "ALTERN", Denumire = "Alternator", Producator = "Bosch", Pret = 1950, Stoc = 4, StocMinim = 1 },
                        new Produs { Id = 16, CodProdus = "STARTER", Denumire = "Starter", Producator = "Denso", Pret = 1750, Stoc = 5, StocMinim = 1 },

                        // Anvelope
                        new Produs { Id = 17, CodProdus = "ANV-IARNA", Denumire = "Anvelopă iarnă 205/55/R16", Producator = "Nokian", Pret = 950, Stoc = 20, StocMinim = 4 },
                        new Produs { Id = 18, CodProdus = "ANV-VARA", Denumire = "Anvelopă vară 205/55/R16", Producator = "Michelin", Pret = 890, Stoc = 22, StocMinim = 4 },

                        // Distributie
                        new Produs { Id = 19, CodProdus = "CUR-DIST", Denumire = "Curea distribuție", Producator = "Continental", Pret = 650, Stoc = 8, StocMinim = 1 },
                        new Produs { Id = 20, CodProdus = "KIT-DIST", Denumire = "Kit distribuție complet", Producator = "Gates", Pret = 1850, Stoc = 6, StocMinim = 1 },

                        // Suspensie
                        new Produs { Id = 21, CodProdus = "AMORTIZ", Denumire = "Amortizor față", Producator = "Bilstein", Pret = 900, Stoc = 10, StocMinim = 2 },
                        new Produs { Id = 22, CodProdus = "RULMENT", Denumire = "Rulment roată", Producator = "SKF", Pret = 320, Stoc = 16, StocMinim = 3 },

                        // Racire
                        new Produs { Id = 23, CodProdus = "POMPA-APA", Denumire = "Pompă apă", Producator = "Hepu", Pret = 580, Stoc = 9, StocMinim = 2 },
                        new Produs { Id = 24, CodProdus = "RADIATOR", Denumire = "Radiator motor", Producator = "Nissens", Pret = 1050, Stoc = 7, StocMinim = 1 },

                        // Diverse
                        new Produs { Id = 25, CodProdus = "FAR-XENON", Denumire = "Far xenon", Producator = "Osram", Pret = 1350, Stoc = 5, StocMinim = 1 }
                    );
                }

                // ====================== REPARATII (24 inregistrari) ======================
                if (!Db.Reparatii.Any())
                {
                    var now = DateTime.Now;
                    Db.Reparatii.AddRange(
                        // Reparatii In lucru
                        new Reparatie { Id = 1, ClientId = 1, VehiculId = 1, TipInterventie = "Schimb ulei și filtre", Mecanic = "Ion Popa", Status = "In lucru", CostEstimat = 850, DataStart = now.AddDays(-2) },
                        new Reparatie { Id = 2, ClientId = 2, VehiculId = 2, TipInterventie = "Schimb plăcuțe frână", Mecanic = "Vasile Rusu", Status = "In lucru", CostEstimat = 650, DataStart = now.AddDays(-1) },
                        new Reparatie { Id = 3, ClientId = 3, VehiculId = 3, TipInterventie = "Diagnostic complet", Mecanic = "Andrei Ciobanu", Status = "In lucru", CostEstimat = 300, DataStart = now },
                        new Reparatie { Id = 4, ClientId = 6, VehiculId = 6, TipInterventie = "Schimb distribuție", Mecanic = "Mihai Munteanu", Status = "In lucru", CostEstimat = 2800, DataStart = now.AddDays(-3) },
                        new Reparatie { Id = 5, ClientId = 8, VehiculId = 8, TipInterventie = "Reparatie suspensie", Mecanic = "Sergiu Balan", Status = "In lucru", CostEstimat = 2100, DataStart = now.AddDays(-2) },
                        new Reparatie { Id = 6, ClientId = 10, VehiculId = 10, TipInterventie = "Schimb anvelope", Mecanic = "Victor Ceban", Status = "In lucru", CostEstimat = 4200, DataStart = now.AddDays(-1) },
                        new Reparatie { Id = 7, ClientId = 12, VehiculId = 12, TipInterventie = "Schimb bujii", Mecanic = "Ion Popa", Status = "In lucru", CostEstimat = 500, DataStart = now.AddDays(-1) },

                        // Reparatii Finalizate
                        new Reparatie { Id = 8, ClientId = 4, VehiculId = 4, TipInterventie = "Revizie generală", Mecanic = "Vasile Rusu", Status = "Finalizata", CostEstimat = 1950, DataStart = now.AddDays(-10), DataFinalizare = now.AddDays(-7) },
                        new Reparatie { Id = 9, ClientId = 5, VehiculId = 5, TipInterventie = "Schimb baterie", Mecanic = "Andrei Ciobanu", Status = "Finalizata", CostEstimat = 1400, DataStart = now.AddDays(-8), DataFinalizare = now.AddDays(-7) },
                        new Reparatie { Id = 10, ClientId = 7, VehiculId = 7, TipInterventie = "Reparatie alternator", Mecanic = "Mihai Munteanu", Status = "Finalizata", CostEstimat = 2100, DataStart = now.AddDays(-14), DataFinalizare = now.AddDays(-10) },
                        new Reparatie { Id = 11, ClientId = 9, VehiculId = 9, TipInterventie = "Schimb discuri frână", Mecanic = "Sergiu Balan", Status = "Finalizata", CostEstimat = 1850, DataStart = now.AddDays(-5), DataFinalizare = now.AddDays(-3) },
                        new Reparatie { Id = 12, ClientId = 11, VehiculId = 11, TipInterventie = "Schimb pompa apă", Mecanic = "Victor Ceban", Status = "Finalizata", CostEstimat = 950, DataStart = now.AddDays(-6), DataFinalizare = now.AddDays(-4) },
                        new Reparatie { Id = 13, ClientId = 13, VehiculId = 13, TipInterventie = "Schimb filtre cabina", Mecanic = "Ion Popa", Status = "Finalizata", CostEstimat = 450, DataStart = now.AddDays(-4), DataFinalizare = now.AddDays(-3) },
                        new Reparatie { Id = 14, ClientId = 14, VehiculId = 14, TipInterventie = "Reparatie climatronic", Mecanic = "Vasile Rusu", Status = "Finalizata", CostEstimat = 1350, DataStart = now.AddDays(-9), DataFinalizare = now.AddDays(-6) },
                        new Reparatie { Id = 15, ClientId = 15, VehiculId = 15, TipInterventie = "Schimb rulmenți", Mecanic = "Andrei Ciobanu", Status = "Finalizata", CostEstimat = 750, DataStart = now.AddDays(-7), DataFinalizare = now.AddDays(-5) },

                        // Reparatii Neincepute
                        new Reparatie { Id = 16, ClientId = 16, VehiculId = 16, TipInterventie = "Diagnostic motor", Mecanic = "Mihai Munteanu", Status = "Neinceputa", CostEstimat = 250, DataStart = now.AddDays(2) },
                        new Reparatie { Id = 17, ClientId = 17, VehiculId = 17, TipInterventie = "Schimb ulei și filtre", Mecanic = "Sergiu Balan", Status = "Neinceputa", CostEstimat = 900, DataStart = now.AddDays(1) },
                        new Reparatie { Id = 18, ClientId = 18, VehiculId = 18, TipInterventie = "Reparatie eșapament", Mecanic = "Victor Ceban", Status = "Neinceputa", CostEstimat = 1650, DataStart = now.AddDays(3) },
                        new Reparatie { Id = 19, ClientId = 19, VehiculId = 19, TipInterventie = "Schimb far xenon", Mecanic = "Ion Popa", Status = "Neinceputa", CostEstimat = 1500, DataStart = now.AddDays(2) },
                        new Reparatie { Id = 20, ClientId = 20, VehiculId = 20, TipInterventie = "Revizie cutie viteze", Mecanic = "Vasile Rusu", Status = "Neinceputa", CostEstimat = 1200, DataStart = now.AddDays(4) },
                        new Reparatie { Id = 21, ClientId = 21, VehiculId = 21, TipInterventie = "Schimb amortizoare", Mecanic = "Andrei Ciobanu", Status = "Neinceputa", CostEstimat = 3600, DataStart = now.AddDays(5) },
                        new Reparatie { Id = 22, ClientId = 22, VehiculId = 22, TipInterventie = "Reparatie starter", Mecanic = "Mihai Munteanu", Status = "Neinceputa", CostEstimat = 1900, DataStart = now.AddDays(3) },
                        new Reparatie { Id = 23, ClientId = 23, VehiculId = 23, TipInterventie = "Schimb radiator", Mecanic = "Sergiu Balan", Status = "Neinceputa", CostEstimat = 1300, DataStart = now.AddDays(2) },
                        new Reparatie { Id = 24, ClientId = 1, VehiculId = 1, TipInterventie = "Schimb anvelope iarna", Mecanic = "Victor Ceban", Status = "Neinceputa", CostEstimat = 3800, DataStart = now.AddDays(10) }
                    );
                }

                // ====================== PIESE FOLOSITE (45 inregistrari) ======================
                if (!Db.ReparatiePiese.Any())
                {
                    Db.ReparatiePiese.AddRange(
                        // Reparatie 1 - Schimb ulei si filtre
                        new ReparatiePiesa { ReparatieId = 1, ProdusId = 1, Cantitate = 1, PretUnitate = 420 },
                        new ReparatiePiesa { ReparatieId = 1, ProdusId = 4, Cantitate = 1, PretUnitate = 130 },
                        new ReparatiePiesa { ReparatieId = 1, ProdusId = 5, Cantitate = 1, PretUnitate = 160 },

                        // Reparatie 2 - Schimb placute frana
                        new ReparatiePiesa { ReparatieId = 2, ProdusId = 8, Cantitate = 1, PretUnitate = 480 },
                        new ReparatiePiesa { ReparatieId = 2, ProdusId = 11, Cantitate = 1, PretUnitate = 100 },

                        // Reparatie 3 - Diagnostic complet
                        // (nu are piese)

                        // Reparatie 4 - Schimb distributie
                        new ReparatiePiesa { ReparatieId = 4, ProdusId = 20, Cantitate = 1, PretUnitate = 1850 },
                        new ReparatiePiesa { ReparatieId = 4, ProdusId = 23, Cantitate = 1, PretUnitate = 580 },

                        // Reparatie 5 - Reparatie suspensie
                        new ReparatiePiesa { ReparatieId = 5, ProdusId = 21, Cantitate = 2, PretUnitate = 900 },
                        new ReparatiePiesa { ReparatieId = 5, ProdusId = 22, Cantitate = 2, PretUnitate = 320 },

                        // Reparatie 6 - Schimb anvelope
                        new ReparatiePiesa { ReparatieId = 6, ProdusId = 17, Cantitate = 4, PretUnitate = 950 },

                        // Reparatie 7 - Schimb bujii
                        new ReparatiePiesa { ReparatieId = 7, ProdusId = 12, Cantitate = 4, PretUnitate = 95 },

                        // Reparatie 8 - Revizie generala (finalizata)
                        new ReparatiePiesa { ReparatieId = 8, ProdusId = 2, Cantitate = 1, PretUnitate = 380 },
                        new ReparatiePiesa { ReparatieId = 8, ProdusId = 4, Cantitate = 1, PretUnitate = 130 },
                        new ReparatiePiesa { ReparatieId = 8, ProdusId = 5, Cantitate = 1, PretUnitate = 160 },
                        new ReparatiePiesa { ReparatieId = 8, ProdusId = 6, Cantitate = 1, PretUnitate = 190 },
                        new ReparatiePiesa { ReparatieId = 8, ProdusId = 7, Cantitate = 1, PretUnitate = 210 },
                        new ReparatiePiesa { ReparatieId = 8, ProdusId = 12, Cantitate = 4, PretUnitate = 95 },

                        // Reparatie 9 - Schimb baterie (finalizata)
                        new ReparatiePiesa { ReparatieId = 9, ProdusId = 14, Cantitate = 1, PretUnitate = 1250 },

                        // Reparatie 10 - Reparatie alternator (finalizata)
                        new ReparatiePiesa { ReparatieId = 10, ProdusId = 15, Cantitate = 1, PretUnitate = 1950 },

                        // Reparatie 11 - Schimb discuri frana (finalizata)
                        new ReparatiePiesa { ReparatieId = 11, ProdusId = 10, Cantitate = 2, PretUnitate = 750 },
                        new ReparatiePiesa { ReparatieId = 11, ProdusId = 8, Cantitate = 1, PretUnitate = 480 },
                        new ReparatiePiesa { ReparatieId = 11, ProdusId = 9, Cantitate = 1, PretUnitate = 380 },

                        // Reparatie 12 - Schimb pompa apa (finalizata)
                        new ReparatiePiesa { ReparatieId = 12, ProdusId = 23, Cantitate = 1, PretUnitate = 580 },
                        new ReparatiePiesa { ReparatieId = 12, ProdusId = 1, Cantitate = 1, PretUnitate = 420 },

                        // Reparatie 13 - Schimb filtre cabina (finalizata)
                        new ReparatiePiesa { ReparatieId = 13, ProdusId = 6, Cantitate = 1, PretUnitate = 190 },

                        // Reparatie 14 - Reparatie climatronic (finalizata)
                        new ReparatiePiesa { ReparatieId = 14, ProdusId = 13, Cantitate = 2, PretUnitate = 290 },

                        // Reparatie 15 - Schimb rulmenti (finalizata)
                        new ReparatiePiesa { ReparatieId = 15, ProdusId = 22, Cantitate = 2, PretUnitate = 320 },

                        // Reparatii neincepute (se pot adauga piese cand vor incepe)

                        // Exemple de piese planificate pentru reparatii neincepute
                        new ReparatiePiesa { ReparatieId = 17, ProdusId = 3, Cantitate = 1, PretUnitate = 450 },
                        new ReparatiePiesa { ReparatieId = 17, ProdusId = 4, Cantitate = 1, PretUnitate = 130 },
                        new ReparatiePiesa { ReparatieId = 17, ProdusId = 5, Cantitate = 1, PretUnitate = 160 },

                        new ReparatiePiesa { ReparatieId = 19, ProdusId = 25, Cantitate = 2, PretUnitate = 1350 },

                        new ReparatiePiesa { ReparatieId = 21, ProdusId = 21, Cantitate = 4, PretUnitate = 900 },

                        new ReparatiePiesa { ReparatieId = 22, ProdusId = 16, Cantitate = 1, PretUnitate = 1750 },

                        new ReparatiePiesa { ReparatieId = 23, ProdusId = 24, Cantitate = 1, PretUnitate = 1050 },

                        new ReparatiePiesa { ReparatieId = 24, ProdusId = 17, Cantitate = 4, PretUnitate = 950 }
                    );
                }

                Db.SaveChanges();

            }


        }

    }

}
