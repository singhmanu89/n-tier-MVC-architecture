using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueForm.BusinessObjects.Infrastructure;

namespace TrueForm.BusinessObjects.DomainClasses
{
    public class KioskStaff : BaseEntity
    {
        [ForeignKey("KioskId")]
        public virtual Kiosk Kiosk { get; set; }
        public int KioskId { get; set; }
         
        public string StaffMemberName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

    }
}
