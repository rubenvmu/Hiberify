using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using webmusic_solved.Models;

namespace webmusic_solved.Services.CounterSQL
{
    public class CountersqlService : ICountersqlService
    {
        private readonly GrupoAContext _context;

        public CountersqlService(GrupoAContext context)
        {
            _context = context;
        }

        public int GetCancionesCount()
        {
            return _context.Canciones.Count();
        }

        public int GetArtistasCount()
        {
            return _context.Artistas.Count();
        }
        public double GetMinutosMusicaCount()
        {
            return _context.Canciones.Count();
        }
    }
}