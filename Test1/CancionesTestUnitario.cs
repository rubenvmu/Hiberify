using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using webmusic_solved.Controllers;
using webmusic_solved.Models;

namespace webmusic_solved.Tests.Controllers
{
    public class CancionesControllerTests
    {
        [Fact]
        public async Task Index_ReturnsView_WhenSearchStringIsNull()
        {
            // Arrange
            var context = new Mock<GrupoAContext>();
            var cancionesService = new Mock<ICancionesService>();
            var controller = new CancionesController(context.Object, cancionesService.Object);

            // Act
            var result = await controller.Index("");

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Details_ReturnsNotFound_WhenIdIsNull()
        {
            // Arrange
            var context = new Mock<GrupoAContext>().Object;
            var cancionesService = new Mock<ICancionesService>().Object;
            var controller = new CancionesController(context, cancionesService);

            // Act
            var result = await controller.Details(null);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Edit_ReturnsNotFound_WhenIdIsNull()
        {
            // Arrange
            var context = new Mock<GrupoAContext>();
            var cancionesService = new Mock<ICancionesService>();
            var controller = new CancionesController(context.Object, cancionesService.Object);

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
            var cancionesService = new Mock<ICancionesService>();
            var controller = new CancionesController(context.Object, cancionesService.Object);

            // Act
            var result = await controller.Delete(null);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}