// Copyright (c) Miguel Angel De La Rosa Martínez, Alec Demian Santana Celaya, Jaime Valdez Tanori, Martin Ricardo Yocupicio Ramos. Licensed under the MIT Licence.
// See the LICENSE file in the repository root for full license text.

using EventManager.Core.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Core.Database.Services
{
    public class EventoService
    {
        private readonly DatabaseContext _context;

        public EventoService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Evento>> GetEventosAsync()
        {
            return await _context.Eventos.ToListAsync();
        }

        public async Task<Evento> GetEventoAsync(int id)
        {
            return await _context.Eventos.FindAsync(id);
        }

        public async Task<Evento> CreateEventoAsync(Evento evento)
        {
            _context.Eventos.Add(evento);
            await _context.SaveChangesAsync();

            return evento;
        }

        public async Task<Evento> UpdateEventoAsync(int id, Evento evento)
        {
            _context.Entry(evento).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return evento;
        }

        public async Task<Evento> DeleteEventoAsync(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            _context.Eventos.Remove(evento);
            await _context.SaveChangesAsync();

            return evento;
        }

        public async Task<bool> EventoExistsAsync(int id)
        {
            return await _context.Eventos.AnyAsync(e => e.Id == id);
        }
    }
}