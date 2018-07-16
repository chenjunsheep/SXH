using Sxh.Shared.Response.Model;
using System;

namespace Sxh.Client.Business.Model
{
    public class ClientPortionTransferItem : PortionTransferItem
    {
        public int NexPaymentDayRemain { get; set; }

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

        public string GetProjectInformation()
        {
            return $"{DisplayTransferingRate}/{DisplayYijia} {transferingCopies} {projectTitle}";
        }

        public double GetAvailableCopies(double availableCash)
        {
            if (minTransferingPrice.HasValue && transferingCopies.HasValue)
            {
                return Math.Min(Math.Floor(availableCash / minTransferingPrice.Value / 100) * 100, transferingCopies.Value);
            }
            return 0;
        }

        public double NextRemainDay { get; set; }
        public string DisplayNextRemainDay
        {
            get
            {
                return NextRemainDay >= 0 ? $"{(int)NextRemainDay}天" : "-";
            }
        }

        public double ProjectRate { get; set; }
        public string PayType { get; set; }
        public string DisplayProjectTitle
        {
            get
            {
                var prefix = ProjectRate > 0 ? $"{ProjectRate}% " : string.Empty;
                prefix += !string.IsNullOrEmpty(PayType) ? $"{PayType} " : string.Empty;
                return $"{prefix}{projectTitle}";
            }
        }

        public static ClientPortionTransferItem Create(ClientPortionTransferItem trans, ClientPaymentItem payment)
        {
            var item = new ClientPortionTransferItem();

            if (trans != null)
            {
                item.acquisitionCopies = trans.acquisitionCopies;
                item.advicePrice = trans.advicePrice;
                item.annualizedReturnRate = trans.annualizedReturnRate;
                item.latestRate = trans.latestRate;
                item.latestReturnRate = trans.latestReturnRate;
                item.latestTransPrice = trans.latestTransPrice;
                item.maxAcquisitionPrice = trans.maxAcquisitionPrice;
                item.maxAcquisitionRate = trans.maxAcquisitionRate;
                item.minTransferingPrice = trans.minTransferingPrice;
                item.minTransferingRate = trans.minTransferingRate;
                item.projectId = trans.projectId;
                item.projectTitle = trans.projectTitle;
                item.remainingDays = trans.remainingDays;
                item.transferingCopies = trans.transferingCopies;
            }

            if (payment != null)
            {
                item.NextRemainDay = payment.NextRemainDay;
                item.ProjectRate = payment.Rate;
                item.PayType = payment.PayType;
            }

            return item;
        }
    }
}
