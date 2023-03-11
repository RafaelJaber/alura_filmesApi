using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models
{
    public class MovieTheater
    {
        [Key]
        [Required]
        public Guid Uid { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "Field name is required")]
        public string? Name { get; set; }
    }
}
