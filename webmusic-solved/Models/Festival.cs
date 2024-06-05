using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace webmusic_solved.Models;

public partial class Festival
{
    public int Id { get; set; }
    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string? Nombre { get; set; }

    public int? ArtistaId { get; set; }
    [StringLength(60, MinimumLength = 1)]
    [Required]
    public string? Ciudad { get; set; }

    public DateOnly? FechaInicio { get; set; }

    public DateOnly? FechaFinal { get; set; }

    public virtual Artistas? Artista { get; set; }
}
