using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public class SaleMotoResponse
    {
        public int SaleId { get; set; }
        public Guid motoId { get; set; }
        public int Quantity { get; set; }
        public double price { get; set; }
        public int discount { get; set; }
    }
}
