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
using TrueForm.DataLayer.Repositories.Interfaces;
using System.Data.Entity;
namespace TrueForm.DataLayer.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(TrueFormDbContext context) : base(context)
        {

        }

        public Product FindProductByCompanyId(int companyId)
        {
            var product = Context.Products.FirstOrDefault(x => x.CompanyId == companyId);
            return product;
        }

        IPagedList<Product> IProductRepository.Filter(int companyId)
        {
            //TODO: Id need to be replace by kiosk id or pick first product by default
            var slots = Context.Products.Where(x => x.CompanyId == companyId)
               .OrderByDescending(o => o.Id).ToPagedList(1, 1000);
            return slots;
        }

        public IPagedList<Product> GetAllProducts()
        {
            var products = Context.Products
              .OrderByDescending(o => o.Id).ToPagedList(1, 1000);
            return products;
        }

        public Product FindOne(int productId)
        {
            var product = Context.Products.FirstOrDefault(x => x.Id == productId);
            return product;
        }

       
         
    }
}