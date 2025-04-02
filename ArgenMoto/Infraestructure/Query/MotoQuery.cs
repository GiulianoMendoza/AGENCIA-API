using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Query
{
    public class MotoQuery : IMotoQuery
    {
        private readonly AppDBContext _context;
        public MotoQuery(AppDBContext DBcontext)
        {
            this._context = DBcontext;
        }
        public async Task<List<Moto>> GetAll()
        {
            try
            {
                List<Moto> motos = await _context.Moto
                    .Include(p => p.Category)
                    .Include(p => p.SaleMotos)
                    .ToListAsync();
                return motos;
            }
            catch (DbUpdateException)
            {
                throw new ExceptionSintaxError("Error en la BD, Problemas para obtener las motos");
            }

        }
        public async Task<List<Moto>> GetMotoByCategory(int categoryId)
        {
            try
            {
                List<Moto> motos = await _context.Moto
                    .Include(p => p.Category)
                    .Include(p => p.SaleMotos)
                    .Where(p => p.Category.CategoryId == categoryId)
                    .ToListAsync();
                return motos;


            }
            catch (DbUpdateException)
            {
                throw new ExceptionConflict("Categoria no encontrada");
            }
        }
        public async Task<List<Moto>> GetMotoByName(string name)
        {
            try
            {
                List<Moto> motos = await _context.Moto
                    .Include(p => p.Category)
                    .Include(p => p.SaleMotos)
                    .Where(p => p.MotoName.Contains(name))
                    .ToListAsync();
                return motos;
            }
            catch (DbUpdateException)
            {
                throw new ExceptionConflict("Nombre no encontrado");
            }
        }
        public async Task<List<Moto>> GetMotoPaged(int limit, int offset)
        {
            try
            {
                List<Moto> motos = await _context.Moto
                .Include(p => p.Category)
                .Include(p => p.SaleMotos)
                .Skip(offset)
                .Take(limit)
                .ToListAsync();
                return motos;
            }
            catch (DbUpdateException)
            {
                throw new ExceptionConflict("No se pudo filtrar");
            }
        }
        public async Task<Moto> GetMotoById(Guid MotoId)
        {
            try
            {
                return await _context.Moto
                    .Include(p => p.Category)
                    .Include(p => p.SaleMotos)
                    .SingleOrDefaultAsync(p => p.MotoId == MotoId);

            }
            catch (DbUpdateException)
            {
                throw new ExceptionConflict("Problema al encontrar la moto");
            }
        }
        public async Task<double> GetPriceById(Guid MotoId)
        {
            var price = await _context.Moto
                .Where(p => p.MotoId == MotoId)
                .Select(p => p.Price)
                .FirstOrDefaultAsync();
            if (price == default(double))
            {
                throw new ExceptionNotFound("                                            Moto no encontrada                                           ");
            }
            return price;
        }
        public async Task<int> GetDiscountById(Guid MotoId)
        {
            var discount = await _context.Moto
                .Where(p => p.MotoId == MotoId)
                .Select(p => p.Discount)
                .FirstOrDefaultAsync();
            if (discount == default(int))
            {
                return 0;
            }
            return discount;
        }
        public async Task<Category> GetCategoriaById(int categoryId)
        {

            var categoria = await _context.Category.FindAsync(categoryId);
            return categoria;
        }

    }
}
