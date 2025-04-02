using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMotoQuery
    {
        Task<List<Moto>> GetAll();
        Task<List<Moto>> GetMotoByCategory(int categoryId);
        Task<List<Moto>> GetMotoByName(string name);
        Task<List<Moto>> GetMotoPaged(int limit, int offset);
        Task<Moto> GetMotoById(Guid MotoId);
        Task<int> GetDiscountById(Guid MotoId);
        Task<double> GetPriceById(Guid MotoId);
        Task<Category> GetCategoriaById(int categoryId);
    }
}
