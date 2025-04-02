using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITurnQuery
    {
        Task<List<Turn>> GetAll();
        Task<Turn> GetTurnById(int turnId);
    }
}
