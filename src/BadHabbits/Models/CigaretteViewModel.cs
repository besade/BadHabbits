namespace BadHabbits.Models
{
    public class CigaretteViewModel
    {
        public CigaretteViewModel() 
        {
            Cigarettes = new List<CigaretteViewModelItem>();
        }
        public List<CigaretteViewModelItem> Cigarettes { get; set; }
    }
}
