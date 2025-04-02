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
    public class TechnQuery : ITechnQuery
    {
        private readonly AppDBContext _context;
        public TechnQuery(AppDBContext DBcontext)
        {
            this._context = DBcontext;
        }
        public async Task<Techn> GetTechById(Guid techId)
        {
            try
            {
                return await _context.Techns.SingleOrDefaultAsync(p => p.TecnicoId == techId);

            }
            catch (DbUpdateException)
            {
                throw new ExceptionConflict("Problema al encontrar el Tecnico");
            }
        }
        public async Task<List<Techn>> GetAll()
        {
            try
            {
                List<Techn> techs = await _context.Techns.ToListAsync();
                return techs;
            }
            catch (DbUpdateException)
            {
                throw new ExceptionSintaxError("Error en la BD, problemas para obtener los técnicos.");
            }
        }
    }
}
