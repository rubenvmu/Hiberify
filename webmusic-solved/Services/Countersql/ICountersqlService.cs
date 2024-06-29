using webmusic_solved.Models;

namespace webmusic_solved.Services.CounterSQL
{
    public interface ICountersqlService
    {
        int GetCancionesCount();
        int GetArtistasCount();
        double GetMinutosMusicaCount();
    }
}