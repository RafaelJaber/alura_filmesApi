using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos
{
    public class UpdateAddressDto
    {
        [Required(ErrorMessage = "Line One is required")]
        public string LineOne { get; set; }
        public string LineTwo { get; set; }
        [Required(ErrorMessage = "Number is required")]
        public int Number { get; set; }
    }
}
