using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueForm.BusinessObjects.Enums;
using TrueForm.BusinessObjects.Infrastructure;

namespace TrueForm.BusinessObjects.DomainClasses
{
    public class Product : BaseEntity
    {
        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }
        public int CompanyId { get; set; }
        
        [ForeignKey("ReviewId")]
        public virtual Review Review { get; set; }
        public int ReviewId { get; set; } 

        public string Name { get; set; }
        public string ProductUrl { get; set; }

        public string AmazonFetchType { get; set; }
        public SystemDataListEnums.ProductIdType? AmazonProductIdTypeId { get; set; }

        public string BestBuyFetchType { get; set; }
        public SystemDataListEnums.ProductIdType? BestBuyProductIdTypeId { get; set; }
        public string ProductTagLine { get; set; }
        public double Price { get; set; }
        public Guid? Image { get; set; }
        public string VideoUrl { get; set; }
        public string Description { get; set; }
        public int? Quantity { get; set; } 
        public SystemDataListEnums.SaleType SaleTypeId { get; set; }
        public string IosLink { get; set; }
        public string AndroidLink { get; set; }

    }
}
