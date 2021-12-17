using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static KouStore.Config.Settings;

namespace KouStore.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Text)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public byte[]? Image { get; set; }
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; } = decimal.Zero;
    
        public string GetImageDataURL() => Image == null ? 
            string.Empty : 
            string.Format("data:image/jpg;base64, {0}", Convert.ToBase64String(Image));

        public void SetImageDataURL(IFormFile file)
        {
            MemoryStream ms = new();
            file.CopyTo(ms);
            Image = ms.ToArray();
            ms.Close();
            ms.Dispose();
        }
    }

}
