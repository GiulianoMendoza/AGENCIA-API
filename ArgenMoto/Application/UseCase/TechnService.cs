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

namespace Application.UseCase
{
    public class TechnService : ITechnService
    {
        private readonly ITechnQuery _query;
        private readonly ITechnMapper _mapper;
        private readonly ITechnCommand _command;

        public TechnService(ITechnQuery techquery, ITechnMapper technMapper, ITechnCommand technCommand)
        {
            _query = techquery;
            _mapper = technMapper;
            _command = technCommand;
        }
        public async Task<List<TechResponse>> GetTech()
        {
            List<Techn> techns = new();
            techns = await _query.GetAll();
            return await _mapper.GenerateListTechResponse(techns);
        }
        public async Task<TechResponse> GetTechById(Guid id)
        {
            try
            {
                var TechById = await _query.GetTechById(id);
                if (TechById == null)
                {
                    throw new ExceptionNotFound("No existe Tecnico con ese ID.");
                }
                else
                {
                    var techResponse = await _mapper.GenerateTechResponse(TechById);
                    return techResponse;
                }
            }
            catch (ExceptionNotFound ex)
            {
                throw new ExceptionNotFound("Error: " + ex.Message);
            }
        }
        public async Task<TechResponse> RegisterTech(TechRequest techRequest, Guid id)
        {
            try
            {
                if (techRequest == null)
                {
                    throw new ExceptionSintaxError("Solicitud incorrecta campos vacios.");
                }

                if (string.IsNullOrWhiteSpace(techRequest.Name))
                {
                    throw new ExceptionSintaxError("El nombre del cliente no puede estar vacío.");
                }
                var newTech = new Techn
                {
                    TecnicoId = id,
                    Name = techRequest.Name,
                    Surname = techRequest.Surname,
                    Dni = techRequest.Dni,
                    Phone = techRequest.Phone,
                    Addres = techRequest.Addres,
                    Email = techRequest.Email,
                    Province = techRequest.Province,
                    Locality = techRequest.Locality
                };
                await _command.InsertTecnico(newTech);
                var response = await _mapper.GenerateTechResponse(newTech);

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
