using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace webmusic_solved.Models;

public partial class Canciones
{
    public int Id { get; set; }
    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string? Titulo { get; set; }

    public int? ArtistaId { get; set; }

    public int? AlbumId { get; set; }
    [StringLength(60, MinimumLength = 3)]
    [Required]
    public virtual Albumes? Album { get; set; }

    public virtual Artistas? Artista { get; set; }
}
