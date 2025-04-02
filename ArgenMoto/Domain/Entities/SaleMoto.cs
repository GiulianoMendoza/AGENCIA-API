using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SaleMoto
    {
        public int ShoppingCartId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public int Sale { get; set; }
        public Guid Mot { get; set; }
        public Moto Moto { get; set; }
        public Sale Venta { get; set; }
    }
}
