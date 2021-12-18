﻿using KouStore.Models.Absracts;
using KouStore.Models;

namespace KouStore.Areas.Customer.Models
{
    public class HomePageViewModel : QueryPageViewModel<ProductModel>
    {
        public override List<ProductModel> QueryModels { get; set; } = new();
        public List<CategoryModel> Categories { get; set; } = new();
    }
}