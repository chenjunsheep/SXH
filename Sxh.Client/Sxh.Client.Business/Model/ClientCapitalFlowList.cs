using Shared.Util;
using System.Collections.Generic;

namespace Sxh.Client.Business.Model
{
    public class ClientCapitalFlowList
    {
        public List<ClientCapitalFlowItem> rowSet { get; set; }

        public double GetCash()
        {
            if (rowSet != null && rowSet.Count > 0)
            {
                return TypeParser.GetDoubleValue(rowSet[0].availableAmount);
            }

            return 0;
        }
    }
}
