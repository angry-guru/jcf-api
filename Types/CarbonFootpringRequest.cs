using jcf_api.Types;

namespace jcf_api.Type
{
    public class CarbonFootprintRequest
    {
        public int FlightsNumber { get;set; }
        public int HotelDaysNumber { get;set; }
        public AmountOption PaperAmount { get; set; }
    }
}
