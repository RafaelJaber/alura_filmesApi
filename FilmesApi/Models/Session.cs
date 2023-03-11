using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmesApi.Models
{
    [Table(("TB_Sessions"))]
    public class Session
    {
        [Key]
        [Required]
        public Guid Guid { get; set; } = Guid.NewGuid();
    }
}
