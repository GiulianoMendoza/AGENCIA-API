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
    public class MotoService : IMotoService
    {
        private readonly IMotoQuery _query;
        private readonly IMotoMapper _mapper;
        private readonly IMotoCommand _command;

        public MotoService(IMotoQuery motoquery, IMotoMapper motoMapper, IMotoCommand motoCommand)
        {
            _query = motoquery;
            _mapper = motoMapper;
            _command = motoCommand;
        }
        public async Task<List<MotoGetResponse>> GetMotoByFilters(List<int> categories, string name, int limit, int offset)
        {
            List<Moto> listmots = new();

            if (categories.Count() == 0 && name == null && limit == 0 && offset == 0)
            {
                listmots = await _query.GetAll();
            }
            else
            {
                if (categories.Count() > 0 && categories.Count() <= 10)
                {
                    foreach (int categoryId in categories)
                    {
                        var motsByCategory = await _query.GetMotoByCategory(categoryId);
                        if (limit == 0 && offset == 0)
                        {
                            listmots.AddRange(motsByCategory);
                        }
                        else
                        {
                            listmots.AddRange(motsByCategory);
                        }
                    }
                }

                if (name != null)
                {
                    if (categories.Count() > 0 && categories.Count() <= 10)
                    {
                        var secundarylist = listmots;
                        listmots.Clear();
                        listmots = secundarylist.Where(moto => moto.MotoName.ToLower().Contains(name.ToLower())).ToList();
                    }
                    var motobyname = await _query.GetMotoByName(name);
                    listmots.AddRange(motobyname);
                    listmots = listmots.Where(moto => moto.MotoName.ToLower().Contains(name.ToLower())).ToList();
                    if (limit == 0 && offset == 0)
                    {
                        listmots = listmots.Where(moto => moto.MotoName.ToLower().Contains(name.ToLower())).ToList();
                    }

                }
                if (limit > 0 && offset >= 0)
                {
                    if (listmots.Count > 0)
                    {
                        listmots = listmots.Skip(offset).Take(limit).ToList();
                    }
                    else
                    {
                        listmots = await _query.GetMotoPaged(limit, offset);
                    }

                }
            }

            return await _mapper.GenerateListMotsGetResponse(listmots);

        }
        public async Task<MotoResponse> RegisterMoto(MotoRequest motoRequest)
        {
            try
            {
                if (motoRequest == null)
                {
                    throw new ExceptionSintaxError("Solicitud incorrecta campos vacios.");
                }

                if (string.IsNullOrWhiteSpace(motoRequest.motoName))
                {
                    throw new ExceptionSintaxError("El nombre de la moto no puede estar vacío.");
                }

                var motowithname = await _query.GetMotoByName(motoRequest.motoName);
                if (motowithname.Any(p => p.MotoName == motoRequest.motoName))
                {
                    throw new ExceptionConflict("Conflicto, la moto ya existe.");
                }

                ValidateMotoRequest(motoRequest);

                var categoriaSeleccionada = await _query.GetCategoriaById(motoRequest.category);
                if (categoriaSeleccionada == null)
                {
                    throw new ExceptionSintaxError("La categoría especificada no existe.");
                }

                var newMoto = new Moto
                {
                    MotoName = motoRequest.motoName,
                    Description = motoRequest.description,
                    Price = motoRequest.price,
                    Discount = motoRequest.discount,
                    imageUrl = motoRequest.imageUrl,
                    CategoryId = motoRequest.category,
                    Category = categoriaSeleccionada
                };

                string MotoId = await _command.InsertProduct(newMoto);
                newMoto.MotoId = new Guid(MotoId);

                var response = await _mapper.GenerateMotoResponse(newMoto);
                response.category = new Category
                {
                    CategoryId = newMoto.CategoryId,
                    Name = newMoto.Category.Name
                };

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
        public async Task<MotoResponse> GetMotoById(Guid id)
        {
            try
            {
                var MotoById = await _query.GetMotoById(id);
                if (MotoById == null)
                {
                    throw new ExceptionNotFound("No existe Moto con ese ID.");
                }
                else
                {
                    var MotoResponse = await _mapper.GenerateMotoResponse(MotoById);
                    MotoResponse.category = new Category
                    {
                        CategoryId = MotoById.CategoryId,
                        Name = MotoById.Category.Name
                    };
                    return MotoResponse;
                }
            }
            catch (ExceptionNotFound ex)
            {
                throw new ExceptionNotFound("Error: " + ex.Message);
            }
        }
        public async Task<MotoResponse> UpdateMoto(Guid id, MotoRequest motoRequest)
        {
            try
            {

                if (motoRequest == null)
                {
                    throw new ExceptionSintaxError("Solicitud incorrecta campos vacios.");
                }
                Moto motoup = await _query.GetMotoById(id);
                if (motoup == null)
                {
                    throw new ExceptionNotFound("No existe producto con ese ID.");
                }
                else
                {
                    List<Moto> listaMots = await _query.GetAll();
                    if (motoRequest.motoName == "")
                    {
                        throw new ExceptionSintaxError("No puede estar el nombre vacio");
                    }
                    if (listaMots.Any(p => p.MotoName.ToLower() == motoRequest.motoName.ToLower() && p.MotoId != id))
                    {
                        throw new ExceptionConflict("Ya existe producto con ese nombre");
                    }
                    ValidateMotoRequest(motoRequest);
                    motoup = await _command.UpdateProduct(id, motoRequest);
                    var response = await _mapper.GenerateMotoResponse(motoup);
                    response.category = new Category
                    {
                        CategoryId = motoup.CategoryId,
                        Name = motoup.Category.Name
                    };
                    return response;

                }
            }
            catch (ExceptionSintaxError ex)
            {
                throw new ExceptionSintaxError("Error: " + ex.Message);
            }
            catch (ExceptionNotFound ex)
            {
                throw new ExceptionNotFound("Error: " + ex.Message);
            }
            catch (ExceptionConflict ex)
            {
                throw new ExceptionConflict("Error: " + ex.Message);
            }

        }
        public async Task<MotoResponse> DeleteMoto(Guid id)
        {
            try
            {
                Moto motoDelete = await _query.GetMotoById(id);
                if (motoDelete != null)
                {
                    if (motoDelete.SaleMotos.Count() != 0)
                    {
                        throw new ExceptionConflict("No se puede borrar la moto que tenga una venta asociada");
                    }
                    motoDelete = await _command.DeleteProduct(id);
                    var response = await _mapper.GenerateMotoResponse(motoDelete);
                    response.category = new Category
                    {
                        CategoryId = motoDelete.CategoryId,
                        Name = motoDelete.Category.Name
                    };
                    return response;
                }
                else
                {
                    throw new ExceptionNotFound("No existe ninguna moto con ese id");
                }

            }
            catch (ExceptionNotFound ex)
            {
                throw new ExceptionNotFound("Error: " + ex.Message);
            }
            catch (ExceptionConflict ex)
            {
                throw new ExceptionConflict("Error: " + ex.Message);
            }
        }

        public async Task<double> GetPriceById(Guid MotoId)
        {
            return await _query.GetPriceById(MotoId);
        }
        public async Task<int> GetDiscountById(Guid MotoId)
        {
            return await _query.GetDiscountById(MotoId);
        }
        private void ValidateMotoRequest(MotoRequest MotoRequest)
        {
            if (MotoRequest.description == "")
            {
                throw new ExceptionSintaxError("debe tener una descripcion minima.");
            }
            if (MotoRequest.price <= 0)
            {
                throw new ExceptionSintaxError("El precio debe ser mayor a 0");
            }
            if (MotoRequest.discount < 0)
            {
                throw new ExceptionSintaxError("El descuento debe ser mayor o igual a 0");
            }
            if (MotoRequest.imageUrl == "")
            {
                throw new ExceptionSintaxError("debe ingresar una URL.");
            }
            if (MotoRequest.category <= 0 || MotoRequest.category > 10)
            {
                throw new ExceptionSintaxError("Categoría del 1 al 10");
            }
        }
    }
}
