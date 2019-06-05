using jcf_api.Types;

namespace jcf_api.Extensions
{
    public static class FlightOptionExtensions
    {
        public static int GetAverageValue(this FlightOption option)
        {
            switch(option)
            {
                case (FlightOption.LessThan5):
                    return 3;
                case (FlightOption.From5To10):
                    return 8;
                case (FlightOption.From10To50):
                    return 34;
                case (FlightOption.From50To100):
                    return 81;
                case (FlightOption.From100To500):
                    return 340;
                case (FlightOption.MoreThan500):
                    return 811;
                default:
                    return 0;
            }
        }

        public static string GetDescription(this FlightOption option)
        {
            switch(option)
            {
                case (FlightOption.LessThan5):
                    return "Less than 5";
                case (FlightOption.From5To10):
                    return "5-10";
                case (FlightOption.From10To50):
                    return "10-50";
                case (FlightOption.From50To100):
                    return "50-100";
                case (FlightOption.From100To500):
                    return "100-500";
                case (FlightOption.MoreThan500):
                    return "More than 500";
                default:
                    return "Not flying anymore";
            }
        }
    } 
}
