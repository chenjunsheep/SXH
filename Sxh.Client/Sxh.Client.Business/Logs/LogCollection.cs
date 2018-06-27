using System;
using System.Collections.Generic;
using System.Linq;

namespace Sxh.Client.Business.Logs
{
    public class LogCollection : List<Log>
    {
        private void Add(LogType logType, string memo)
        {
            var target = new Log() {
                Type = logType,
                Memo = $"[{DateTime.Now.ToString("hh:mm:ss")}] {memo}"
            };

            Add(target);
        }

        public void Message(string memo)
        {
            Add(LogType.Message, memo);
        }

        public void Warning(string memo)
        {
            Add(LogType.Warning, memo);
        }

        public void Error(string memo)
        {
            Add(LogType.Error, memo);
        }

        public List<Log> GetAll()
        {
            var all = new List<Log>();
            all.AddRange(this);
            all.Reverse();
            RemoveAll(log => true);
            return all;
        }
    }
}
