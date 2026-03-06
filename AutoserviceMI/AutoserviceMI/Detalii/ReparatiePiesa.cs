namespace AutoserviceMI.Detalii
{
    public class ReparatiePiesa
    {
        public int Id { get; set; }

        public int ReparatieId { get; set; }
        public Reparatie Reparatie { get; set; }

        public int ProdusId { get; set; }
        public Produs Produs { get; set; }

        public int Cantitate { get; set; }
        public decimal PretUnitate { get; set; }
    }
}
