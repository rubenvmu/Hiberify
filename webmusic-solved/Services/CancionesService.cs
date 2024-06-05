using Microsoft.EntityFrameworkCore;
using webmusic_solved.Models;

public class CancionesService : ICancionesService
{
    private readonly GrupoAContext _context;

    public CancionesService(GrupoAContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Canciones>> GetCanciones(string searchString)
    {
        if (_context.Albumes == null)
        {
            throw new InvalidOperationException("Fallo");
        }

        var canciones = from m in _context.Canciones
            select m;

        if (!String.IsNullOrEmpty(searchString))
        {
            canciones = canciones.Where(s => s.Titulo!.Contains(searchString));
        }

        return await canciones.ToListAsync();
    }
}