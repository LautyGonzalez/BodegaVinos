using BodegaVinos.Entities;
using BodegaVinos.DTOs;
using BodegaVinos.Interfaces.Services;
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
        public IActionResult RegisterWine([FromBody] WineCreateDto wineDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var wine = new Wine
            {
                Name = wineDto.Name,
                Variety = wineDto.Variety,
                Year = wineDto.Year,
                Region = wineDto.Region,
                Stock = wineDto.Stock
            };

            _wineService.AddWine(wine);

            var responseDto = new WineResponseDto
            {
                Id = wine.Id,
                Name = wine.Name,
                Variety = wine.Variety,
                Year = wine.Year,
                Region = wine.Region,
                Stock = wine.Stock,
                CreatedAt = wine.CreatedAt
            };

            return CreatedAtAction(nameof(GetWine), new { id = wine.Id }, responseDto);
        }

        [HttpGet]
        public IActionResult GetInventory()
        {
            var wines = _wineService.GetAllWines();
            var wineDtos = wines.Select(wine => new WineResponseDto
            {
                Id = wine.Id,
                Name = wine.Name,
                Variety = wine.Variety,
                Year = wine.Year,
                Region = wine.Region,
                Stock = wine.Stock,
                CreatedAt = wine.CreatedAt
            });
            return Ok(wineDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetWine(int id)
        {
            var wine = _wineService.GetWineById(id);
            if (wine == null)
            {
                return NotFound();
            }
            var wineDto = new WineResponseDto
            {
                Id = wine.Id,
                Name = wine.Name,
                Variety = wine.Variety,
                Year = wine.Year,
                Region = wine.Region,
                Stock = wine.Stock,
                CreatedAt = wine.CreatedAt
            };
            return Ok(wineDto);
        }

        [HttpGet]
        [Route("GetByVariety")]
        public IActionResult GetWineByVariety(string Variety)
        {
            var wines = _wineService.GetWineByVariety(Variety);
            if (wines == null || !wines.Any())
            {
                return NotFound();
            }
            var wineDtos = wines.Select(wine => new WineResponseDto
            {
                Id = wine.Id,
                Name = wine.Name,
                Variety = wine.Variety,
                Year = wine.Year,
                Region = wine.Region,
                Stock = wine.Stock,
                CreatedAt = wine.CreatedAt
            });
            return Ok(wineDtos);
        }

        [HttpPut]
        public IActionResult UpdateStockById(int id, int newStock)
        {
            var wine = _wineService.UpdateStockById(id, newStock);
            if (wine == null)
            {
                return NotFound();
            }
            var wineDto = new WineResponseDto
            {
                Id = wine.Id,
                Name = wine.Name,
                Variety = wine.Variety,
                Year = wine.Year,
                Region = wine.Region,
                Stock = wine.Stock,
                CreatedAt = wine.CreatedAt
            };
            return Ok(wineDto);
        }
    }
}