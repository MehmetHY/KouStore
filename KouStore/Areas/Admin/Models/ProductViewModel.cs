using KouStore.Data;
using KouStore.Models;
using KouStore.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using KouStore.Config;
using System.ComponentModel.DataAnnotations;

namespace KouStore.Areas.Admin.Models
{
    public class ProductViewModel : IFormViewModel
    {
        public ProductModel Product { get; set; } = new();
        public CategoryModel Category { get; set; } = new();
        [DataType(DataType.Upload)]
        public IFormFile? ImageFile { get; set; }
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

        public ProductViewModel() {}
        public ProductViewModel(CategoryModel category) { Category = category; }
        public ProductViewModel(CategoryModel category, ProductModel product) 
        { 
            Category = category; 
            Product = product;
        }

        public void Setup(AppDbContext db, Controller _)
        {
            DbContext = db;
        }
        public void ValidateViewModel()
        {
            TrimFields();
            if (IsThereAnyEmptyTextField()) return;
            if (!IsPriceValid()) return;
            ValidateImage();
        }
        private void TrimFields()
        {
            Product.Title = Product.Title?.Trim() ?? string.Empty;
            Product.Description = Product.Description?.Trim() ?? string.Empty;
        }
        private bool IsThereAnyEmptyTextField()
        {
            bool result = false;
            if (string.IsNullOrEmpty(Product.Title))
            {
                TitleError = "Title cannot be empty!";
                TitleValid = false;
                result = true;
            }
            if (string.IsNullOrEmpty(Product.Description))
            {
                DescriptionError = "Description cannot be empty!";
                DescriptionValid = false;
                result = true;
            }
            return result;
        }
        private bool IsPriceValid()
        {
            if (Product.Price < decimal.Zero)
            {
                PriceError = "Price cannot be negative!";
                PriceValid = false;
                return false;
            }
            return true;
        }
        private void ValidateImage()
        {
            if (DidTryToUpload() && IsUploadImageValid())
            {
                Product.SetImageDataURL(ImageFile);
            }
            else if (!DidTryToUpload() && !IsCurrentImageExist())
            {
                ImageValid = false;
                ImageError = "Image cannot be empty!";
            }
        }
        private bool DidTryToUpload() => ImageFile != null;
        private bool IsCurrentImageExist() => Product.Image != null;
        private bool IsUploadImageValid()
        {
            if (ImageFile!.Length > Settings.MaxImageSizeInBytes)
            {
                ImageError = $"Image size cannot be greater than {Settings.MaxImageSizeInMB}MB!";
                ImageValid = false;
                return false;
            }
            string extension = Path.GetExtension(ImageFile.FileName);
            if (!Settings.AllowedImageExtensions.Contains(extension))
            {
                ImageError = "Image extension must be \".jpeg\"!";
                ImageValid = false;
                return false;
            }
            return true;
        }
    }
}
