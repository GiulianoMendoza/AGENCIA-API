using Application.Request;
using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITurnService
    {
        Task<List<TurnResponse>> GetTurns();
        Task<TurnResponse> GetTurnsById(int turnid);
        Task<TurnResponse> RegisterTurn(TurnRequest turnRequest);
        Task<TurnResponse> CancelTurn(int turnId, string status);
        Task<TurnResponse> UpdateTurn(int turnId, TurnRequest turn);
        Task<TurnResponse> DeleteTurn(int turnId);
    }
}
