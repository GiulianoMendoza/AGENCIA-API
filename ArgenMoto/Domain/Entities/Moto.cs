using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Moto
    {
        public Guid MotoId { get; set; }
        public string MotoName { get; set; }
        public string Description { get; set; }
        public int StockMin {  get; set; }
        public int StockMax { get; set;}
        public int StockCurrent {  get; set; }
        public double Price { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public int EngineNum { get; set; }
        public int ChasisNum { get; set; }
        public DateTime Age { get; set; }
        public int Cylinder {  get; set; }
        public string imageUrl { get; set; }
        public int Discount { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<SaleMoto> SaleMotos { get; set; }
    }
}
