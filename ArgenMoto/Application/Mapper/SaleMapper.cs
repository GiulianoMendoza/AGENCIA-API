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
    public class SaleMapper : ISaleMapper
    {
        public SaleMapper()
        {
        }
        public async Task<SaleResponse> GenerateSaleResponse(Sale newSale)
        {
            SaleResponse response = new SaleResponse
            {
                id = newSale.SaleId,
                totalPay = (double)newSale.TotalPay,
                subtotal = (double)newSale.Subtotal,
                totalDiscount = (double)newSale.TotalDiscount,
                taxes = (double)newSale.Taxes,
                date = newSale.Date,
                mots = new List<SaleMotoResponse>()
            };
            foreach (var saleProduct in newSale.SaleMotos)
            {
                response.mots.Add(new SaleMotoResponse
                {
                    SaleId = saleProduct.Sale,
                    motoId = saleProduct.Mot,
                    Quantity = saleProduct.Quantity,
                    price = (double)saleProduct.Price,
                    discount = saleProduct.Discount,
                });
            }
            response.totalQuantity = response.mots.Sum(p => p.Quantity);
            return response;
        }
        public async Task<SaleGetResponse> GetSale(Sale newSale)
        {
            int totalQuantity = newSale.SaleMotos.Sum(sp => sp.Quantity);
            return new SaleGetResponse
            {
                id = newSale.SaleId,
                totalPay = (double)newSale.TotalPay,
                totalQuantity = totalQuantity,
                date = newSale.Date
            };
        }
    }
}
