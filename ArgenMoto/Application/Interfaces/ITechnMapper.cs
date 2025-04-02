using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITechnMapper
    {
        Task<TechResponse> GenerateTechResponse(Techn newTech);
        Task<List<TechResponse>> GenerateListTechResponse(List<Techn> techns);
    }
}
