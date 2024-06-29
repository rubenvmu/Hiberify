using Xunit;
using Microsoft.AspNetCore.Mvc;
using webmusic_solved.Controllers;
using webmusic_solved.Models;

namespace webmusic_hiberify_tests
{
    public class ArtistasControllerTests
    {
        [Fact]
        public async Task Index_ReturnsView()
        {
            // Arrange
            var context = new GrupoAContext();
            var controller = new ArtistasController(context);

            // Act
            var result = await controller.Index();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Details_ReturnsView_WhenIdIsValid()
        {
            // Arrange
            var context = new GrupoAContext();
            var controller = new ArtistasController(context);
            var id = 1;

            // Act
            var result = await controller.Details(id);

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Details_ReturnsNotFound_WhenIdIsInvalid()
        {
            // Arrange
            var context = new GrupoAContext();
            var controller = new ArtistasController(context);
            var id = 0;

            // Act
            var result = await controller.Details(id);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}