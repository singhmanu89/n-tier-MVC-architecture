using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueForm.BusinessObjects.Enums;
using TrueForm.BusinessObjects.Infrastructure;

namespace TrueForm.BusinessObjects.DomainClasses
{
    public class Slot : BaseEntity
    {
        public SystemDataListEnums.TierType TierTypeId { get; set; }
        [ForeignKey("KioskId")]
        public virtual Kiosk Kiosk { get; set; }
        public int KioskId { get; set; }
        public string SlotName { get; set; }
        public double JanPrice { get; set; }
        public double FebPrice { get; set; }    
        public double MarPrice { get; set; }
        public double AprPrice { get; set; }
        public double MayPrice { get; set; }
        public double JunePrice { get; set; }
        public double JulyPrice { get; set; }
        public double AugPrice { get; set; }
        public double SepPrice { get; set; }
        public double OctPrice { get; set; }
        public double NovPrice { get; set; }
        public double DecPrice { get; set; }
        public double NextJanPrice { get; set; }
        public double NextFebPrice { get; set; }
        public double NextMarPrice { get; set; }

        public bool IsAvailable { get; set; }   

    }
}
