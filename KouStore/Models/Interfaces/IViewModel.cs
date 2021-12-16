using KouStore.Data;

namespace KouStore.Models.Interfaces
{
    public interface IViewModel
    {
        public AppDbContext? DbContext { get; set; }
        public void Setup(AppDbContext db);
        public bool Result { get; }
        public void ValidateViewModel();
    }
}
