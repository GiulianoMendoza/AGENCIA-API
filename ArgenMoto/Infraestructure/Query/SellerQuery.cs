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
    public class SellerQuery : ISellerQuery
    {
        private readonly AppDBContext _context;
        public SellerQuery(AppDBContext DBcontext)
        {
            this._context = DBcontext;
        }
        public async Task<Seller> GetSellerById(Guid sellerId)
        {
            try
            {
                return await _context.Sellers.SingleOrDefaultAsync(p => p.SellerId == sellerId);

            }
            catch (DbUpdateException)
            {
                throw new ExceptionConflict("Problema al encontrar el Vendedor");
            }
        }
    }
}
