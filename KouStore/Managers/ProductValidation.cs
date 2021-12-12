using KouStore.Data;
using KouStore.Models;

namespace KouStore.Managers
{
    public class ProductValidation
    {
        public string NameErrorMessage { get; set; } = string.Empty;
        public bool NameValid { get; set; } = true;
        public string DescriptionErrorMessage { get; set; } = string.Empty;
        public bool DescriptionValid { get; set; } = true;
        public string PriceErrorMessage { get; set; } = string.Empty;
        public bool PriceValid { get; set; } = true;
        public string CategoryErrorMessage { get; set; } = string.Empty;
        public bool CategoryValid { get; set; } = true;
        public string StockErrorMessage { get; set; } = string.Empty;
        public bool StockValid { get; set; } = true;

        private bool ValidateProduct(ProductModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                NameValid = false;
            }
            if (string.IsNullOrWhiteSpace(model.Description))
            {
                DescriptionValid = false;
            }
            if (model.Price < 0 || model.Price > 99999)
            {
                PriceValid = false;
            }
            if (model.Category == null)
            {
                CategoryValid = false;
            }
            if (model.StockQuantity < 0 || model.StockQuantity > 99999)
            {
                StockValid = false;
            }
            return !GetResult();
        }

        private bool GetResult()
        {
            return NameValid && DescriptionValid && PriceValid && CategoryValid && StockValid;
        }
    }
}
