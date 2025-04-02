using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Request
{
    public class TurnRequest
    {
        public DateTime Date { get; set; }
        public string TypeService { get; set; }
        public string Status { get; set; }
        public Guid Client { get; set; }
        public Guid Techn { get; set; }
        public Guid Motoid { get; set; }
        public int Sale { get; set; }
    }
}
