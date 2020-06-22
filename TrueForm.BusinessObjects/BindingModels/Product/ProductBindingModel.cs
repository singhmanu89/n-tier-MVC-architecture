using System;
using System.Collections.Generic;
using TrueForm.BusinessObjects.Enums;

namespace TrueForm.BusinessObjects.BindingModels.Product
{
    public class ProductBindingModel
    {
        public int CompanyId { get; set; } 
        public string Name { get; set; }
        public string ProductUrl { get; set; }

        public string AmazonFetchType { get; set; }
        public int? AmazonProductIdTypeId { get; set; } 

        public string BestBuyFetchType { get; set; }
        public int? BestBuyProductIdTypeId { get; set; } 
        public string ProductTagLine { get; set; }
        public double Price { get; set; }
        public Guid? Image { get; set; }
        public string VideoUrl { get; set; }
        public string Description { get; set; }
        public int? Quantity { get; set; }
        public int SaleTypeId { get; set; }
        public string SaleTypeName { get; set; }
        public string IosLink { get; set; }
        public string AndroidLink { get; set; }
        
    }
}
