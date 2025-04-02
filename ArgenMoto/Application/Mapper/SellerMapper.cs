using Application.Interfaces;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper
{
    public class SellerMapper : ISellerMapper
    {
        public SellerMapper()
        {

        }

        public async Task<SellerResponse> GenerateSellerResponse(Seller newSeller)
        {
            return new SellerResponse
            {
                SellerId = newSeller.SellerId,
                Name = newSeller.Name,
                Surname = newSeller.Surname,
                Dni = newSeller.Dni,
                Phone = newSeller.Phone,
                Email = newSeller.Email
            };
        }
    }
}
