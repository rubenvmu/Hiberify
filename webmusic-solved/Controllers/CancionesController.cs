﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webmusic_solved.Models;

namespace webmusic_solved.Controllers
{
    public class CancionesController : Controller
    {
        private readonly GrupoAContext _context;
        private readonly ICancionesService _cancionesService;

        public CancionesController(GrupoAContext context, ICancionesService canciones)
        {
            _context = context;
            _cancionesService = canciones;
        }

        // GET: Canciones
        public async Task<IActionResult> Index(string searchString, string searchString2)
        {
            var albumes = await _cancionesService.GetCanciones(searchString);
            return View(albumes);
        }

        // GET: Canciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var canciones = await _context.Canciones
                .Include(c => c.Album)
                .Include(c => c.Artista)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (canciones == null)
            {
                return NotFound();
            }

            return View(canciones);
        }

        // GET: Canciones/Create
        public IActionResult Create()
        {
            ViewData["AlbumId"] = new SelectList(_context.Albumes, "Id", "Id");
            ViewData["ArtistaId"] = new SelectList(_context.Artistas, "Id", "Id");
            return View();
        }

        // POST: Canciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,ArtistaId,AlbumId")] Canciones canciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(canciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlbumId"] = new SelectList(_context.Albumes, "Id", "Id", canciones.AlbumId);
            ViewData["ArtistaId"] = new SelectList(_context.Artistas, "Id", "Id", canciones.ArtistaId);
            return View(canciones);
        }

        // GET: Canciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var canciones = await _context.Canciones.FindAsync(id);
            if (canciones == null)
            {
                return NotFound();
            }
            ViewData["AlbumId"] = new SelectList(_context.Albumes, "Id", "Id", canciones.AlbumId);
            ViewData["ArtistaId"] = new SelectList(_context.Artistas, "Id", "Id", canciones.ArtistaId);
            return View(canciones);
        }

        // POST: Canciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,ArtistaId,AlbumId")] Canciones canciones)
        {
            if (id != canciones.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(canciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CancionesExists(canciones.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlbumId"] = new SelectList(_context.Albumes, "Id", "Id", canciones.AlbumId);
            ViewData["ArtistaId"] = new SelectList(_context.Artistas, "Id", "Id", canciones.ArtistaId);
            return View(canciones);
        }

        // GET: Canciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var canciones = await _context.Canciones
                .Include(c => c.Album)
                .Include(c => c.Artista)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (canciones == null)
            {
                return NotFound();
            }

            return View(canciones);
        }

        // POST: Canciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var canciones = await _context.Canciones.FindAsync(id);
            if (canciones != null)
            {
                _context.Canciones.Remove(canciones);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CancionesExists(int id)
        {
            return _context.Canciones.Any(e => e.Id == id);
        }
    }
}
