using BadHabbits.DataAccess;
using BadHabbits.Layers;
using BadHabbits.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BadHabbits.Controllers
{
    [Route("habbits")]
    public class HabbitsController : Controller
    {
        readonly IHabbitsLayer _habbitsLayer;
        public HabbitsController(IHabbitsLayer habbitsLayer)
        {
            _habbitsLayer = habbitsLayer;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("catalog")]
        public IActionResult Catalog()
        {
            var cigarettes = _habbitsLayer.GetCigarettes();
            var vm = new CigaretteViewModel();
            if (cigarettes.Any())
            {
                vm.Cigarettes.AddRange(cigarettes.Select(x => new CigaretteViewModelItem(x)));
            }
            return View(vm);
        }

        [HttpGet]
        [Route("calculate/{cigaretteId}")]
        public IActionResult Calculate([FromRoute] Guid cigaretteId)
        {
            var cigarettes = _habbitsLayer.GetCigarettes();
            var vm = new CalculateViewModel();
            if (cigarettes.Any())
            {
                var cigarette = cigarettes.FirstOrDefault(x => x.CigaretteId == cigaretteId);
                vm = new CalculateViewModel()
                {
                    CigaretteId = cigarette.CigaretteId,
                    Brand = cigarette.Brand,
                    Name = cigarette.Name,
                    WithFilter = cigarette.WithFilter,
                    NicotineAmount = cigarette.NicotineAmount,
                    TarAmount = cigarette.TarAmount,
                    Price = cigarette.Price
                };
            }
            return View(vm);
        }

        [HttpGet]
        [Route("image/{cigaretteId}")]
        public IActionResult GetImage([FromRoute] Guid cigaretteId)
        {
            var image = _habbitsLayer.GetCigaretteImage(cigaretteId);
            if (image != null)
            {
                return File(image, "image/jpeg");
            }
            else
            {
                return Content("Image not found");
            }
        }
    }
}
