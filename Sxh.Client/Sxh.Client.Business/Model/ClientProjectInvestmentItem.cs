using Shared.Util;
using Sxh.Shared.Response.Model;
using System;

namespace Sxh.Client.Business.Model
{
    public class ClientProjectInvestmentItem : ProjectInvestmentItem
    {
        #region Property

        private double? _rate;
        public double Rate
        {
            get
            {
                if (!_rate.HasValue)
                {
                    _rate = TypeParser.GetDoubleValue($"{ratePart1}.{ratePart2}");
                }
                return _rate.Value;
            }
        }

        #endregion

        #region Method

        public double GetActualRate(PeriodType periodType)
        {
            switch (periodType)
            {
                case PeriodType.Day:
                    var periodActual = Math.Max(5, period);
                    var rateActual = Rate * period / 3.65 + periodActual;
                    return rateActual;
                case PeriodType.Month:
                    return Rate + 1.8;
                default:
                    return 0;
            }
        }

        #endregion
    }
}
