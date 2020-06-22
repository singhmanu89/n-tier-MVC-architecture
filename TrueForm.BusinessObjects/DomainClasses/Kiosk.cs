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
    public class Kiosk : BaseEntity
    {
        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }
        public int LocationId { get; set; }

        public virtual ICollection<Slot> Slots { get; set; }

        public string Name { get; set; }
        public string Neighborhood { get; set; }
        public int AnnualAmount { get; set; }
        public int NumberOfSlots { get; set; }
        public int TierType1Slots { get; set; }
        public int TierType2Slots { get; set; }
        public double TierType1Weight { get; set; }
        public double TierType2Weight { get; set; }
        public string Overview { get; set; }
        public string RegularHoursMondayToSaturday { get; set; }
        public string RegularHoursSunday { get; set; }
        public string HolidayHoursMondayToSaturday { get; set; }
        public string HolidayHoursSunday { get; set; }
        public bool IsReserved { get; set; }
            
        public double JanPercentage { get; set; }
        public double FebPercentage { get; set; }
        public double MarPercentage { get; set; }
        public double AprPercentage { get; set; }
        public double MayPercentage { get; set; }
        public double JunePercentage { get; set; }
        public double JulyPercentage { get; set; }
        public double AugPercentage { get; set; }
        public double SepPercentage { get; set; }
        public double OctPercentage { get; set; }
        public double NovPercentage { get; set; }
        public double DecPercentage { get; set; }
        public double NextJanPercentage { get; set; }
        public double NextFebPercentage { get; set; }
        public double NextMarPercentage { get; set; }
    }
}
