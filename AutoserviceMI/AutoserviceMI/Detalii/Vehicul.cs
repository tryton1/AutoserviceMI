using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoserviceMI.Detalii
{
    public class Vehicul
    {
        public int Id { get; set; }
        public string NumarInmatriculare { get; set; }
        public string Marca { get; set; }
        public string Model { get; set; }
        public string VIN { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public override string ToString()
        {
            return $"{Marca} {Model} - {NumarInmatriculare}";
        }
    }
}
