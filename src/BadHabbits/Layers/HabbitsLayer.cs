using BadHabbits.DataAccess;
using BadHabbits.DataAccess.Models;

namespace BadHabbits.Layers
{
    public class HabbitsLayer : IHabbitsLayer
    {
        readonly BadHabbitsDbContext _context;
        public HabbitsLayer(BadHabbitsDbContext context)
        {
            _context = context;
        }

        public List<Cigarette> GetCigarettes()
        {
            return _context.Cigarettes.ToList();
        }

        public void DeleteCigarette(Guid cigaretteId)
        {
            var cigarette = _context.Cigarettes.FirstOrDefault(c => c.CigaretteId == cigaretteId);
            if (cigarette != null)
            {
                _context.Cigarettes.Remove(cigarette);
                _context.SaveChanges();
            }
        }
        
        public void AddCigarette(Cigarette cigarette)
        {
            _context.Cigarettes.Add(cigarette);
            _context.SaveChanges();
        }
        
        public byte[] GetCigaretteImage(Guid cigaretteId)
        {
            return _context.Cigarettes.FirstOrDefault(x => x.CigaretteId == cigaretteId)?.Picture;
        }
    }
    
}
