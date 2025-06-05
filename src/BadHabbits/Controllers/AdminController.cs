using System.IO;
using BadHabbits.Layers;
using BadHabbits.Models;
using Microsoft.AspNetCore.Mvc;

namespace BadHabbits.Controllers
{
    public class AdminController : Controller
    {
        readonly IHabbitsLayer _habbitsLayer;
        public AdminController(IHabbitsLayer habbitsLayer)
        {
            _habbitsLayer = habbitsLayer;
        }

        [HttpGet]
        public IActionResult Cigarette()
        {
            return View(new CigaretteViewModelItem());
        }

        [HttpPost]
        public IActionResult Cigarette(CigaretteViewModelItem cigaretteViewModel)
        {
            if (cigaretteViewModel != null)
            {
                using var memoryStream = new MemoryStream();
                cigaretteViewModel.Picture.CopyToAsync(memoryStream).GetAwaiter().GetResult();
                byte[] fileBytes = memoryStream.ToArray();
                _habbitsLayer.AddCigarette(new DataAccess.Models.Cigarette()
                {
                    CigaretteId = Guid.NewGuid(),
                    Brand = cigaretteViewModel.Brand,
                    Name = cigaretteViewModel.Name,
                    WithFilter = cigaretteViewModel.WithFilter,
                    NicotineAmount = cigaretteViewModel.NicotineAmount,
                    TarAmount = cigaretteViewModel.TarAmount,
                    Price = cigaretteViewModel.Price,
                    Picture = fileBytes
                }
                );
            }
            return RedirectToAction("Catalog", "Habbits");
        }

    }
}
