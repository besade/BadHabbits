using System.ComponentModel.DataAnnotations;
using BadHabbits.DataAccess.Models;

namespace BadHabbits.Models
{
    public class CigaretteViewModelItem
    {
        public CigaretteViewModelItem() { }
        public CigaretteViewModelItem(Cigarette cigarette)
        {
            CigaretteId = cigarette.CigaretteId;
            Brand = cigarette.Brand;
            Name = cigarette.Name;
            WithFilter = cigarette.WithFilter;
            NicotineAmount = cigarette.NicotineAmount;
            TarAmount = cigarette.TarAmount;
            Price = cigarette.Price;
        }

        public Guid CigaretteId { get; set; }

        [Required]
        [Length(1, 50)]
        public string Brand { get; set; }
        public string Name { get; set; }
        public bool WithFilter { get; set; }
        public float NicotineAmount { get; set; }
        public int TarAmount { get; set; }
        public float Price { get; set; }
        public IFormFile Picture { get; set; }
    }
}
