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
    public interface ISlotRepository : IGenericRepository<Slot>
    {
        Slot FindOne(int slotId);
        IPagedList<Slot> Filter(int kioskId, SystemDataListEnums.TierType tierTypeId);
        IPagedList<Slot> Filter(int kioskId);
    }
}
