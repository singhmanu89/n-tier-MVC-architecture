using System.Collections.Generic;
using System.Linq;
using PagedList;
using TrueForm.BusinessObjects.BindingModels.Kiosk;
using TrueForm.BusinessObjects.DomainClasses;
using TrueForm.BusinessObjects.Enums;
using TrueForm.BusinessObjects.Extensions;
using TrueForm.BusinessObjects.Generic;
using TrueForm.BusinessObjects.ViewModels.Company;
using TrueForm.BusinessObjects.ViewModels.Kiosk;

namespace TrueForm.BusinessObjects.Serializers
{
    public static class KioskMapper
    {
        public static KioskViewModel ToViewModel(this Kiosk model)
        {
            var viewModel = model.Map<Kiosk, KioskViewModel>(
                cfg =>
                {
                    cfg.CreateMap<Kiosk, KioskViewModel>()
                    .ForMember(x => x.LocationName, x => x.MapFrom(y => y.Location.LocationName));
                }
            );
            return viewModel;
        }

        public static TrueFormPagedList<KioskViewModel> ToViewModel(this IPagedList<Kiosk> models)
        {
            var viewModels = new List<KioskViewModel>();

            models.ToList().ForEach(b =>
            {
                viewModels.Add(ToViewModel(b));
            });

            return viewModels.ToTrueFormPagedList(models.GetMetaData());
        }

        public static IEnumerable<KioskViewModel> ToListViewModel(this IPagedList<Kiosk> models)
        {
            var viewModels = new List<KioskViewModel>();

            models.ToList().ForEach(b =>
            {
                viewModels.Add(ToViewModel(b));
            });

            return viewModels;
        }

        public static Kiosk ToEntity(this KioskBindingModel model, Kiosk original = null)
        {
            var isUpdate = original != null;
            var entity = isUpdate
                ? model.Map(original)                     // update
                : model.Map<KioskBindingModel, Kiosk>();  //insert
            return entity;

        }
         

       
    }
}
