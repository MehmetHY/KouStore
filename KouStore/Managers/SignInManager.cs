using KouStore.Areas.Admin.Models;
using KouStore.Models;
using KouStore.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KouStore.Managers
{
    public static class SignInManager
    {
        public const string ADMIN_ID_KEY = "AdminId";

        public static bool IsAdminSignedIn(ISession session) => 
            session.GetString(ADMIN_ID_KEY) != null;

        public static void SignInAdmin(AdminViewModel model)
        {
            model.Session?.SetString(ADMIN_ID_KEY, model.Admin.Id.ToString());
        }

        public static void LogOutAdmin(ISession session)
        {
            if (IsAdminSignedIn(session))
                session.Remove(ADMIN_ID_KEY);
        }

        public static IActionResult ToAdminAuthAction(this IActionResult action, Controller controller) => 
            IsAdminSignedIn(controller.HttpContext.Session) ? 
                action : 
                controller.RedirectToAction("Index", "SignIn", new { Area = "Admin" });
    }
}
