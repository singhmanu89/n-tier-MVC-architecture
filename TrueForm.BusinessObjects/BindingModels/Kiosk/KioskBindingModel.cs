using System;
using System.Collections.Generic;
using TrueForm.BusinessObjects.Enums;

namespace TrueForm.BusinessObjects.BindingModels.Kiosk
{
    public class KioskBindingModel
    {
        public string Name { get; set; }
        public string Neighborhood { get; set; }
        public int LocationId { get; set; }
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


        public List<string> Type1Slots { get; set; }
        public List<string> Type2Slots { get; set; }
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

        public double Tier2JanPrice { get; set; }
        public double Tier2FebPrice { get; set; }
        public double Tier2MarPrice { get; set; }
        public double Tier2AprPrice { get; set; }
        public double Tier2MayPrice { get; set; }
        public double Tier2JunePrice { get; set; }
        public double Tier2JulyPrice { get; set; }
        public double Tier2AugPrice { get; set; }
        public double Tier2SepPrice { get; set; }
        public double Tier2OctPrice { get; set; }
        public double Tier2NovPrice { get; set; }
        public double Tier2DecPrice { get; set; }
        public double Tier2NextJanPrice { get; set; }
        public double Tier2NextFebPrice { get; set; }
        public double Tier2NextMarPrice { get; set; }

    }
}
