using Application.Request;
using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISellerService
    {
        Task<SellerResponse> GetSellerById(Guid id);
        Task<SellerResponse> RegisterSeller(SellerRequest sellerRequest, Guid id);
    }
}
