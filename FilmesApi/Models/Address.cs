using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmesApi.Models
{
    /// <summary>
    /// Modelo Padrão de Endereço
    /// </summary>
    [Table("TB_Addresses")]
    public class Address
    {
        [Key]
        [Required]
        public Guid Uid { get; set; }
        [Required(ErrorMessage = "Line One is required")]
        public string? LineOne { get; set; }
        public string? LineTwo { get; set; }
        [Required(ErrorMessage = "Number is required")]
        public int Number { get; set; }
    }
}
