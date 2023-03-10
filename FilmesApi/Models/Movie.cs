using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml;

namespace FilmesApi.Models
{
    [Table("TB_Movie")]
    public class Movie
    {
        [Key]
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "Title is required")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public string? Gender { get; set; }
        [Required(ErrorMessage = "Duration is Required")]
        [Range(0, 500, ErrorMessage = "Duration is invalid")]
        public int Duration { get; set; }
    }
}
