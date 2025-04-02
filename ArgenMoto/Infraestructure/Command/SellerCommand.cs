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
    public class SellerCommand : ISellerCommand
    {
        private readonly AppDBContext _context;
        public SellerCommand(AppDBContext context)
        {
            _context = context;
        }
        public async Task<string> InsertVendedor(Seller seller)
        {
            try
            {
                _context.Add(seller);
                _context.SaveChangesAsync();
                return seller.SellerId.ToString();
            }
            catch (DbUpdateException)
            {
                throw new ExceptionConflict("Error en la base de datos: Problema en añadir el Vendedor");
            }
        }
    }
}
