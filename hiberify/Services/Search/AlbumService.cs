using Microsoft.EntityFrameworkCore;
using webmusic_solved.Models;

public class AlbumService : IAlbumService
{
    private readonly GrupoAContext _context;

    public AlbumService(GrupoAContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Albumes>> GetAlbumes(string searchString, string searchString2)
    {
        if (_context.Albumes == null)
        {
            throw new InvalidOperationException("Fallo");
        }

        var canciones = from m in _context.Albumes
            select m;

        if (!String.IsNullOrEmpty(searchString))
        {
            canciones = canciones.Where(s => s.Titulo!.Contains(searchString));
        }

        if (!String.IsNullOrEmpty(searchString2))
        {
            canciones = canciones.Where(s => s.Genero!.Contains(searchString2));
        }

        return await canciones.ToListAsync();
    }
}