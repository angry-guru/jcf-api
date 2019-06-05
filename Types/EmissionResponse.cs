namespace jcf_api.Types
{
    public class EmissionResponse
    {
        public EmissionResult NonUser { get; set; }
        public EmissionResult User { get; set; }
        public int SavedTrees { get; set; }
        public double SavedCost { get; set; }
    }
}
