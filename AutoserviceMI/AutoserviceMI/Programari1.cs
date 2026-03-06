using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoserviceMI
{
    public class Programari1
    {
        public DateTime oraData { get; set; }
        public string nume { get; set; }
        public string numarTelefon { get; set; }
        public string modelAutomobil { get; set; }
        public int anFabricare { get; set; }

        public Programari1(DateTime oraData, string nume, string numarTelefon, string modelAutomobil, int anFabricare)
        {
            this.oraData = oraData;
            this.nume = nume;
            this.numarTelefon = numarTelefon;
            this.modelAutomobil = modelAutomobil;
            this.anFabricare = anFabricare;
        }
    }
}

