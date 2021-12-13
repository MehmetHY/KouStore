﻿using System.ComponentModel.DataAnnotations;

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
