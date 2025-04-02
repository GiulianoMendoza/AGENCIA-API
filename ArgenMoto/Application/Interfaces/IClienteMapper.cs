using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IClienteMapper
    {
        Task<ClientResponse> GenerateClientResponse(Client newClient);
        Task<List<ClientResponse>> GenerateListClientResponse(List<Client> clients);
    }
}
