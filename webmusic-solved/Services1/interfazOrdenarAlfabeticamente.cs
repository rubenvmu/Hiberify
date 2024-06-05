using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webmusic_solved.Models;

namespace webmusic_solved.Controllers
{
    public class interfazOrdenarAlfabeticamente : Controller
    {
        private readonly GrupoAContext _context;

        public interfazOrdenarAlfabeticamente(GrupoAContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var albums = _context.Albumes.OrderBy(a => a.Titulo).ToList();
            return View(albums);
        }
    }
}
