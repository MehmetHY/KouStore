using KouStore.Areas.Admin.Models;
using KouStore.Areas.Customer.Models;
using KouStore.Data;
using KouStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace KouStore.Managers
{
    public static class SignInManager
    {
        public const string ADMIN_ID_KEY = "AdminId";
        public const string CUSTOMER_ID_KEY = "CustomerId";

        public static bool IsAdminSignedIn(this Controller controller) => 
            controller.HttpContext.Session.GetString(ADMIN_ID_KEY) != null;
        public static void SignInAdmin(AdminViewModel model)
        {
            model.Session?.SetString(ADMIN_ID_KEY, model.Admin.Id.ToString());
        }
        public static void LogOutAdmin(this Controller controller)
        {
            if (IsAdminSignedIn(controller))
                controller.HttpContext.Session.Remove(ADMIN_ID_KEY);
        }
        public static IActionResult ToAdminAuthAction(this IActionResult action, Controller controller) => 
            IsAdminSignedIn(controller) ? 
                action : 
                controller.RedirectToAction("Index", "SignIn", new { Area = "Admin" });

        public static int GetCurrentCustomerId(this ISession session) => 
            session.IsCustomerSignedIn() ? int.Parse(session.GetString(CUSTOMER_ID_KEY)!) : 0;
        public static bool IsCustomerSignedIn(this Controller controller) =>
            controller.HttpContext.Session.IsCustomerSignedIn();
        public static bool IsCustomerSignedIn(this ISession session) =>
            session.GetString(CUSTOMER_ID_KEY) != null;
        public static void SignInCustomer(this Controller controller, CustomerModel? customer)
        {
            if (customer == null) return;
            controller.HttpContext.Session.SetString(CUSTOMER_ID_KEY, customer.Id.ToString());
        }
        public static void SignInCustomer(SignInViewModel signInViewModel)
        {
            SignInCustomer(signInViewModel.CurrentController!, signInViewModel.Customer);
        }
        public static void LogOutCustomer(this Controller controller)
        {
            if (IsCustomerSignedIn(controller))
                controller.HttpContext.Session.Remove(CUSTOMER_ID_KEY);
        }
        public static CustomerModel? GetCurrentCustomer(this Controller controller, AppDbContext? db)
        {
            if (db == null) return null;
            string? idString = controller.HttpContext.Session.GetString(CUSTOMER_ID_KEY);
            int id;
            if (!int.TryParse(idString, out id)) return null;
            return CustomerDbManager.GetCustomer(id, db);
        }
    }
}
