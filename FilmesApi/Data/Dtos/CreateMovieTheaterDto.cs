using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos
{
    public class CreateMovieTheaterDto
    {
        [Required(ErrorMessage = "Field name is required")]
        public string? Name { get; set; }
    }
}
