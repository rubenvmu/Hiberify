namespace webmusic_solved.Models
{
    public class artistasMetadata
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Genero { get; set; }

        public DateOnly? Fecha { get; set; }
    }
}
