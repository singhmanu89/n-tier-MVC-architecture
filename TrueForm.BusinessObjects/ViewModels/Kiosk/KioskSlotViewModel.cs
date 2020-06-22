using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueForm.BusinessObjects.Enums;

namespace TrueForm.BusinessObjects.ViewModels.Kiosk
{
    public class KioskSlotViewModel
    {
        public int KioskId { get; set; }
      
        public SystemDataListEnums.TierType TierTypeId { get; set; }
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
