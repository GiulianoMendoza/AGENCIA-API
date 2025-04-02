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
    public class TurnMapper : ITurnMapper
    {
        public TurnMapper() { }
        public async Task<TurnResponse> GenerateTurnResponse(Turn newTurn)
        {
            return new TurnResponse
            {
                Date = newTurn.Date,
                TypeService = newTurn.TypeService,
                Status = newTurn.Status,
                Techn = newTurn.TechnId,
                TurnId = newTurn.TurnId,
                Moto = newTurn.Motoid,
                Client = newTurn.ClientId,
                Sale = newTurn.SaleId
            };
        }
        public async Task<List<TurnResponse>> GenerateListTurnResponse(List<Turn> turns)
        {
            List<TurnResponse> turnResponse = new();
            foreach (Turn turn in turns)
            {
                turnResponse.Add(await GenerateTurnResponse(turn));
            }
            return turnResponse;
        }
    }
}
