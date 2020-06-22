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

namespace TrueForm.DataLayer.Repositories
{
    public class SlotRepository : GenericRepository<Slot>, ISlotRepository
    {
        public SlotRepository(TrueFormDbContext context) : base(context)
        {

        }


        Slot ISlotRepository.FindOne(int slotId)
        {
            var slots = Context.Slots.FirstOrDefault(x => x.Id == slotId);
            return slots;
        }

        IPagedList<Slot> ISlotRepository.Filter(int kioskId, SystemDataListEnums.TierType tierTypeId)
        {
            var slots = Context.Slots.Where(x => x.KioskId == kioskId && x.TierTypeId == tierTypeId)
                .OrderByDescending(o=>o.Id).ToPagedList(1, 1000);
            return slots;
        }

        public IPagedList<Slot> Filter(int kioskId)
        {
            var slots = Context.Slots.Where(x => x.KioskId == kioskId)
                .OrderByDescending(o => o.Id).ToPagedList(1, 1000);
            return slots;
        }
    }
}