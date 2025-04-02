using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public class SellerResponse
    {
        public Guid SellerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Dni { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
    }
}
