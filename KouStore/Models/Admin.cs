using System.ComponentModel.DataAnnotations;

namespace KouStore.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public string UId { get; set; }
        public string Password { get; set; }
    }
}
