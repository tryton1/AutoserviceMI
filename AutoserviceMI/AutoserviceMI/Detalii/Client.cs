using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoserviceMI.Detalii
{
    public class Client
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Telefon { get; set; }
        public string Oras { get; set; }

        public Client (string nume, string prenume, string telefon, string oras) 
        {
            this.Nume = nume;
            this.Prenume = prenume;
            this.Telefon = telefon;
            this.Oras = oras;
        }

        public Client()
        {

        }

        public override string ToString()
        {
            return $"{Nume} {Prenume}";
        }
    }
}
