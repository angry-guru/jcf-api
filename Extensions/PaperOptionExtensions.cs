using jcf_api.Types;

namespace jcf_api.Extensions
{
    public static class AmountOptionExtensions
    {
        private const double OnePaperWeightLbs = 0.011;

        public static double GetAverageValue(this PaperOption option)
        {
            switch(option)
            {
                case (PaperOption.LessThan100):
                    return 66.67; // calculated empiricaly based on opencard stats of approximate dayly processing equal ~1k samples (15 per 1 page)
                case (PaperOption.From100To500):
                    return 368;
                case (PaperOption.From500To1k):
                    return 835;
                case (PaperOption.From1kTo10k):
                    return 4333;
                case (PaperOption.MoreThan10k):
                    return 21718;
                default:
                    return 0;
            }
        }

        public static string GetDescription(this PaperOption option)
        {
            switch(option)
            {
                case (PaperOption.LessThan100):
                    return "Less than 100";
                case (PaperOption.From100To500):
                    return "100-500";
                case (PaperOption.From500To1k):
                    return "500-1,000";
                case (PaperOption.From1kTo10k):
                    return "1,000-10,000";
                case (PaperOption.MoreThan10k):
                    return "More than 10,000";
                default:
                    return "Don't use paper";
            }
        }

        public static double GetLbsWeight(this PaperOption option)
        {
            return option.GetAverageValue() * OnePaperWeightLbs;
        }
    } 
}