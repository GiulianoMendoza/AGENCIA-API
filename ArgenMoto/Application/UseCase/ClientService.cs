using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Application.UseCase
{
    public class ClientService : IClientService
    {
        private readonly IClientQuery _query;
        private readonly IClienteMapper _mapper;
        private readonly IClientCommand _command;

        public ClientService(IClientQuery clientquery, IClienteMapper clientMapper, IClientCommand clientCommand)
        {
            _query = clientquery;
            _mapper = clientMapper;
            _command = clientCommand;
        }
        public async Task<List<ClientResponse>> GetClients()
        {
            List<Client> clients = new();
            clients = await _query.GetAll();
            return await _mapper.GenerateListClientResponse(clients);
        }
        public async Task<ClientResponse> GetClientById(Guid id)
        {
            try
            {
                var ClientById = await _query.GetClientById(id);
                if (ClientById == null)
                {
                    throw new ExceptionNotFound("No existe client con ese ID.");
                }
                else
                {
                    var clientResponse = await _mapper.GenerateClientResponse(ClientById);
                    return clientResponse;
                }
            }
            catch (ExceptionNotFound ex)
            {
                throw new ExceptionNotFound("Error: " + ex.Message);
            }
        }
        public async Task<ClientResponse> RegisterClient(ClientRequest ClientRequest, Guid id)
        {
            try
            {
                if (ClientRequest == null)
                {
                    throw new ExceptionSintaxError("Solicitud incorrecta campos vacios.");
                }

                if (string.IsNullOrWhiteSpace(ClientRequest.name))
                {
                    throw new ExceptionSintaxError("El nombre del cliente no puede estar vacío.");
                }
                var newClient = new Client
                {
                    ClientId = id,
                    Name = ClientRequest.name,
                    Surname = ClientRequest.surname,
                    Dni = ClientRequest.dni,
                    Phone = ClientRequest.phone,
                    Addres = ClientRequest.addres,
                    Email = ClientRequest.email,
                    Province = ClientRequest.province,
                    Locality = ClientRequest.locality
                };
                await _command.InsertClient(newClient);
                var response = await _mapper.GenerateClientResponse(newClient);

                return response;
            }
            catch (ExceptionSintaxError ex)
            {
                throw new ExceptionSintaxError("Error: " + ex.Message);
            }
            catch (ExceptionConflict ex)
            {
                throw new ExceptionConflict("Error: " + ex.Message);
            }
        }
    }
}
