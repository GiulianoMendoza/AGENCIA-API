using Application.Interfaces;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper
{
    public class ClientMapper : IClienteMapper
    {
        public ClientMapper()
        {

        }

        public async Task<ClientResponse> GenerateClientResponse(Client newClient)
        {
            return new ClientResponse
            {
                clientId = newClient.ClientId,
                name = newClient.Name,
                surname = newClient.Surname,
                dni = newClient.Dni,
                addres = newClient.Addres,
                phone = newClient.Phone,
                email = newClient.Email
            };
        }
        public async Task<List<ClientResponse>> GenerateListClientResponse(List<Client> clients)
        {
            List<ClientResponse> clientresponse = new();
            foreach (Client client in clients)
            {
                clientresponse.Add(await GenerateClientResponse(client));
            }
            return clientresponse;
        }
    }
}
