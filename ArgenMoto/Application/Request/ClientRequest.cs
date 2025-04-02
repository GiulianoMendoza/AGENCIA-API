using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Request
{
    public class ClientRequest
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public int phone { get; set; }
        public int dni { get; set; }
        public string addres { get; set; }
        public string locality { get; set; }
        public string province { get; set; }
    }
}
