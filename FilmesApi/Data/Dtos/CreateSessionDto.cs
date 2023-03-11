namespace FilmesApi.Data.Dtos
{
    public class CreateSessionDto
    {
        public Guid MovieId { get; set; }
        public Guid MovieTheaterId { get; set; }
    }
}
