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

namespace Infraestructure.Command
{
    public class SaleMotoCommand : ISaleMotoCommand
    {
        private readonly AppDBContext _context;
        public SaleMotoCommand(AppDBContext context)
        {
            this._context = context;
        }
        public async Task<SaleMoto> insertSM(SaleMoto saleMoto)
        {
            try
            {
                _context.Add(saleMoto);
                await _context.SaveChangesAsync();
                return saleMoto;
            }
            catch (DbUpdateException ex)
            {
                throw new ExceptionNotFound("No se pudo registrar un SaleMoto: " + ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}
