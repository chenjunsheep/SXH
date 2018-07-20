namespace Sxh.Client.Business.Model
{
    public class MonitorInfo
    {
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
    }
}
