using Microsoft.EntityFrameworkCore;
using webmusic_solved.Models;

public interface IAlbumService
{
    Task<IEnumerable<Albumes>> GetAlbumes(string searchString, string searchString2);
}