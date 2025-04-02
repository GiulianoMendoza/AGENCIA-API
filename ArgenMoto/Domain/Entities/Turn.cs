using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Turn
    {
        public int TurnId { get; set; }
        public Guid ClientId { get; set; }
        public Guid TechnId { get; set; }
        public Guid Motoid { get; set; }
        public int SaleId { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public string TypeService { get; set; }
        
        public Moto Moto { get; set; }
        public Client client { get; set; }
        public Techn techn { get; set; }
        public Sale sale { get; set; }

    }
}
