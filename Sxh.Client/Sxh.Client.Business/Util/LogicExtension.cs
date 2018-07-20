using Sxh.Client.Business.Model;

namespace Sxh.Client.Business.Util
{
    public static class LogicExtension
    {
        public static string ConvertToQueryValue(this PeriodType periodType)
        {
            switch (periodType)
            {
                case PeriodType.Day:
                    return "IN_30_DAYS";
                case PeriodType.Month:
                    return "IN_1_MONTHS";
                default:
                    return "ALL";
            }
        }
    }
}
