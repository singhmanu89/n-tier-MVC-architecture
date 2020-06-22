using System.Collections.Generic;
using System.Linq;
using PagedList;
using TrueForm.BusinessObjects.BindingModels.Kiosk;
using TrueForm.BusinessObjects.BindingModels.Product;
using TrueForm.BusinessObjects.DomainClasses;
using TrueForm.BusinessObjects.Enums;
using TrueForm.BusinessObjects.Extensions;
using TrueForm.BusinessObjects.Generic;
using TrueForm.BusinessObjects.ViewModels.Company;
using TrueForm.BusinessObjects.ViewModels.Kiosk;
using TrueForm.BusinessObjects.ViewModels.Product;
using TrueForm.BusinessObjects.ViewModels.Slot;

namespace TrueForm.BusinessObjects.Serializers
{
    public static class ProductMapper
    {
        public static ProductViewModel ToViewModel(this Product model)
        {
            var viewModel = model.Map<Product, ProductViewModel>(
                cfg =>
                {
                    cfg.CreateMap<Product, ProductViewModel>()
                    .ForMember(x => x.CompanyName, x => x.MapFrom(y => y.Company.Name));
                }
            );
            return viewModel;
        }

        public static TrueFormPagedList<ProductViewModel> ToViewModel(this IPagedList<Product> models)
        {
            var viewModels = new List<ProductViewModel>();

            models.ToList().ForEach(b =>
            {
                viewModels.Add(ToViewModel(b));
            });

            return viewModels.ToTrueFormPagedList(models.GetMetaData());
        }

        public static Product ToEntity(this ProductBindingModel model, int kioskId, Product original = null)
        {
            var isUpdate = original != null;
            var entity = isUpdate
                ? model.Map(original)                     // update
                : model.Map<ProductBindingModel, Product>();  //insert
            return entity;

        }
    }
}
