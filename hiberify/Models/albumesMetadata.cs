namespace webmusic_solved.Models
{
    public class albumesMetadata
    {
        public int Id { get; set; }

        public string? Genero { get; set; }

        public DateOnly? Fecha { get; set; }

        public string? Titulo { get; set; }
    }
}
