using KouStore.Data;
using KouStore.Models.Interfaces;
using KouStore.Models;
using KouStore.Managers;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace KouStore.Areas.Customer.Models
{
    public class RegisterViewModel : IFormViewModel
    {
        public CustomerModel Customer { get; set; } = new();
        public Controller? CurrentController { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; } = string.Empty;
        public bool NameValid { get; set; } = true;
        public bool PasswordValid { get; set; } = true;
        public bool ConfirmPasswordValid { get; set; } = true;
        public string NameError { get; set; } = string.Empty;
        public string PasswordError { get; set; } = string.Empty;
        public string ConfirmPasswordError { get; set; } = string.Empty;
        public AppDbContext? DbContext { get; set; }
        public bool Result => NameValid && PasswordValid && ConfirmPasswordValid;

        public void Setup(AppDbContext db, Controller controller) 
        {
            DbContext = db; 
            CurrentController = controller;
        }
        public void ValidateViewModel()
        {
            TrimWhiteSpaceFromFields();
            if (IsThereAnyEmptyField()) return;
            if (IsNameExist()) return;
            CheckPasswordsMatch();
        }
        private void TrimWhiteSpaceFromFields()
        {
            Customer.Name = Customer.Name?.Trim() ?? string.Empty;
            Customer.Password = Customer.Password?.Trim() ?? string.Empty;
            ConfirmPassword = ConfirmPassword?.Trim() ?? string.Empty;
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
            if (Customer.Password == string.Empty)
            {
                PasswordValid = false;
                PasswordError = "Password cannot be empty!";
                return true;
            }
            if (ConfirmPassword == string.Empty)
            {
                ConfirmPasswordValid = false;
                ConfirmPasswordError = "Confirm password cannot be empty!";
                return true;
            }
            return false;
        }
        private bool IsNameExist()
        {
            if (CustomerDbManager.IsExist(Customer.Name, DbContext))
            {
                NameValid = false;
                NameError = $"Name \"{Customer.Name}\"";
                return true;
            }
            return false;
        }
        private void CheckPasswordsMatch()
        {
            if (ConfirmPassword != Customer.Password)
            {
                ConfirmPasswordValid = false;
                ConfirmPasswordError = "Passwords don't match!";
            }
        }
    }
}
