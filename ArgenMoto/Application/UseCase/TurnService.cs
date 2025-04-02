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
    public class TurnService : ITurnService
    {
        private readonly ITurnQuery _query;
        private readonly ITurnMapper _mapper;
        private readonly ITurnCommand _command;

        public TurnService(ITurnQuery turnQuery, ITurnMapper turnMapper, ITurnCommand turnCommand)
        {
            _query = turnQuery;
            _mapper = turnMapper;
            _command = turnCommand;
        }
        public async Task<List<TurnResponse>> GetTurns()
        {
            List<Turn> turns = new();
            turns = await _query.GetAll();
            return await _mapper.GenerateListTurnResponse(turns);
        }
        public async Task<TurnResponse> GetTurnsById(int turnid)
        {
            var turns = await _query.GetTurnById(turnid);
            return await _mapper.GenerateTurnResponse(turns);
        }
        public async Task<TurnResponse> RegisterTurn(TurnRequest turnRequest)
        {
            try
            {
                if (turnRequest == null)
                {
                    throw new ExceptionSintaxError("Solicitud incorrecta campos vacios.");
                }

                if (string.IsNullOrWhiteSpace(turnRequest.TypeService))
                {
                    throw new ExceptionSintaxError("El tipo de servicio no puede estar vacío.");
                }
                var newTurn = new Turn
                {
                    ClientId = turnRequest.Client,
                    SaleId = turnRequest.Sale,
                    Motoid = turnRequest.Motoid,
                    TechnId = turnRequest.Techn,
                    TypeService = turnRequest.TypeService,
                    Status = turnRequest.Status,
                    Date = turnRequest.Date
                };
                string turnid = await _command.AddTurn(newTurn);
                var response = await _mapper.GenerateTurnResponse(newTurn);
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
        public async Task<TurnResponse> CancelTurn(int turnId, string status)
        {
            var result = await _command.CancelTurn(turnId, status);
            var mapper = await _mapper.GenerateTurnResponse(result);
            return mapper;
        }
        public async Task<TurnResponse> UpdateTurn(int turnId, TurnRequest turn)
        {
            var result = await _command.UpdateTurn(turnId, turn);
            var mapper = await _mapper.GenerateTurnResponse(result);
            return mapper;
        }
        public async Task<TurnResponse> DeleteTurn(int turnId)
        {
            var result = await _command.DeleteTurn(turnId);
            var mapper = await _mapper.GenerateTurnResponse(result);
            return mapper;
        }
    }
}
