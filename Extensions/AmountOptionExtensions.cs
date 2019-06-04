using jcf_api.Types;

namespace jcf_api.Extensions
{
    public static class AmountOptionExtensions
    {
        private const double OnePaperWeightLbs = 0.011;

        public static double GetAverageValue(this AmountOption option)
        {
            switch(option)
            {
                case (AmountOption.LessThan100):
                    return 66.67; // calculated empiricaly based on opencard stats of approximate dayly processing equal ~1k samples (15 per 1 page)
                case (AmountOption.From100To500):
                    return 368;
                case (AmountOption.From500To1k):
                    return 835;
                case (AmountOption.From1kTo10k):
                    return 4333;
                case (AmountOption.MoreThan10k):
                    return 21718;
                default:
                    return 1;
            }
        }

        public static string GetDescription(this AmountOption option)
        {
            switch(option)
            {
                case (AmountOption.LessThan100):
                    return "Less than 100";
                case (AmountOption.From100To500):
                    return "100-500";
                case (AmountOption.From500To1k):
                    return "500-1,000";
                case (AmountOption.From1kTo10k):
                    return "1,000-10,000";
                case (AmountOption.MoreThan10k):
                    return "More than 10,000";
                default:
                    return string.Empty;
            }
        }

        public static double GetLbsWeight(this AmountOption option)
        {
            return option.GetAverageValue() * OnePaperWeightLbs;
        }
    } 
}