using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using webmusic_solved.Controllers;
using webmusic_solved.Models;
using Microsoft.EntityFrameworkCore;

namespace tests_hiberify.Controllers
{
    public class ArtistasControllerTests
    {

        private List<Artistas> GetTestArtistas()
        {
            var fixedDateTime = new DateTime(2022, 1, 1);
            return new List<Artistas>
    {
        new Artistas { Id = 1, Nombre = "Artist 1", Genero = "Rock", Fecha = DateOnly.Parse("2023-01-12") },
        new Artistas { Id = 1, Nombre = "Artist 1", Genero = "Rock", Fecha = DateOnly.Parse("2023-01-12") },
        new Artistas { Id = 1, Nombre = "Artist 1", Genero = "Blues", Fecha = DateOnly.Parse("2023-01-12") },
    };
        }

        [Fact]
        public async Task Details_ReturnsNotFound_WhenIdIsNull()
        {
            // Arrange
            var context = new Mock<GrupoAContext>();
            var controller = new ArtistasController(context.Object);

            // Act
            var result = await controller.Details(null);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Create_ReturnsView_WhenModelIsValid()
        {
            // Arrange
            var context = new Mock<GrupoAContext>();
            var controller = new ArtistasController(context.Object);

            // Act
            var result = controller.Create();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Create_ReturnsRedirectToAction_WhenModelIsValid()
        {
            // Arrange
            var context = new Mock<GrupoAContext>();
            var artistas = new Artistas { Nombre = "Test Artist", Genero = "Rock", Fecha = DateOnly.FromDateTime(new DateTime(2022, 1, 1)) };
            var controller = new ArtistasController(context.Object);

            // Act
            var result = await controller.Create(artistas);

            // Assert
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public async Task Edit_ReturnsNotFound_WhenIdIsNull()
        {
            // Arrange
            var context = new Mock<GrupoAContext>();
            var controller = new ArtistasController(context.Object);

            // Act
            var result = await controller.Edit(null);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Delete_ReturnsNotFound_WhenIdIsNull()
        {
            // Arrange
            var context = new Mock<GrupoAContext>();
            var controller = new ArtistasController(context.Object);

            // Act
            var result = await controller.Delete(null);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

    }

}
