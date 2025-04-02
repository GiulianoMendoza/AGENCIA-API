using Application.Request;
using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITechnService
    {
        Task<TechResponse> GetTechById(Guid id);
        Task<TechResponse> RegisterTech(TechRequest techRequest, Guid id);
        Task<List<TechResponse>> GetTech();
    }
}
