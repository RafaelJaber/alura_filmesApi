using System.ComponentModel.DataAnnotations;

namespace UserApi.Data.Requests
{
    public class ActivateAccountRequest
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string ActivationCode { get; set; }
    }
}
