using AutoserviceMI.Detalii;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoserviceMI
{
    public class Programare
    {
        public int Id { get; set; }

        [Required]
        public DateTime DataProgramare { get; set; }

        [Required]
        [MaxLength(100)]
        public string TipInterventie { get; set; }

        [MaxLength(50)]
        public string Mecanic { get; set; }

        [Required]
        public string Stare { get; set; } 

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int VehiculId { get; set; }
        public Vehicul Vehicul { get; set; }
    }
}
