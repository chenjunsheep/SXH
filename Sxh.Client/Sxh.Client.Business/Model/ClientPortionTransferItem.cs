using Sxh.Shared.Response.Model;
using System;

namespace Sxh.Client.Business.Model
{
    public class ClientPortionTransferItem : PortionTransferItem
    {
        public string DisplayTransferingRate
        {
            get
            {
                return minTransferingRate.HasValue ? $"{Math.Round(minTransferingRate.Value, 2)}%" : string.Empty;
            }
        }

        public double Yijia
        {
            get
            {
                return minTransferingPrice.HasValue && advicePrice.HasValue ? 100 * Math.Round((minTransferingPrice.Value - advicePrice.Value) / advicePrice.Value, 4) : 0;
            }
        }

        public string DisplayYijia
        {
            get
            {
                return $"{Yijia}%";
            }
        }
    }
}
