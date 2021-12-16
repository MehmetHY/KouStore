using KouStore.Data;
using Microsoft.AspNetCore.Mvc;

namespace KouStore.Models.Interfaces
{
    public interface IViewModel
    {
        public AppDbContext? DbContext { get; set; }
        public void Setup(AppDbContext db, Controller controller);
        public bool Result { get; }
        public void ValidateViewModel();
    }
}
