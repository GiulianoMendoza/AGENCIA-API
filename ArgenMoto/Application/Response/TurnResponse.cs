using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public class TurnResponse
    {
        public DateTime Date { get; set; }
        public string TypeService { get; set; }
        public string Status { get; set; }
        public int TurnId { get; set; }
        public Guid Techn { get; set; }
        public Guid Moto { get; set; }
        public int Sale { get; set; }
        public Guid Client { get; set; }
    }
}
