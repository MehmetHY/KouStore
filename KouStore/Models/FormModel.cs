using KouStore.Data;
using KouStore.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KouStore.Models
{
    public class FormModel<T> where T : IViewModel, new()
    {
        public T ViewModel { get; set; } = new T();
        public Controller CurrentController { get; set; }
        public string ViewName { get; set; } = string.Empty;
        public IActionResult TargetActionResult { get; set; }
        public delegate void ViewModelAction(T model);
        public ViewModelAction SuccessAction { get; set; }
        public void Setup(Controller controller, string viewName, IActionResult targetAction, ViewModelAction onSuccess, AppDbContext db)
        {
            CurrentController = controller;
            ViewName = viewName;
            TargetActionResult = targetAction;
            SuccessAction = onSuccess;
            ViewModel.Setup(db, controller);
        }
        public IActionResult ProcessForm() 
        {
            ViewModel.ValidateViewModel();
            if (IsFormValid())
            {
                SuccessAction(ViewModel);
                return TargetActionResult;
            }
            return CurrentController.View(ViewName, this);
        }
        private bool IsFormValid() => ViewModel.Result;
    }
}
