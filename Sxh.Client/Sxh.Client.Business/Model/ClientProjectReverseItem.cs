using Sxh.Shared.Response.Model;
using System;

namespace Sxh.Client.Business.Model
{
    public class ClientProjectReverseItem : ProjectReverseItem
    {
        #region Property

        private ReverseStatusType? _statusType;
        public ReverseStatusType StatusType
        {
            get
            {
                if (!_statusType.HasValue)
                {
                    switch (status.name)
                    {
                        case Status.Namespace.WAIT:
                            _statusType = ReverseStatusType.Wait;
                            break;
                        default:
                            _statusType = ReverseStatusType.Done;
                            break;
                    }
                }
                return _statusType.Value;
            }
        }

        private ReversePeriodType? _periodType;
        public ReversePeriodType PeriodType
        {
            get
            {
                if (!_periodType.HasValue)
                {
                    switch (repaymentStrategy.name)
                    {
                        case RepaymentType.Namespace.DAY:
                            _periodType = ReversePeriodType.Day;
                            break;
                        case RepaymentType.Namespace.MONTH:
                            _periodType = ReversePeriodType.Month;
                            break;
                        default:
                            _periodType = ReversePeriodType.None;
                            break;
                    }
                }
                return _periodType.Value;
            }
        }

        private double? _rateActual;
        public double RateActual
        {
            get
            {
                if (!_rateActual.HasValue)
                {
                    _rateActual = GetActualRate();
                }
                return _rateActual.Value;
            }
        }

        #endregion

        #region Private Method

        private double GetActualRate()
        {
            switch (PeriodType)
            {
                case ReversePeriodType.Day:
                    var periodActual = Math.Max(5, period);
                    var rateActual = rate + periodActual / period * 3.65;
                    return rateActual;
                case ReversePeriodType.Month:
                    return rate + 1.8;
                default:
                    return rate;
            }
        }

        #endregion

        #region Class

        public enum ReverseStatusType
        {
            Done,
            Wait,
        }

        public enum ReversePeriodType
        {
            None,
            Day,
            Month,
        }

        #endregion

    }
}
