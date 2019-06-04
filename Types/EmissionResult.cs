namespace jcf_api.Types
{
    public class EmissionResult
    {
        public CarbonFootprintResult Flights { get;set; }
        public CarbonFootprintResult Accomodation { get;set; }
        public CarbonFootprintResult Paper { get; set; }
        public double TotalTons { get; set; }
        public double TotalCost { get; set; }
    }
}
