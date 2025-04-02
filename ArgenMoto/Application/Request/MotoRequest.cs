using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Request
{
    public class MotoRequest
    {
        public string motoName { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public string mark { get; set; }
        public string model { get; set; }
        public int cylinder { get; set; }
        public int category { get; set; }
        public string imageUrl { get; set; }
        public int discount { get; set; }
    }
}
