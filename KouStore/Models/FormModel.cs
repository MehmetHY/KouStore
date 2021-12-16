﻿using KouStore.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KouStore.Models
{
    public class FormModel
    {
        public IViewModel ViewModel { get; set; }
        public Controller CurrentController { get; set; }
        public string ViewName { get; set; } = string.Empty;
        public IActionResult TargetAction { get; set; }
        public delegate void ViewModelAction(IViewModel model);
        public ViewModelAction SuccessAction { get; set; }
        private bool IsFormValid() => 
            ViewModel.Result;
        public IActionResult ProcessForm() 
        {
            ViewModel.ValidateViewModel();
            if (IsFormValid())
            {
                SuccessAction(ViewModel);
                return TargetAction;
            }
            return CurrentController.RedirectToAction(ViewName, new { formModel = this });
        }
    }
}
