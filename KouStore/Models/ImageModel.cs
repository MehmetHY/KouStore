using System.ComponentModel.DataAnnotations;

namespace KouStore.Models
{
    public class ImageModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string Title { get; set; } = "image";
        [Required]
        [DataType(DataType.Upload)]
        public byte[] Data { get; set; } = new byte[1000000];
    }
}
