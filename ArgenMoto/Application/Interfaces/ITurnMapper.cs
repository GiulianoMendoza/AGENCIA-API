using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITurnMapper 
    {
        Task<TurnResponse> GenerateTurnResponse(Turn newTurn);
        Task<List<TurnResponse>> GenerateListTurnResponse(List<Turn> turns);
    }
}
