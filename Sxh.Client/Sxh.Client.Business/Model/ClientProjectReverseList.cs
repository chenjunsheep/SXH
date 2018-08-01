using System.Collections.Generic;
using System.Linq;

namespace Sxh.Client.Business.Model
{
    public class ClientProjectReverseList
    {
        public List<ClientProjectReverseItem> rowSet { get; set; }

        public int Count
        {
            get { return rowSet == null ? 0 : rowSet.Count; }
        }

        public ClientProjectReverseItem BestItem
        {
            get
            {
                if (Count <= 0) return null;
                return rowSet.FindAll(r => r.StatusType == ClientProjectReverseItem.ReverseStatusType.Wait).OrderBy(r => r.RateActual).FirstOrDefault();
            }
        }
    }
}
