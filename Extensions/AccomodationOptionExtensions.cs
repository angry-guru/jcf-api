using jcf_api.Types;

namespace jcf_api.Extensions
{
    public static class AccomodationOptionExtensions
    {
        public static int GetAverageValue(this AccomodationOption option)
        {
            switch(option)
            {
                case (AccomodationOption.LessThan3):
                    return 2;
                case (AccomodationOption.From3To10):
                    return 7;
                case (AccomodationOption.From10To50):
                    return 34;
                case (AccomodationOption.From50To100):
                    return 81;
                case (AccomodationOption.From100To500):
                    return 340;
                case (AccomodationOption.MoreThan500):
                    return 811;
                default:
                    return 0;
            }
        }

        public static string GetDescription(this AccomodationOption option)
        {
            switch(option)
            {
                case (AccomodationOption.LessThan3):
                    return "Less than 3";
                case (AccomodationOption.From3To10):
                    return "3-10";
                case (AccomodationOption.From10To50):
                    return "10-50";
                case (AccomodationOption.From50To100):
                    return "50-100";
                case (AccomodationOption.From100To500):
                    return "100-500";
                case (AccomodationOption.MoreThan500):
                    return "More than 500";
                default:
                    return "Don't use";
            }
        }
    } 
}
