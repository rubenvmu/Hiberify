using Xunit;
using webmusic_solved.Models;

namespace ArtistasTest
{
    public class ArtistasTesting
    {
        private readonly Artistas _artistas;

        public ArtistasTesting()
        {
            _artistas = new Artistas();
        }

        [Fact]
        public void TestArtista_Id_SetAndGet()
        {
            // Arrange
            int expectedId = 1;

            // Act
            _artistas.Id = expectedId;

            // Assert
            Assert.Equal(expectedId, _artistas.Id);
        }

        [Fact]
        public void TestArtista_Nombre_SetAndGet()
        {
            // Arrange
            string expectedNombre = "Test Artist";

            // Act
            _artistas.Nombre = expectedNombre;

            // Assert
            Assert.Equal(expectedNombre, _artistas.Nombre);
        }

    }
}