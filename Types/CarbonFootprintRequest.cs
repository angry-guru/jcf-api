namespace jcf_api.Types
{
    public class CarbonFootprintRequest
    {
        public int NumberOfFlights { get;set; }
        public int NumberOfDays { get;set; }
        public AmountOption AmountOfPaper { get; set; }
    }
}
