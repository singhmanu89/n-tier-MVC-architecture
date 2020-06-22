using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueForm.BusinessObjects.Infrastructure;

namespace TrueForm.BusinessObjects.DomainClasses
{
    public class CompanySlot : BaseEntity
    {
        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }
        public int CompanyId { get; set; }
        
        [ForeignKey("SlotId")]
        public virtual Slot Slot { get; set; }
        public int SlotId { get; set; }

    }
}
