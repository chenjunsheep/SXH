using System.Collections.Generic;

namespace Sxh.Client.Business.Model
{
    public class ClientProjectInvestmentList
    {
        public List<ClientProjectInvestmentItem> rowSet { get; set; }

        public int Count
        {
            get { return rowSet == null ? 0 : rowSet.Count; }
        }

        public ClientProjectInvestmentItem TopItem
        {
            get
            {
                if (Count <= 0) return null;
                return rowSet[0];
            }
        }
    }
}
