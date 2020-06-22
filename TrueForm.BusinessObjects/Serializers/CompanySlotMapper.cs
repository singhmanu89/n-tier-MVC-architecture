using System.Collections.Generic;
using System.Linq;
using PagedList;
using TrueForm.BusinessObjects.BindingModels.Kiosk;
using TrueForm.BusinessObjects.DomainClasses;
using TrueForm.BusinessObjects.Enums;
using TrueForm.BusinessObjects.Extensions;
using TrueForm.BusinessObjects.Generic;
using TrueForm.BusinessObjects.ViewModels.Company;
using TrueForm.BusinessObjects.ViewModels.CompanySlot;
using TrueForm.BusinessObjects.ViewModels.Kiosk;
using TrueForm.BusinessObjects.ViewModels.Slot;

namespace TrueForm.BusinessObjects.Serializers
{
    public static class CompanySlotMapper
    {
        public static CompanySlotViewModel ToViewModel(this CompanySlot model)
        {
            var viewModel = model.Map<CompanySlot, CompanySlotViewModel>(
                cfg =>
                {
                    cfg.CreateMap<CompanySlot, CompanySlotViewModel>()
                    .ForMember(x => x.CompanyId, x => x.MapFrom(y => y.CompanyId))
                    .ForMember(x => x.CompanyName, x => x.MapFrom(y => y.Company.Name))
                    .ForMember(x => x.SlotName, x => x.MapFrom(y => y.Slot.SlotName));
                }
            );
            return viewModel;
        }

        public static TrueFormPagedList<CompanySlotViewModel> ToViewModel(this IPagedList<CompanySlot> models)
        {
            var viewModels = new List<CompanySlotViewModel>();

            models.ToList().ForEach(b =>
            {
                viewModels.Add(ToViewModel(b));
            });

            return viewModels.ToTrueFormPagedList(models.GetMetaData());
        }
        //public static Slot ToSlotEntity(this KioskBindingModel model, int kioskId, SystemDataListEnums.TierType tierTypeId, string slotName, Slot original = null)
        //{
        //    var isUpdate = original != null;
        //    var entity = isUpdate
        //        ? model.Map(original)                     // update
        //        : model.Map<KioskBindingModel, Slot>();  //insert
        //    entity.SlotName = slotName;
        //    entity.KioskId = kioskId;
        //    entity.TierTypeId = tierTypeId;
        //    entity.IsAvailable = true;
        //    return entity;

        //}
    }
}
