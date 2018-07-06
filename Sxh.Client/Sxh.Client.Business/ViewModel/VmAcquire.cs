using System.Net;

namespace Sxh.Client.Business.ViewModel
{
    public class VmAcquire
    {
        public double AcquisitionPrice { get; set; }
        public int Copies { get; set; }
        public int ProjectId { get; set; }
        public string TokenAcquire { get; set; }
        public string TockenKey { get; set; }
        public double ShowPrice { get; set; }
        public string TransactionPassword { get; set; }
        public string VerificationCode { get; set; }
        public CookieCollection TokenOffical { get; set; }
    }
}
