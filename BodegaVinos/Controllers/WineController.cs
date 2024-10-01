using BodegaVinos.Entities;
using BodegaVinos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BodegaVinos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WineController : ControllerBase
    {
        private readonly IWineService _wineService;

        public WineController(IWineService wineService)
        {
            _wineService = wineService;
        }

        [HttpPost]
        public IActionResult RegisterWine([FromBody] Wine wine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _wineService.AddWine(wine);
            return CreatedAtAction(nameof(GetWine), new { id = wine.Id }, wine);
        }

        [HttpGet]
        public IActionResult GetInventory()
        {
            var wines = _wineService.GetAllWines();
            return Ok(wines);
        }

        [HttpGet("{id}")]
        public IActionResult GetWine(int id)
        {
            var wine = _wineService.GetWineById(id);
            if (wine == null)
            {
                return NotFound();
            }
            return Ok(wine);
        }
    }
}
