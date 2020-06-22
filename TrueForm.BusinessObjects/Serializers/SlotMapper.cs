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
using TrueForm.BusinessObjects.ViewModels.Slot;

namespace TrueForm.BusinessObjects.Serializers
{
    public static class SlotMapper
    {
        public static SlotViewModel ToViewModel(this Slot model)
        {
            var viewModel = model.Map<Slot, SlotViewModel>(
                cfg =>
                {
                    cfg.CreateMap<Slot, SlotViewModel>()
                    .ForMember(x => x.TierTypeName, x => x.MapFrom(y => y.TierTypeId));
                }
            );
            return viewModel;
        }

        public static TrueFormPagedList<SlotViewModel> ToViewModel(this IPagedList<Slot> models)
        {
            var viewModels = new List<SlotViewModel>();

            models.ToList().ForEach(b =>
            {
                viewModels.Add(ToViewModel(b));
            });

            return viewModels.ToTrueFormPagedList(models.GetMetaData());
        }
        public static Slot ToSlotEntity(this KioskBindingModel model, int kioskId, SystemDataListEnums.TierType tierTypeId, string slotName, Slot original = null)
        {
            var isUpdate = original != null;
            var entity = isUpdate
                ? model.Map(original)                     // update
                : model.Map<KioskBindingModel, Slot>();  //insert
            entity.SlotName = slotName;
            entity.KioskId = kioskId;
            entity.TierTypeId = tierTypeId;
            entity.IsAvailable = true;

            if (tierTypeId != SystemDataListEnums.TierType.Tier2)
                return entity;

            entity.JanPrice = model.Tier2JanPrice;
            entity.FebPrice = model.Tier2FebPrice;
            entity.MarPrice = model.Tier2MarPrice;
            entity.AprPrice = model.Tier2AprPrice;
            entity.MayPrice = model.Tier2MayPrice;
            entity.JunePrice = model.Tier2JunePrice;
            entity.JulyPrice = model.Tier2JulyPrice;
            entity.AugPrice = model.Tier2AugPrice;
            entity.SepPrice = model.Tier2SepPrice;
            entity.OctPrice = model.Tier2OctPrice;
            entity.NovPrice = model.Tier2NovPrice;
            entity.DecPrice = model.Tier2DecPrice;
            entity.NextJanPrice = model.Tier2NextJanPrice;
            entity.NextFebPrice = model.Tier2NextFebPrice;
            entity.NextMarPrice = model.Tier2NextMarPrice;

            return entity;
        }
    }
}
