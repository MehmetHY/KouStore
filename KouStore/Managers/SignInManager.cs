using KouStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace KouStore.Managers
{
    public static class SignInManager
    {
        public const string ADMIN_ID_KEY = "AdminId";
        public static bool IsAdminSignedIn(ISession session)
        {
            return session.GetString(ADMIN_ID_KEY) != null;
        }
        public static void SignInAdmin(ISession session, AdminModel admin)
        {
            session.SetString(ADMIN_ID_KEY, admin.Id.ToString());
        }
        public static void LogOutAdmin(ISession session)
        {
            session.Remove(ADMIN_ID_KEY);
        }
        public static IActionResult ConvertActionToAdminAuthenticatedAction(IActionResult action, Controller controller)
        {
            if (IsAdminSignedIn(controller.HttpContext.Session))
            {
                return action;
            }
            return controller.RedirectToAction("Index", "SignIn", new { Area = "Admin" });
        }
    }
}
