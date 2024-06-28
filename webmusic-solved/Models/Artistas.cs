using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace webmusic_solved.Models;

public partial class Artistas
{
    public int Id { get; set; }
    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string? Nombre { get; set; }
    [StringLength(60, MinimumLength = 3)]
    public string? Genero { get; set; }

    public DateTime Fecha { get; set; }

    public virtual ICollection<Canciones> Canciones { get; set; } = new List<Canciones>();

    public virtual ICollection<Festival> Festival { get; set; } = new List<Festival>();
}
