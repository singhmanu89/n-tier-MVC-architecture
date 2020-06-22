using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueForm.BusinessObjects.BindingModels.Kiosk;
using TrueForm.BusinessObjects.DomainClasses;
using TrueForm.BusinessObjects.ViewModels.Kiosk;
using TrueForm.DataLayer.Infrastructure;
using TrueForm.DataLayer.Repositories.Interfaces;
using System.Data.Entity;
using PagedList;

namespace TrueForm.DataLayer.Repositories
{
    public class KioskRepository : GenericRepository<Kiosk>, IKioskRepository
    {
        public KioskRepository(TrueFormDbContext context) : base(context)
        {

        }
        public Kiosk FindOne(int kioskId)
        {
            var kiosk = Context.Kiosks.FirstOrDefault(x => x.Id == kioskId);
            return kiosk;
        }

        public IQueryable<Kiosk> FindKioskByLocationId(int locationId)
        {
            var kiosk = Context.Kiosks.Include(c => c.Location)
                                    .Include(x => x.Slots)
                                    .Where(x => x.LocationId == locationId);

            return kiosk;
        }

        public IPagedList<Kiosk> Filter(int kioskId)
        {
            var kiosk = Context.Kiosks.Where(x => x.Id == kioskId);
            return kiosk.OrderByDescending(o => o.Id).ToPagedList(1, 1000);
        }

        public IPagedList<Kiosk> Filter()
        {
            var kiosk = Context.Kiosks.Include(c => c.Location)
                                    .Include(x => x.Slots);
            return kiosk.OrderByDescending(o => o.Id).ToPagedList(1, 1000);
        }

    }
}