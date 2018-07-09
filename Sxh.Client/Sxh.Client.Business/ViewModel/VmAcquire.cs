using System.Net;

namespace Sxh.Client.Business.ViewModel
{
    public class VmAcquire
    {
        public double AcquisitionPrice { get; set; }
        public int Copies { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string TokenAcquire { get; set; }
        public string TockenKey { get; set; }
        public double ShowPrice { get; set; }
        public string TransactionPassword { get; set; }
        public string VerificationCode { get; set; }
        public CookieCollection TokenOffical { get; set; }

        public bool IsAvailable
        {
            get
            {
                return AcquisitionPrice > 0 
                    && Copies > 0 
                    && ProjectId > 0 
                    && !string.IsNullOrEmpty(TokenAcquire) 
                    && !string.IsNullOrEmpty(TockenKey) 
                    && !string.IsNullOrEmpty(TransactionPassword)
                    && !string.IsNullOrEmpty(VerificationCode)
                    && TokenOffical != null && TokenOffical.Count > 1;
            }
        }
    }
}
