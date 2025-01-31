using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Moq;
using webmusic_solved.Models;
using webmusic_solved.Services.CounterSQL;
using Xunit;

namespace tests_hiberify.Services
{
    public class CountersqlServiceTests
    {

        /*using System;
           using System.Collections.Generic;
           using Microsoft.EntityFrameworkCore;
           using webmusic_solved.Models;

           namespace webmusic_solved.Services.CounterSQL
           {
               public class CountersqlService : ICountersqlService
               {
                   private readonly GrupoAContext _context;

                   public CountersqlService(GrupoAContext context)
                   {
                       _context = context;
                   }

                   public int GetCancionesCount()
                   {
                       return _context.Canciones.Count();
                   }

                   public int GetArtistasCount()
                   {
                       return _context.Artistas.Count();
                   }
                   public double GetMinutosMusicaCount()
                   {
                       return _context.Canciones.Count();
                   }
               }
           }*/

        [Fact]
        public void GetCancionesCount_ReturnsCancionesCount()
        {
            // Arrange
            var data = new List<Canciones>
            {
                new Canciones { Id = 1, Titulo = "Cancion 1", ArtistaId = 1, AlbumId = 1 },
                new Canciones { Id = 2, Titulo = "Cancion 2", ArtistaId = 1, AlbumId = 1 },
                new Canciones { Id = 3, Titulo = "Cancion 3", ArtistaId = 1, AlbumId = 1 },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Canciones>>();
            mockSet.As<IQueryable<Canciones>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Canciones>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Canciones>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Canciones>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<GrupoAContext>();
            mockContext.Setup(c => c.Canciones).Returns(mockSet.Object);

            var service = new CountersqlService(mockContext.Object);

            // Act
            var result = service.GetCancionesCount();

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]

        public void GetArtistasCount_ReturnsArtistasCount()
        {
            // Arrange
            var data = new List<Artistas>
            {
                new Artistas { Id = 1, Nombre = "Artista 1", Genero = "Rock", Fecha = DateOnly.Parse("2023-01-12") },
                new Artistas { Id = 2, Nombre = "Artista 2", Genero = "Rock", Fecha = DateOnly.Parse("2023-01-12") },
                new Artistas { Id = 3, Nombre = "Artista 3", Genero = "Blues", Fecha = DateOnly.Parse("2023-01-12") },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Artistas>>();
            mockSet.As<IQueryable<Artistas>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Artistas>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Artistas>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Artistas>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<GrupoAContext>();
            mockContext.Setup(c => c.Artistas).Returns(mockSet.Object);

            var service = new CountersqlService(mockContext.Object);

            // Act
            var result = service.GetArtistasCount();

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]

        public void GetMinutosMusicaCount_ReturnsMinutosMusicaCount()
        {
            // Arrange
            var data = new List<Canciones>
            {
                new Canciones { Id = 1, Titulo = "Cancion 1", ArtistaId = 1, AlbumId = 1},
                new Canciones { Id = 2, Titulo = "Cancion 2", ArtistaId = 1, AlbumId = 1},
                new Canciones { Id = 3, Titulo = "Cancion 3", ArtistaId = 1, AlbumId = 1},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Canciones>>();
            mockSet.As<IQueryable<Canciones>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Canciones>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Canciones>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Canciones>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<GrupoAContext>();
            mockContext.Setup(c => c.Canciones).Returns(mockSet.Object);

            var service = new CountersqlService(mockContext.Object);

            // Act
            var result = service.GetMinutosMusicaCount();

            // Assert
            Assert.Equal(3, result);
        }





    }
}