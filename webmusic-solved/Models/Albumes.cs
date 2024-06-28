using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace webmusic_solved.Models;

public partial class Albumes
{
    public int Id { get; set; }
    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string? Genero { get; set; }

    public DateTime Fecha { get; set; }
    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    [StringLength(30)]
    public string? Titulo { get; set; }

    public virtual ICollection<Canciones> Canciones { get; set; } = new List<Canciones>();
}
