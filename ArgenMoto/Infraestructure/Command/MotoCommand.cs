using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Command
{
    public class MotoCommand : IMotoCommand
    {
        private readonly AppDBContext _context;
        public MotoCommand(AppDBContext context)
        {
            _context = context;
        }
        public async Task<string> InsertProduct(Moto moto)
        {
            try
            {
                _context.Add(moto);
                _context.SaveChangesAsync();
                return moto.MotoId.ToString();
            }
            catch (DbUpdateException)
            {
                throw new ExceptionConflict("Error en la base de datos: Problema en añadir el producto");
            }
        }
        public async Task<Moto> UpdateProduct(Guid MotoId, MotoRequest moto)
        {
            try
            {
                var MotoUpdate = await _context.Moto.FirstOrDefaultAsync(p => p.MotoId == MotoId);
                MotoUpdate.MotoName = moto.motoName;
                MotoUpdate.Description = moto.description;
                MotoUpdate.Price = moto.price;
                MotoUpdate.Discount = moto.discount;
                MotoUpdate.imageUrl = moto.imageUrl;
                MotoUpdate.CategoryId = moto.category;
                await _context.SaveChangesAsync();
                return MotoUpdate;
            }
            catch (DbUpdateException)
            {
                throw new ExceptionConflict("Problema al modificar la moto");
            }
        }
        public async Task<Moto> DeleteProduct(Guid id)
        {
            try
            {

                var motoDelete = await _context.Moto.FirstOrDefaultAsync(p => p.MotoId == id);
                if (motoDelete == null)
                {
                    throw new ExceptionNotFound("La Moto con ID " + id + " no fue encontrada.");
                }
                _context.Moto.Remove(motoDelete);
                await _context.SaveChangesAsync();
                return motoDelete;
            }
            catch (DbUpdateException)
            {
                throw new ExceptionConflict("Problema al Eliminar la moto");
            }
        }
    }
}
