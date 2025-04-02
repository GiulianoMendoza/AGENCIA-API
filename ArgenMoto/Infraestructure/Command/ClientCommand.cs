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
    public class ClientCommand : IClientCommand
    {
        private readonly AppDBContext _context;
        public ClientCommand(AppDBContext context)
        {
            _context = context;
        }
        public async Task<string> InsertClient(Client cliente)
        {
            try
            {
                _context.Add(cliente);
                _context.SaveChangesAsync();
                return cliente.ClientId.ToString();
            }
            catch (DbUpdateException)
            {
                throw new ExceptionConflict("Error en la base de datos: Problema en añadir el Cliente");
            }
        }
    }
}
