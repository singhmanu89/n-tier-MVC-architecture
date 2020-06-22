using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TrueForm.BusinessObjects.BindingModels.Kiosk;
using TrueForm.BusinessObjects.Enums;
using TrueForm.BusinessObjects.Helpers;
using TrueForm.BusinessObjects.Interfaces.Company;
using TrueForm.BusinessObjects.Interfaces.Kiosk;
using TrueForm.BusinessObjects.Interfaces.Product;
using TrueForm.BusinessObjects.Interfaces.Slot;

namespace TrueForm.Api.Controllers.Product
{
    [Authorize]
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        private readonly IProductService _productService; 

        public ProductController(IProductService productService)
        {
            _productService = productService; 
        }

        [Route("")]
        public DataActionResponse GetAllProducts()
        { 
            return _productService.GetAllProducts()
                                    .CreateDataActionResponseSuccess();
        }

        [Route("GetProductById/{productId}")]
        public DataActionResponse GetProductById(int productId)
        {
            return _productService.GetProductById(productId)
                                    .CreateDataActionResponseSuccess();
        }

        [Route("GetProductBySlotId/{slotId}")]
        public DataActionResponse GetProductBySlotId(int slotId)
        {
            return _productService.GetProductBySlotId(slotId)
                                    .CreateDataActionResponseSuccess();
        }

        [Route("GetProductsByCompanyId/{companyId}")]
        public DataActionResponse GetProductsByCompanyId(int companyId)
        {
            return _productService.GetProductsByCompanyId(companyId)
                                    .CreateDataActionResponseSuccess();
        }
        
    }
}
