using KouStore.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KouStore.Models
{
    public class LoginModel
    {
        [DisplayName("Admin Name")]
        [DataType(DataType.Text)]
        [Required]
        public string UId { get; set; } = string.Empty;
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; } = string.Empty;
        public string ErrorMessage { get; private set; } = string.Empty;

        public (bool, AdminModel?) IsUIdValid(AppDbContext db)
        {
            if (UId == string.Empty)
            {
                ErrorMessage = "Admin Name cannot be empty!";
                return (false, null);
            }
            AdminModel? admin = db.Admins.Where(a => a.UId == UId).FirstOrDefault();
            if (admin == null || admin.UId != UId)
            {
                ErrorMessage = $"Admin \"{UId}\" doesn't exist!";
                return (false, null);
            }
            return (true, admin);
        }
        public bool IsPasswordValid(AdminModel admin)
        {
            if (Password == string.Empty)
            {
                ErrorMessage = "Admin Name cannot be empty!";
                return false;
            }
            if (admin.Password != Password)
            {
                ErrorMessage = "Wrong password";
                return false;
            }
            return true;
        }
    }
}
