using Application.Request;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITurnCommand
    {
        Task<string> AddTurn(Turn turn);
        Task<Turn> UpdateTurn(int TurnId, TurnRequest turn);
        Task<Turn> CancelTurn(int TurnId, string status);
        Task<Turn> DeleteTurn(int id);
    }
}
