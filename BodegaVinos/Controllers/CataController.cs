using BodegaVinos.Entities;
using BodegaVinos.DTOs;
using BodegaVinos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BodegaVinos.Interfaces.Services;

namespace BodegaVinos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CataController : ControllerBase
    {
        private readonly ICataService _cataService;
        private readonly IWineService _wineService;

        public CataController(ICataService cataService, IWineService wineService)
        {
            _cataService = cataService;
            _wineService = wineService;
        }

        [HttpGet]
        public IActionResult GetCatasFuturas(DateTime fechaActual)
        {
            var catas = _cataService.GetAllCatasDisp()
                .Where(c => c.Date > fechaActual)
                .Select(cata => new CataResponseDto
                {
                    Id = cata.Id,
                    Date = cata.Date,
                    Name = cata.Name,
                    GuestList = cata.GuestList,
                    Wines = cata.Wines.Select(wine => new WineResponseDto
                    {
                        Id = wine.Id,
                        Name = wine.Name,
                        Variety = wine.Variety,
                        Year = wine.Year,
                        Region = wine.Region,
                        Stock = wine.Stock,
                        CreatedAt = wine.CreatedAt
                    }).ToList()
                })
                .ToList();

            return Ok(catas);
        }

        [HttpPost]
        public IActionResult CreateCata([FromBody] CataCreateDto cataDto)
        {
            var cata = new Cata
            {
                Date = cataDto.Date,
                Name = cataDto.Name,
                GuestList = cataDto.GuestList,
                Wines = cataDto.WineIds.Select(wineId => _wineService.GetWineById(wineId)).ToList()
            };

            _cataService.CreateCata(cata);

            var responseDto = new CataResponseDto
            {
                Id = cata.Id,
                Date = cata.Date,
                Name = cata.Name,
                GuestList = cata.GuestList,
                Wines = cata.Wines.Select(wine => new WineResponseDto
                {
                    Id = wine.Id,
                    Name = wine.Name,
                    Variety = wine.Variety,
                    Year = wine.Year,
                    Region = wine.Region,
                    Stock = wine.Stock,
                    CreatedAt = wine.CreatedAt
                }).ToList()
            };

            return Ok(responseDto);
        }

        [HttpPut]
        public IActionResult UpdateCata(int id, [FromBody] CataCreateDto cataDto)
        {
            var cataExistente = _cataService.GetAllCatasDisp()
                .FirstOrDefault(c => c.Id == id);

            if (cataExistente == null)
            {
                return NotFound($"No quedan Catas Pendientes");
            }

            if (cataDto.Date < DateTime.Now)
            {
                return BadRequest("La fecha de la cata debe ser futura");
            }

            cataExistente.Date = cataDto.Date;
            cataExistente.Name = cataDto.Name;
            cataExistente.GuestList = cataDto.GuestList;
            cataExistente.Wines = cataDto.WineIds.Select(wineId => _wineService.GetWineById(wineId)).ToList();

            _cataService.UpdateCata(cataExistente);

            var responseDto = new CataResponseDto
            {
                Id = cataExistente.Id,
                Date = cataExistente.Date,
                Name = cataExistente.Name,
                GuestList = cataExistente.GuestList,
                Wines = cataExistente.Wines.Select(wine => new WineResponseDto
                {
                    Id = wine.Id,
                    Name = wine.Name,
                    Variety = wine.Variety,
                    Year = wine.Year,
                    Region = wine.Region,
                    Stock = wine.Stock,
                    CreatedAt = wine.CreatedAt
                }).ToList()
            };

            return Ok(responseDto);
        }
    }
}