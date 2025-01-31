using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using webmusic_solved.Controllers;
using webmusic_solved.Models;
using Microsoft.EntityFrameworkCore;

namespace tests_hiberify.Controllers
{
    internal class AlbumesTestUnitario
    {
        [Fact]
        public async Task Index_ReturnsView_WhenSearchStringIsNull()
        {
            // Arrange
            var context = new Mock<GrupoAContext>();
            var albumService = new Mock<IAlbumService>();
            var controller = new AlbumesController(context.Object, albumService.Object);

            // Act
            var result = await controller.Index("", "");

            // Assert
            Assert.IsType<ViewResult>(result);
        }
    }
}
