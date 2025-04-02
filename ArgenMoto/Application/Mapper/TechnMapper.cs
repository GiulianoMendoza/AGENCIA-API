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
    public class TechnMapper : ITechnMapper
    {
        public TechnMapper()
        {

        }

        public async Task<TechResponse> GenerateTechResponse(Techn newTech)
        {
            return new TechResponse
            {
                TechId = newTech.TecnicoId,
                name = newTech.Name,
                surname = newTech.Surname,
                dni = newTech.Dni,
                addres = newTech.Addres,
                phone = newTech.Phone,
                email = newTech.Email
            };
        }
        public async Task<List<TechResponse>> GenerateListTechResponse(List<Techn> techns)
        {
            List<TechResponse> techresponse = new();
            foreach (Techn tech in techns)
            {
                techresponse.Add(await GenerateTechResponse(tech));
            }
            return techresponse;
        }
    }
}
