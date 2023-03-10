using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos
{
    public class CreateMovieDto
    {
        [Required(ErrorMessage = "Title is required")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        [StringLength(50, ErrorMessage = "Max length is 50 caracters")]
        public string? Gender { get; set; }
        [Required(ErrorMessage = "Duration is Required")]
        [Range(0, 500, ErrorMessage = "Duration is invalid")]
        public int Duration { get; set; }
    }
}
