using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public class SaleMotoService : ISaleMotoService
    {
        private readonly ISaleMotoCommand _command;

        public SaleMotoService(ISaleMotoCommand command)
        {
            _command = command;
        }
        public async Task<SaleMoto> RegisterSaleProduct(SaleMoto saleMoto)
        {
            return await _command.insertSM(saleMoto);

        }
    }
}
