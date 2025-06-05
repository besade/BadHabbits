using BadHabbits.DataAccess.Models;

namespace BadHabbits.Layers
{
    public interface IHabbitsLayer
    {
        List<Cigarette> GetCigarettes();

        void DeleteCigarette(Guid cigaretteId);
        void AddCigarette(Cigarette cigarette);
        byte[] GetCigaretteImage(Guid cigaretteId);
    }
}
