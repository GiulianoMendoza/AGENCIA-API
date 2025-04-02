using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Buy
    {
        public int OrderbuyId { get; set; }
        public int Quantity {  get; set; }
        public decimal TotalPay { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Taxes { get; set; }
        public string Description { get; set; }
        public DateTime DateStar { get; set; }
        public DateTime DateEnd { get; set; }
        public ICollection<SaleMoto> SaleMotos { get; set; }

    }
}
