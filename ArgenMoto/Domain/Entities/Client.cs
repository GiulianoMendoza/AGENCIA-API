using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Client
    {
        public Guid ClientId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int Dni { get; set; }
        public int Phone {  get; set; }
        public string Addres { get; set; }
        public string Locality { get; set; }
        public string Province { get; set; }
    }
}
