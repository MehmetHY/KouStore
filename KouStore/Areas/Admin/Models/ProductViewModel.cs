
using KouStore.Data;
using KouStore.Models;
using KouStore.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KouStore.Areas.Admin.Models
{
    public class ProductViewModel : IViewModel
    {
        public ProductModel Product { get; set; } = new();
        public CategoryModel? Category { get; set; }
        public bool TitleValid { get; set; } = true;
        public bool DescriptionValid { get; set; } = true;
        public bool ImageValid { get; set; } = true;
        public bool PriceValid { get; set; } = true;
        public string TitleError { get; set; } = string.Empty;
        public string DescriptionError { get; set; } = string.Empty;
        public string ImageError { get; set; } = string.Empty;
        public string PriceError { get; set; } = string.Empty;
        public AppDbContext? DbContext { get; set; }

        public bool Result => TitleValid && DescriptionValid && ImageValid && PriceValid;


        public void Setup(AppDbContext db, Controller _)
        {
            DbContext = db;
        }

        public void ValidateViewModel()
        {
            TrimFields();
        }

        private void TrimFields()
        {
            Product.Title = Product.Title?.Trim() ?? string.Empty;
            Product.Description = Product.Description?.Trim() ?? string.Empty;
        }
    }
}
