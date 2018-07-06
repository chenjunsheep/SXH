using System.Collections.Generic;
using System.Linq;

namespace Sxh.Client.Business.Model
{
    public class ClientPortionTransferList
    {
        public List<ClientPortionTransferItem> rowSet { get; set; }

        public int Count
        {
            get { return rowSet == null ? 0 : rowSet.Count; }
        }

        public bool IsLocked { get; private set; }

        public ClientPortionTransferItem TopItem
        {
            get
            {
                if (rowSet == null || rowSet.Count == 0) return new ClientPortionTransferItem();
                return rowSet[0];
            }
        }

        public ClientPortionTransferItem GetProjectById(int projectId)
        {
            if (Count > 0)
            {
                var target = rowSet.FirstOrDefault(p => p.projectId == projectId);
                return target;
            }
            return null;
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
