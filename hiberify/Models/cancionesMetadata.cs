﻿namespace webmusic_solved.Models
{
    public class cancionesMetadata
    {
        public int Id { get; set; }

        public string? Titulo { get; set; }

        public int? ArtistaId { get; set; }

        public int? AlbumId { get; set; }

        public virtual Albumes? Album { get; set; }

        public virtual Artistas? Artista { get; set; }
    }
}
