namespace Sxh.Client.Business.Model
{
    public class MonitorInfo
    {
        public bool IsLocked { get; private set; }

        private ClientProjectInvestmentList _projectInvestmentMonth;
        public ClientProjectInvestmentList ProjectInvestmentMonth
        {
            get { return _projectInvestmentMonth ?? (_projectInvestmentMonth = new ClientProjectInvestmentList()); }
            set { _projectInvestmentMonth = value; }
        }

        private ClientProjectInvestmentList _projectInvestmentDay;
        public ClientProjectInvestmentList ProjectInvestmentDay
        {
            get { return _projectInvestmentDay ?? (_projectInvestmentDay = new ClientProjectInvestmentList()); }
            set { _projectInvestmentDay = value; }
        }

        public void Lock()
        {
            IsLocked = true;
        }

        public void UnLock()
        {
            IsLocked = false;
        }
    }
}
