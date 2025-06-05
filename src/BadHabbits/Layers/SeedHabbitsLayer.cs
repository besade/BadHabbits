using BadHabbits.DataAccess.Models;

namespace BadHabbits.Layers
{
    public class SeedHabbitsLayer : IHabbitsLayer
    {
        public SeedHabbitsLayer()
        {
            
        }


        public List<Cigarette> GetCigarettes()
        {
            return new List<Cigarette>()
            {
                new Cigarette()
                {
                    Brand = "Bond",
                    Name = "Blue"
                }
            };
        }

        public void DeleteCigarette(Guid cigaretteId)
        {
            throw new NotImplementedException();
        }

        public void AddCigarette(Cigarette cigarette)
        {
            throw new NotImplementedException();
        }

        public byte[] GetCigaretteImage(Guid cigaretteId)
        {
            throw new NotImplementedException();
        }
    }
}
