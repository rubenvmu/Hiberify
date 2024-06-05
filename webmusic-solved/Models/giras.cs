namespace webmusic_solved.Models
{
    public class giras
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public int? ArtistaId { get; set; }

        public virtual Artistas? Artista { get; set; }

        public DateOnly? FechaInicioGira { get; set; }

        public DateOnly? FechaFinalGira { get; set; }

    }
}
