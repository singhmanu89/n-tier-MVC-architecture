using System.ComponentModel;

namespace TrueForm.BusinessObjects.Enums
{
    public class SystemDataListEnums
    {
        public enum SaleType
        {
            [Description("Inventory")]
            Inventory = 1,
            [Description("Non Inventory")]
            NonInventory = 2
        }
        public enum TierType
        {
            [Description("Tier 1")]
            Tier1 = 1,
            [Description("Tier 2")]
            Tier2 = 2
        }

        public enum ProductIdType
        {
            [Description("URL")]
            URL = 1,
            [Description("SKU")]
            SKU = 2
        }
    }
}
