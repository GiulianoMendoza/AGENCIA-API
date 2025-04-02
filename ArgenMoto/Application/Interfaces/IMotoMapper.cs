using Application.Mapper;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMotoMapper
    {
        Task<MotoGetResponse> GenerateMotoGetResponse(Moto newMoto);
        Task<MotoResponse> GenerateMotoResponse(Moto newMoto);
        Task<List<MotoGetResponse>> GenerateListMotsGetResponse(List<Moto> Mots);
    }
}
