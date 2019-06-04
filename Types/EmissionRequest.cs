namespace jcf_api.Types
{
    public class EmissionRequest
    {
        public CarbonFootprintRequest NonUser { get; set; }
        public CarbonFootprintRequest User { get; set; }
    }
}
