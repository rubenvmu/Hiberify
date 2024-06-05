using webmusic_solved;
using webmusic_solved.Models;

namespace webmusic_solved.Services.Repo
{
    public class fakeAlbumesRepositorio : IAlbumesRepositorio
    {

        private List<Canciones> listaCanciones = new();
    }
}
