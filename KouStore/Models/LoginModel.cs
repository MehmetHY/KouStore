using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KouStore.Models
{
    public class LoginModel
    {
        [DisplayName("User Name")]
        [DataType(DataType.Text)]
        [Required]
        public string UId { get; set; } = string.Empty;
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
