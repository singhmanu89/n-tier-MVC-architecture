using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using TrueForm.BusinessObjects.BindingModels.Kiosk;
using TrueForm.BusinessObjects.DomainClasses;
using TrueForm.BusinessObjects.Enums;
using TrueForm.BusinessObjects.ViewModels.Kiosk;
using TrueForm.DataLayer.Infrastructure;

namespace TrueForm.DataLayer.Repositories.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Product FindOne(int productId);
        Product FindProductByCompanyId(int companyId);
        IPagedList<Product> Filter(int companyId);
        IPagedList<Product> GetAllProducts(); 
    }
}
