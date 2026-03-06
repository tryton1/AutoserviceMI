using AutoserviceMI.Detalii;
using System;
using System.Collections.Generic;

public class Reparatie
{
    public int Id { get; set; }

    public int ClientId { get; set; }
    public Client Client { get; set; }

    public int VehiculId { get; set; }
    public Vehicul Vehicul { get; set; }

    public string Status { get; set; }
    public string TipInterventie { get; set; }
    public string Mecanic { get; set; }
    public string Descriere { get; set; }

    public DateTime DataStart { get; set; }
    public DateTime? DataFinalizare { get; set; }

    public decimal CostEstimat { get; set; }
    public decimal CostTotalPiese { get; set; }
    public decimal CostTotal { get; set; }

    public ICollection<ReparatiePiesa> PieseFolosite { get; set; }
}
