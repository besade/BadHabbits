using System.ComponentModel.DataAnnotations;

namespace BadHabbits.Models
{
    public class CalculateViewModel
    {
        public Guid CigaretteId { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public bool WithFilter { get; set; }
        public float NicotineAmount { get; set; }
        public int TarAmount { get; set; }
        public float Price { get; set; }


        public int CigarettesPerDay { get; set; }
        public float TotalSumPerDay { get; set; }
        public float TotalSumPerWeek { get; set; }
        public float TotalSumPerMonth { get; set; }
        public float TotalSumPerHalfYear { get; set; }
        public float TotalSumPerYear { get; set; }
    }
}
