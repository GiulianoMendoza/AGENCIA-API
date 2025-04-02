using Application.Request;
using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMotoService
    {
        Task<List<MotoGetResponse>> GetMotoByFilters(List<int> categories, string name, int limit, int offset);
        Task<MotoResponse> RegisterMoto(MotoRequest request);
        Task<MotoResponse> GetMotoById(Guid id);
        Task<MotoResponse> UpdateMoto(Guid id, MotoRequest motoRequest);
        Task<MotoResponse> DeleteMoto(Guid id);
        Task<double> GetPriceById(Guid MotoId);
        Task<int> GetDiscountById(Guid MotoId);
    }
}
