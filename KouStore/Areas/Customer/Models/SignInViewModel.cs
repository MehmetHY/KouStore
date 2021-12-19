using KouStore.Data;
using KouStore.Models.Interfaces;
using KouStore.Models;
using KouStore.Managers;
using Microsoft.AspNetCore.Mvc;

namespace KouStore.Areas.Customer.Models
{
    public class SignInViewModel : IFormViewModel
    {
        public CustomerModel Customer { get; set; } = new();
        public Controller? CurrentController { get; set; }
        public bool NameValid { get; set; } = true;
        public bool PasswordValid { get; set; } = true;
        public string NameError { get; set; } = string.Empty;
        public string PasswordError { get; set; } = string.Empty;
        public AppDbContext? DbContext { get; set; }
        public bool Result => NameValid &&  PasswordValid;

        public void Setup(AppDbContext db, Controller currentController) 
        {
            DbContext = db; 
            CurrentController = currentController;
        }

        public void ValidateViewModel()
        {
            TrimWhiteSpaceFromFields();
            if (IsThereAnyEmptyField()) return;
            CheckNameAndPasswordCorrect();
        }
        private void TrimWhiteSpaceFromFields()
        {
            Customer.Name = Customer.Name?.Trim() ?? string.Empty;
            Customer.Password = Customer.Password?.Trim() ?? string.Empty;
        }
        private bool IsThereAnyEmptyField()
        {
            if (Customer.Name == string.Empty)
            {
                NameValid = false;
                NameError = "Name cannot be empty!";
                return true;
            }
            if (Customer.Password == string.Empty)
            {
                PasswordValid = false;
                PasswordError = "Password cannot be empty!";
                return true;
            }
            return false;
        }
        private void CheckNameAndPasswordCorrect()
        {
            var queryCustomer = CustomerDbManager.GetCustomer(Customer.Name, DbContext);
            if (queryCustomer == null)
            {
                NameValid = false;
                NameError = $"Name \"{Customer.Name}\" doesn't exist!";
            }
            else if (Customer.Password != queryCustomer.Password)
            {
                PasswordValid = false;
                PasswordError = "Password is incorrect!";
            }
            else
            {
                Customer = queryCustomer;
            }
        }
    }
}
