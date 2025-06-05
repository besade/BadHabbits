namespace BadHabbits.DataAccess.Models
{
    public class Cigarette
    {
        public Guid CigaretteId { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public bool WithFilter { get; set; }
        public float NicotineAmount { get; set; }
        public int TarAmount { get; set; }
        public float Price { get; set; }
        public byte[]? Picture { get; set; }
    }
}
