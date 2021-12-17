using KouStore.Data;
using KouStore.Models;
using KouStore.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KouStore.Areas.Admin.Models
{
    public class CategoryViewModel : IViewModel
    {
        public CategoryModel Category { get; set; } = new();
        public bool NameValid { get; set; } = true;
        public string NameError { get; set; } = string.Empty;
        public AppDbContext? DbContext { get; set; }
        public bool Result => NameValid;

        public CategoryViewModel()
        {

        }
        public CategoryViewModel(CategoryModel category)
        {
            Category = category;
        }

        public void Setup(AppDbContext db, Controller _)
        {
            DbContext = db;
        }

        public void ValidateViewModel()
        {
            TrimNameField();
            if (IsNameEmpty()) return;
            CheckNameExists();
        }
        private void TrimNameField()
        {
            Category.Name = Category.Name?.Trim() ?? string.Empty;
        }
        private bool IsNameEmpty()
        {
            if (Category.Name == string.Empty)
            {
                NameValid = false;
                NameError = "Category name cannot be empty!";
                return true;
            }
            return false;
        }
        private void CheckNameExists()
        {
            CategoryModel? queryModel = DbContext.GetCategoryByName(Category.Name);
            if (queryModel != null)
            {
                NameValid = false;
                NameError = $"Category \"{Category.Name}\" already exists!";
            }
        }

    }
}
