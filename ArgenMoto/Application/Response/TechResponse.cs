using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public class TechResponse
    {
        public Guid TechId { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int dni { get; set; }
        public string addres { get; set; }
        public int phone { get; set; }
        public string email { get; set; }
    }
}
