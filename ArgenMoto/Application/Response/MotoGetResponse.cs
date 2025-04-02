using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public class MotoGetResponse
    {
        public Guid MotoId { get; set; }
        public string motoName { get; set; }
        public double price { get; set; }
        public string mark { get; set; }
        public string model { get; set; }
        public int cylinder { get; set; }
        public int discount { get; set; }
        public string categoryname { get; set; }
        public string imageUrl { get; set; }
    }
}
