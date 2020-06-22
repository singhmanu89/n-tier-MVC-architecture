using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using TrueForm.BusinessObjects.BindingModels.Kiosk;
using TrueForm.BusinessObjects.Enums;
using TrueForm.BusinessObjects.Generic;
using TrueForm.BusinessObjects.Interfaces.Company;
using TrueForm.BusinessObjects.Interfaces.Kiosk;
using TrueForm.BusinessObjects.Interfaces.Product;
using TrueForm.BusinessObjects.Interfaces.Slot;
using TrueForm.BusinessObjects.Serializers;
using TrueForm.BusinessObjects.ViewModels.Company;
using TrueForm.BusinessObjects.ViewModels.Kiosk;
using TrueForm.BusinessObjects.ViewModels.Product;
using TrueForm.BusinessObjects.ViewModels.Slot;
using TrueForm.DataLayer.Repositories.Interfaces;
using TrueForm.Services.Infrastructure;

namespace TrueForm.Services.Product
{
    public class ProductService : ApplicationService, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly ICompanySlotRepository _companySlotRepository;

        public ProductService(IProductRepository productRepository,ICompanyRepository companyRepository,ICompanySlotRepository companySlotRepository)
        {
            _productRepository = productRepository;
            _companyRepository = companyRepository;
            _companySlotRepository = companySlotRepository;
        }
        
        public ProductViewModel GetProductById(int productId)
        {
            var product = _productRepository.FindOne(productId);
            return product.ToViewModel();
        }

        public ProductViewModel GetProductBySlotId(int slotId)
        {
            //Fetch Company From Slot Id
            var companySlot = _companySlotRepository.FindCompanyBySlotId(slotId);

            var companySlotViewModel = companySlot.ToViewModel();
            var companyId = companySlotViewModel.CompanyId;

            var product = _productRepository.FindProductByCompanyId(companyId);
            return product.ToViewModel(); 
        }

        public TrueFormPagedList<ProductViewModel> GetProductsByCompanyId(int companyId)
        {
            var products = _productRepository.Filter(companyId);
            return products.ToViewModel();
        }

        public TrueFormPagedList<ProductViewModel> GetAllProducts()
        {
            var products = _productRepository.GetAllProducts();
            return products.ToViewModel();
        }
    }
}
