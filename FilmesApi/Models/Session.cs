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
        [Required]
        public Guid MovieId { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
