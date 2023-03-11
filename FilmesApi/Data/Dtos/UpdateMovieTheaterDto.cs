using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos
{
    public class UpdateMovieTheaterDto
    {
        [Required(ErrorMessage = "Field name is required")]
        public string? Name { get; set; }
        public Guid AddressUid { get; set; }
    }
}
