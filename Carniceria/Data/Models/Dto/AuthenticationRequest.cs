using System.ComponentModel.DataAnnotations;

namespace Carniceria.Data.Models.Dto
{
    public class AuthenticationRequest
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }

    }
}
