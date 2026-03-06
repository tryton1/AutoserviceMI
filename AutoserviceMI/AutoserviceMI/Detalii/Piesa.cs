using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoserviceMI.Detalii
{
    public class Piesa
    {
        public int Id { get; set; }
        public string CodPiesa { get; set; }
        public string Denumire { get; set; }
        public string Producator { get; set; }
        public decimal Pret { get; set; }
        public int Stoc { get; set; }
        public int StocMinim { get; set; }
    }

}
