using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public class SellerService : ISellerService
    {
        private readonly ISellerQuery _query;
        private readonly ISellerMapper _mapper;
        private readonly ISellerCommand _command;

        public SellerService(ISellerQuery sellerQuery, ISellerMapper sellerMapper, ISellerCommand sellerCommand)
        {
            _query = sellerQuery;
            _mapper = sellerMapper;
            _command = sellerCommand;
        }
        public async Task<SellerResponse> GetSellerById(Guid id)
        {
            try
            {
                var SellerById = await _query.GetSellerById(id);
                if (SellerById == null)
                {
                    throw new ExceptionNotFound("No existe Tecnico con ese ID.");
                }
                else
                {
                    var SellerResponse = await _mapper.GenerateSellerResponse(SellerById);
                    return SellerResponse;
                }
            }
            catch (ExceptionNotFound ex)
            {
                throw new ExceptionNotFound("Error: " + ex.Message);
            }
        }
        public async Task<SellerResponse> RegisterSeller(SellerRequest sellerRequest, Guid id)
        {
            try
            {
                if (sellerRequest == null)
                {
                    throw new ExceptionSintaxError("Solicitud incorrecta campos vacios.");
                }

                if (string.IsNullOrWhiteSpace(sellerRequest.Name))
                {
                    throw new ExceptionSintaxError("El nombre del cliente no puede estar vacío.");
                }
                var newSeller = new Seller
                {
                    SellerId = id,
                    Name = sellerRequest.Name,
                    Surname = sellerRequest.Surname,
                    Dni = sellerRequest.Dni,
                    Phone = sellerRequest.Phone,
                    Addres = sellerRequest.Addres,
                    Email = sellerRequest.Email,
                    Province = sellerRequest.Province,
                    Locality = sellerRequest.Locality
                };
                await _command.InsertVendedor(newSeller);
                var response = await _mapper.GenerateSellerResponse(newSeller);

                return response;
            }
            catch (ExceptionSintaxError ex)
            {
                throw new ExceptionSintaxError("Error: " + ex.Message);
            }
            catch (ExceptionConflict ex)
            {
                throw new ExceptionConflict("Error: " + ex.Message);
            }
        }
    }
}
