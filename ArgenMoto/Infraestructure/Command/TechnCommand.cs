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
    public class TechnCommand : ITechnCommand
    {
        private readonly AppDBContext _context;
        public TechnCommand(AppDBContext context)
        {
            _context = context;
        }
        public async Task<string> InsertTecnico(Techn tech)
        {
            try
            {
                _context.Add(tech);
                _context.SaveChangesAsync();
                return tech.TecnicoId.ToString();
            }
            catch (DbUpdateException)
            {
                throw new ExceptionConflict("Error en la base de datos: Problema en añadir el Tecnico");
            }
        }
    }
}
