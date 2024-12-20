﻿using BodegaVinos.Data;
using BodegaVinos.Entities;
using BodegaVinos.Interfaces.Respository;
using Microsoft.EntityFrameworkCore;

namespace BodegaVinos.Repositories
{
    public class WineRepository : IWineRepository
    {
        private readonly BodegaContext _context;

        public WineRepository(BodegaContext context)
        {
            _context = context;
        }

        public IEnumerable<Wine> GetAll()
        {
            return _context.Wines.ToList();
        }

        public Wine GetById(int id)
        {
            return _context.Wines
                .FirstOrDefault(w => w.Id == id);
        }

        public IEnumerable<Wine> GetWineByVariety(string variety)
        {
            return _context.Wines
                .Where(w => w.Variety.ToLower() == variety.ToLower() && w.Stock > 0)
                .ToList();
        }

        public void Add(Wine wine)
        {
            _context.Wines.Add(wine);
            _context.SaveChanges();
        }

        public void Update(Wine wine)
        {
            var existingWine = _context.Wines.Find(wine.Id);
            if (existingWine != null)
            {
                _context.Entry(existingWine).CurrentValues.SetValues(wine);
                _context.SaveChanges();
            }
        }

        public Wine UpdateStockById(int id, int newStock)
        {
            var wine = _context.Wines.Find(id);
            if (wine != null)
            {
                wine.Stock = newStock;
                _context.SaveChanges();
            }

            return wine;
        }

        public void Delete(int id)
        {
            var wine = _context.Wines.Find(id);
            if (wine != null)
            {
                _context.Wines.Remove(wine);
                _context.SaveChanges();
            }
        }
    }
}