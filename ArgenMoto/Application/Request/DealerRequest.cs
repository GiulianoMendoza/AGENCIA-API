using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Request
{
    public class DealerRequest
    {
        public int cuit { get; set; }
        public string reasonSocial { get; set; }
        public string surname { get; set; }
        public string nameProv { get; set; }
        public string addres { get; set; }
        public string locality { get; set; }
        public string province { get; set; }
        public int phone { get; set; }
        public string email { get; set; }

    }
}
