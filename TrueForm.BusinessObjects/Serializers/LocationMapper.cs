using System.Collections.Generic;
using System.Linq;
using PagedList;
using TrueForm.BusinessObjects.BindingModels.Kiosk;
using TrueForm.BusinessObjects.BindingModels.Location;
using TrueForm.BusinessObjects.DomainClasses;
using TrueForm.BusinessObjects.Enums;
using TrueForm.BusinessObjects.Extensions;
using TrueForm.BusinessObjects.Generic;
using TrueForm.BusinessObjects.ViewModels.Company;
using TrueForm.BusinessObjects.ViewModels.CompanySlot;
using TrueForm.BusinessObjects.ViewModels.Kiosk;
using TrueForm.BusinessObjects.ViewModels.Location;

namespace TrueForm.BusinessObjects.Serializers
{
    public static class LocationMapper
    {
        public static LocationViewModel ToViewModel(this Location model)
        {
            var viewModel = model.Map<Location, LocationViewModel>(
                cfg =>
                {
                    cfg.CreateMap<Location, LocationViewModel>();
                }
            );
            return viewModel;
        }

        public static TrueFormPagedList<LocationViewModel> ToViewModel(this IPagedList<Location> models)
        {
            var viewModels = new List<LocationViewModel>();

            models.ToList().ForEach(b =>
            {
                viewModels.Add(ToViewModel(b));
            });

            return viewModels.ToTrueFormPagedList(models.GetMetaData());
        }
        public static IEnumerable<LocationViewModel> ToViewModel(this IEnumerable<Location> models)
        {
            var viewModels = new List<LocationViewModel>();

            models.ToList().ForEach(b =>
            {
                viewModels.Add(ToViewModel(b));
            });

            return viewModels;
        }

        public static Location ToEntity(this LocationBindingModel model, Location original = null)
        {
            var isUpdate = original != null;
            var entity = isUpdate
                ? model.Map(original)                     // update
                : model.Map<LocationBindingModel, Location>();  //insert
             
            return entity;

        }
         
    }
}
