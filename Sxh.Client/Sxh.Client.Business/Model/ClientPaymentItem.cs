using Shared.Util;
using Sxh.Shared.Response.Model;
using System;

namespace Sxh.Client.Business.Model
{
    public class ClientPaymentItem : PaymentItem
    {
        private DateTime? _nextPaymentDate;
        public DateTime NextPaymentDate
        {
            get
            {
                if (!_nextPaymentDate.HasValue)
                {
                    _nextPaymentDate = TypeParser.GetDateTimeValueExact(NextPayment, "yyyy/MM/dd");
                }
                if (!_nextPaymentDate.HasValue)
                {
                    _nextPaymentDate = DateTime.Now.AddDays(-1);
                }
                return _nextPaymentDate.Value;
            }
        }

        public double NextRemainDay
        {
            get { return (NextPaymentDate - DateTime.Now).TotalDays; }
        }
    }
}
