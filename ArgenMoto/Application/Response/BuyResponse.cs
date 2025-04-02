using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public class BuyResponse
    {
        public Dealer dealer { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPay { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Taxes { get; set; }
        public DateTime DateStar { get; set; }
        public DateTime DateEnd { get; set; }
        public List<MotoGetResponse> mots { get; set; }
    }
}
