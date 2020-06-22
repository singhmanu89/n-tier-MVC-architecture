using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueForm.BusinessObjects.BindingModels.Kiosk;
using TrueForm.BusinessObjects.Enums;
using TrueForm.BusinessObjects.Generic;
using TrueForm.BusinessObjects.ViewModels.Company;
using TrueForm.BusinessObjects.ViewModels.Kiosk;
using TrueForm.BusinessObjects.ViewModels.Product;
using TrueForm.BusinessObjects.ViewModels.Slot;

namespace TrueForm.BusinessObjects.Interfaces.Product
{
    public interface IProductService
    {
        ProductViewModel GetProductById(int productId);
        ProductViewModel GetProductBySlotId(int companyId);    
        TrueFormPagedList<ProductViewModel> GetProductsByCompanyId(int companyId);
        TrueFormPagedList<ProductViewModel> GetAllProducts();  
    }
}
