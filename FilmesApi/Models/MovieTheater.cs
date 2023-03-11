using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmesApi.Models
{
    [Table("TB_MovieTheataers")]
    public class MovieTheater
    {
        [Key]
        [Required]
        public Guid Uid { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "Field name is required")]
        public string? Name { get; set; }
        public Guid AddressUid { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
