using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmesApi.Models
{
    [Table(("TB_Sessions"))]
    public class Session
    {
        [Key]
        [Required]
        public Guid Uid { get; set; } = Guid.NewGuid();
        public Guid? MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        public Guid? MovieTheaterId { get; set; }
        public virtual MovieTheater MovieTheater { get; set; }
    }
}
