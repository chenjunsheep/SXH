using Sxh.Client.Business.Model;

namespace Sxh.Client.Business.Util
{
    public static class LogicExtension
    {
        public static string ConvertToQueryValue(this PeriodType periodType)
        {
            switch (periodType)
            {
                case PeriodType.Day30:
                    return "IN_30_DAYS";
                case PeriodType.Month1:
                    return "IN_1_MONTHS";
                default:
                    return "ALL";
            }
        }
    }
}
