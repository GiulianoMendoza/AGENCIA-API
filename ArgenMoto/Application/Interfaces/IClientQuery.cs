using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IClientQuery
    {
        Task<Client> GetClientById(Guid clientId);
        Task<List<Client>> GetAll();
    }
}
