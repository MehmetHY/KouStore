using System.ComponentModel.DataAnnotations;
using static KouStore.Config.Settings;

namespace KouStore.Models
{
    public class ImageModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Upload)]
        public IFormFile? Data { get; set; }
    }
}
