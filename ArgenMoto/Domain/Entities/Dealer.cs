using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Dealer
    {
        public Guid dealerID {  get; set; }
        public int Cuit {  get; set; }
        public string ReasonSocial { get; set; }
        public string Surname { get; set; }
        public string NameProv {  get; set; }
        public string Addres { get; set; }
        public string Locality { get; set; }
        public string Province { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
    }
}
