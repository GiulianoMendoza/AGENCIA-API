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
    public class TurnQuery : ITurnQuery
    {
            private readonly AppDBContext _context;
            public TurnQuery(AppDBContext DBcontext)
            {
                this._context = DBcontext;
            }
            public async Task<List<Turn>> GetAll()
            {
                try
                {
                    List<Turn> turns = await _context.Turns
                        .Include(p => p.Moto)
                        .Include(p => p.client)
                        .Include(p => p.techn)
                        .Include(p => p.sale)
                        .ToListAsync();
                    return turns;
                }
                catch (DbUpdateException)
                {
                    throw new ExceptionSintaxError("Error en la BD, Problemas para obtener los turnos");
                }

            }
            public async Task<Turn> GetTurnById(int turnId)
            {
                try
                {
                    return await _context.Turns
                        .Include(p => p.Moto)
                        .Include(p => p.client)
                        .Include(p => p.techn)
                        .Include(p => p.sale)
                        .SingleOrDefaultAsync(p => p.TurnId == turnId);

                }
                catch (DbUpdateException)
                {
                    throw new ExceptionConflict("Problema al encontrar el turno");
                }
            }
     }
}
