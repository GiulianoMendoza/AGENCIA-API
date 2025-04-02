using Application.Request;
using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IClientService
    {
        Task<List<ClientResponse>> GetClients();
        Task<ClientResponse> GetClientById(Guid id);
        Task<ClientResponse> RegisterClient(ClientRequest ClientRequest, Guid id);
    }
}
