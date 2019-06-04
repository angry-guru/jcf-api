using jcf_api.Types;

namespace jcf_api.Extensions
{
    public static class TimeOptionExtensions
    {
        public static int GetDays(this TimeOption option)
        {
            switch(option)
            {
                case (TimeOption.week):
                    return 7;
                case (TimeOption.month):
                    return 30;
                case (TimeOption.year):
                    return 365;
                default:
                    return 1;
            }
        }

        public static string GetDescription(this TimeOption option)
        {
            switch(option)
            {
                case (TimeOption.day):
                    return "1 day";
                case (TimeOption.week):
                    return "1 week";
                case (TimeOption.month):
                    return "1 month";
                case (TimeOption.year):
                    return "1 year";
                default:
                    return string.Empty;
            }
        }
    } 
}
