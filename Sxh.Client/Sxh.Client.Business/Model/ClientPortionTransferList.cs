using System.Collections.Generic;

namespace Sxh.Client.Business.Model
{
    public class ClientPortionTransferList
    {
        public List<ClientPortionTransferItem> rowSet { get; set; }

        public int Count
        {
            get { return rowSet == null ? 0 : rowSet.Count; }
        }

        public ClientPortionTransferItem TopItem
        {
            get
            {
                if (rowSet == null || rowSet.Count == 0) return new ClientPortionTransferItem();
                return rowSet[0];
            }
        }
    }
}
