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
    public class MotoMapper : IMotoMapper
    {
        public MotoMapper()
        {

        }

        public async Task<MotoResponse> GenerateMotoResponse(Moto newMoto)
        {
            return new MotoResponse
            {
                MotoId = newMoto.MotoId,
                motoName = newMoto.MotoName,
                description = newMoto.Description,
                price = newMoto.Price,
                mark = newMoto.Mark,
                model = newMoto.Model,
                discount = newMoto.Discount,
                cylinder = newMoto.Cylinder,
                imageUrl = newMoto.imageUrl
            };
        }
        public async Task<MotoGetResponse> GenerateMotoGetResponse(Moto newMoto)
        {
            return new MotoGetResponse
            {
                MotoId = newMoto.MotoId,
                motoName = newMoto.MotoName,
                price = newMoto.Price,
                mark = newMoto.Mark,
                model = newMoto.Model,
                cylinder = newMoto.Cylinder,
                discount = newMoto.Discount,
                categoryname = newMoto.Category.Name,
                imageUrl = newMoto.imageUrl
            };
        }

        public async Task<List<MotoGetResponse>> GenerateListMotsGetResponse(List<Moto> Mots)
        {
            List<MotoGetResponse> motosResponse = new();
            foreach (Moto product in Mots)
            {
                motosResponse.Add(await GenerateMotoGetResponse(product));
            }
            return motosResponse;
        }
    }
}
