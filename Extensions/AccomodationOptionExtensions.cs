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
                case (AccomodationOption.From3To7):
                    return 5;
                case (AccomodationOption.From7To30):
                    return 22;
                case (AccomodationOption.From30To100):
                    return 74;
                case (AccomodationOption.From100To365):
                    return 244;
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
                case (AccomodationOption.From3To7):
                    return "3-7";
                case (AccomodationOption.From7To30):
                    return "7-30";
                case (AccomodationOption.From30To100):
                    return "30-100";
                case (AccomodationOption.From100To365):
                    return "100-365";
                default:
                    return "Don't use";
            }
        }
    } 
}
