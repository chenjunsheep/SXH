using System.Collections.Generic;
using System.Linq;

namespace Sxh.Client.Business.Model
{
    public class ClientPortionTransferList
    {
        #region Property

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
                if (Count <= 0) return new ClientPortionTransferItem();
                return rowSet[0];
            }
        }

        #endregion

        #region Public Method

        public void Clear()
        {
            rowSet = new List<ClientPortionTransferItem>();
        }

        public void AddRange(List<ClientPortionTransferItem> source)
        {
            if (rowSet == null)
            {
                rowSet = new List<ClientPortionTransferItem>();
            }
            if (source != null)
            {
                rowSet.AddRange(source);
            }
        }

        public void Lock()
        {
            IsLocked = true;
        }

        public void UnLock()
        {
            IsLocked = false;
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

        public void UpdateFromPayment(IEnumerable<ClientPaymentItem> payments)
        {
            if (Count > 0 && payments != null && payments.Count() > 0)
            {
                var list = (from tran in rowSet
                            join payment in payments on tran.projectId equals payment.Id
                            select ClientPortionTransferItem.Create(tran, payment)).ToList();
                rowSet = list;
            }
        }

        #endregion
    }
}
