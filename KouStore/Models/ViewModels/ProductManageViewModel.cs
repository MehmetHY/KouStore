using KouStore.Data;
using KouStore.Managers;

namespace KouStore.Models.ViewModels
{
    public class ProductManageViewModel
    {
        private readonly AppDbContext _db;
        public ProductModel Product { get; set; } = new ProductModel();
        public List<CategoryModel> Categories { get; set; } = new List<CategoryModel>();
        public List<SubCategoryModel> SubCategories { get; set; } = new List<SubCategoryModel>();
        public ProductValidation ProductValidate { get; set; } = new ProductValidation();
        public int SubCategoryId { get; set; }
        public FormFile? PreviewImage { get; set; } = null;
        public List<FormFile> Images { get; set; } = new List<FormFile>();
        public ProductManageViewModel(AppDbContext db)
        {
            _db = db;
            PopulateCategories();
        }
        private void PopulateCategories()
        {
            Categories = _db.GetAllCategories();
            SubCategories = _db.GetAllSubCategories();
        }
        public void SetupProductFromForm()
        {
            Product.Category = _db.GetSubCategoryById(SubCategoryId);
            string title = Product.NameEnglish ?? "image";
            Product.PreviewImage.Title = $"{title}_preview";
            Product.PreviewImage.Data = ImageFileToArray(PreviewImage);
            for (int i = 0; i < Images.Count; i++)
            {
                var data = ImageFileToArray(Images[i]);
                Product.Images.Add(new ImageModel() { Title = $"{title}_{i}", Data = data });
            }
        }
        private static byte[] ImageFileToArray(FormFile? file)
        {
            if (file == null) return Array.Empty<byte>();
            MemoryStream stream = new();
            file.CopyTo(stream);
            var arr = stream.ToArray();
            stream.Close();
            stream.Dispose();
            return arr;
        }
    }
}
