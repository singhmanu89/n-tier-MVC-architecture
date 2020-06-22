using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TrueForm.BusinessObjects.DomainClasses;

namespace TrueForm.DataLayer
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // InsertKiosk custom user claims here
            return userIdentity;
        }
    }
    public class TrueFormDbContext: IdentityDbContext<ApplicationUser>
    {
        public DbSet<Company> Company { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Lease> Leases { get; set; }
        public DbSet<Kiosk> Kiosks { get; set; }
        public DbSet<Review> Reviews { get; set; } 
        public DbSet<KioskStaff> KioskStaff { get; set; }
        public DbSet<Slot> Slots { get; set; }
        public DbSet<CompanySlot> CompanySlots { get; set; }
        public TrueFormDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static TrueFormDbContext Create()
        {
            return new TrueFormDbContext();
        }
    }
}
