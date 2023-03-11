namespace FilmesApi.Data.Dtos
{
    public class ReadMovieTheaterDto
    {
        public Guid Uid { get; set; }
        public string? Name { get; set; }
        public DateTime AppointmentTime { get; set; } = DateTime.Now;
    }
}
