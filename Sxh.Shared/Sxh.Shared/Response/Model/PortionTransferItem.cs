namespace Sxh.Shared.Response.Model
{
    public class PortionTransferItem
    {
        //收购份数
        public int? acquisitionCopies { get; set; }
        //建议委托价
        public double? advicePrice { get; set; }
        //标准年化
        public double? annualizedReturnRate { get; set; }
        //最近溢折率
        public double? latestRate { get; set; }
        //最近转让年化
        public double? latestReturnRate { get; set; }
        //最近转让价
        public double? latestTransPrice { get; set; }
        //收购价
        public double? maxAcquisitionPrice { get; set; }
        //收购年化
        public double? maxAcquisitionRate { get; set; }
        //转让价
        public double? minTransferingPrice { get; set; }
        //转让年化
        public double? minTransferingRate { get; set; }
        //项目ID
        public int projectId { get; set; }
        //项目名
        public string projectTitle { get; set; }
        //剩余天数
        public int? remainingDays { get; set; }
        //转让份数
        public int? transferingCopies { get; set; }
    }
}
