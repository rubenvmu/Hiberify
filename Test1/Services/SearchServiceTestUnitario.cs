using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Moq;
using webmusic_solved.Models;
using webmusic_solved.Services.CounterSQL;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using webmusic_solved.Controllers;

namespace tests_hiberify.Services
{
    public class SearchServiceTestUnitario
    {
        /*public class AlbumService : IAlbumService
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

                   return await canciones.ToListAsync();*/

        [Fact]
        public async Task GetAlbumes_ReturnsView_WhenSearchStringIsNull()
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

        [Fact]
        public async Task GetAlbumes_ReturnsView_WhenSearchStringIsNullOrWhiteSpace()
        {
            // Arrange
            var context = new Mock<GrupoAContext>();
            var albumService = new Mock<IAlbumService>();
            var controller = new AlbumesController(context.Object, albumService.Object);

            // Act
            var result = await controller.Index(null, null);

            // Assert
            Assert.IsType<ViewResult>(result);
        }
    }
    }
