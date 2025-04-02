using Application.Request;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMotoCommand
    {
        Task<string> InsertProduct(Moto moto);
        Task<Moto> UpdateProduct(Guid id, MotoRequest Moto);
        Task<Moto> DeleteProduct(Guid id);
    }
}
