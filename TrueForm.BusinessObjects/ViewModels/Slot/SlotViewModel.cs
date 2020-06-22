namespace TrueForm.BusinessObjects.ViewModels.Slot
{
    public class SlotViewModel
    {
        public string TierTypeName { get; set; }
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
