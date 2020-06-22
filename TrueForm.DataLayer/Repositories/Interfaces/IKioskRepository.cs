using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using TrueForm.BusinessObjects.BindingModels.Kiosk;
using TrueForm.BusinessObjects.DomainClasses;
using TrueForm.BusinessObjects.ViewModels.Kiosk;
using TrueForm.DataLayer.Infrastructure;

namespace TrueForm.DataLayer.Repositories.Interfaces
{
    public interface IKioskRepository : IGenericRepository<Kiosk>
    {
        Kiosk FindOne(int kioskId);
        IQueryable<Kiosk> FindKioskByLocationId(int locationId);
        IPagedList<Kiosk> Filter(int kioskId);
        IPagedList<Kiosk> Filter();


    }
}
