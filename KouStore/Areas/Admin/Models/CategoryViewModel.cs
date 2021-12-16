using KouStore.Data;
using KouStore.Models;
using KouStore.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KouStore.Areas.Admin.Models
{
    public class CategoryViewModel : IViewModel
    {
        public CategoryModel Category { get; set; }
        public bool NameValid { get; set; } = true;
        public string NameError { get; set; } = string.Empty;
        public AppDbContext? DbContext { get; set; }
        public bool Result => NameValid;

        public void Setup(AppDbContext db, Controller _)
        {
            DbContext = db;
        }

        public void ValidateViewModel()
        {
            throw new NotImplementedException();
        }
    }
}
