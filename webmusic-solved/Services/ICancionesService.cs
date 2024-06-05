using Microsoft.EntityFrameworkCore;
using webmusic_solved.Models;

public interface ICancionesService
{
    Task<IEnumerable<Canciones>> GetCanciones(string searchString);
}