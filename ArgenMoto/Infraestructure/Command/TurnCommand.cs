using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Command
{
    public class TurnCommand : ITurnCommand
    {
        private readonly AppDBContext _context;
        public TurnCommand(AppDBContext context)
        {
            this._context = context;
        }
        public async Task<string> AddTurn(Turn turn)
        {
            try
            {
                _context.Add(turn);
                _context.SaveChangesAsync();
                return turn.TurnId.ToString();
            }
            catch (DbUpdateException)
            {
                throw new ExceptionConflict("Error en la base de datos: Problema en añadir el turno");
            }
        }
        public async Task<Turn> UpdateTurn(int TurnId, TurnRequest turn)
        {
            try
            {
                var TurnUpdate = await _context.Turns.FirstOrDefaultAsync(p => p.TurnId == TurnId);
                TurnUpdate.TurnId = TurnId;
                TurnUpdate.ClientId = turn.Client;
                TurnUpdate.TechnId = turn.Techn;
                TurnUpdate.TypeService = turn.TypeService;
                TurnUpdate.Status = turn.Status;
                TurnUpdate.Motoid = turn.Motoid;
                TurnUpdate.SaleId = turn.Sale;

                await _context.SaveChangesAsync();
                return TurnUpdate;
            }
            catch (DbUpdateException)
            {
                throw new ExceptionConflict("Problema al modificar el turno");
            }
        }
        public async Task<Turn> CancelTurn(int TurnId, string status)
        {
            var turn = await _context.Turns.FindAsync(TurnId);

            if (turn == null)
            {
                throw new ExceptionNotFound("No se encontró el turno especificado.");
            }

            turn.Status = status;

            await _context.SaveChangesAsync();

            return turn;
        }
        public async Task<Turn> DeleteTurn(int id)
        {
            try
            {

                var TurnDelete = await _context.Turns.FirstOrDefaultAsync(p => p.TurnId == id);
                if (TurnDelete == null)
                {
                    throw new ExceptionNotFound("el turno con ID " + id + " no fue encontrado.");
                }
                _context.Turns.Remove(TurnDelete);
                await _context.SaveChangesAsync();
                return TurnDelete;
            }
            catch (DbUpdateException)
            {
                throw new ExceptionConflict("Problema al Eliminar el turno");
            }
        }
    }
    
}
