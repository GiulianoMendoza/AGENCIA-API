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
    public class ClientQuery : IClientQuery
    {
        private readonly AppDBContext _context;
        public ClientQuery(AppDBContext DBcontext)
        {
            this._context = DBcontext;
        }
        public async Task<Client> GetClientById(Guid clientId)
        {
            try
            {
                return await _context.Clients.SingleOrDefaultAsync(p => p.ClientId == clientId);

            }
            catch (DbUpdateException)
            {
                throw new ExceptionConflict("Problema al encontrar el cliente");
            }
        }
        public async Task<List<Client>> GetAll()
        {
            try
            {
                List<Client> clients = await _context.Clients.ToListAsync();
                return clients;
            }
            catch (DbUpdateException)
            {
                throw new ExceptionSintaxError("Error en la BD, problemas para obtener los clientes.");
            }
        }
    }
}
